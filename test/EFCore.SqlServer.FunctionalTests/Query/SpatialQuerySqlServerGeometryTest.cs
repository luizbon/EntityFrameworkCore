﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.TestUtilities.Xunit;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query
{
#if !Test21
    public class SpatialQuerySqlServerGeometryTest : SpatialQueryTestBase<SpatialQuerySqlServerGeometryFixture>
    {
        public SpatialQuerySqlServerGeometryTest(SpatialQuerySqlServerGeometryFixture fixture, ITestOutputHelper testOutputHelper)
            : base(fixture)
        {
            Fixture.TestSqlLoggerFactory.Clear();
            //Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
        }

        public override async Task Area(bool isAsync)
        {
            await base.Area(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[Polygon].STArea() AS [Area]
FROM [PolygonEntity] AS [e]");
        }

        public override async Task AsBinary(bool isAsync)
        {
            await base.AsBinary(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[Point].STAsBinary() AS [Binary]
FROM [PointEntity] AS [e]");
        }

        public override async Task AsText(bool isAsync)
        {
            await base.AsText(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[Point].AsTextZM() AS [Text]
FROM [PointEntity] AS [e]");
        }

        public override async Task Boundary(bool isAsync)
        {
            await base.Boundary(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[Polygon].STBoundary() AS [Boundary]
FROM [PolygonEntity] AS [e]");
        }

        public override async Task Buffer(bool isAsync)
        {
            await base.Buffer(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[Polygon].STBuffer(1.0E0) AS [Buffer]
FROM [PolygonEntity] AS [e]");
        }

        public override async Task Centroid(bool isAsync)
        {
            await base.Centroid(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[Polygon].STCentroid() AS [Centroid]
FROM [PolygonEntity] AS [e]");
        }

        public override async Task Contains(bool isAsync)
        {
            await base.Contains(isAsync);

            AssertSql(
                @"@__point_0='0x00000000010C000000000000D03F000000000000D03F' (Size = 22) (DbType = Binary)

SELECT [e].[Id], [e].[Polygon].STContains(@__point_0) AS [Contains]
FROM [PolygonEntity] AS [e]");
        }

        public override async Task ConvexHull(bool isAsync)
        {
            await base.ConvexHull(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[Polygon].STConvexHull() AS [ConvexHull]
FROM [PolygonEntity] AS [e]");
        }

        public override async Task IGeometryCollection_Count(bool isAsync)
        {
            await base.IGeometryCollection_Count(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[MultiLineString].STNumGeometries() AS [Count]
FROM [MultiLineStringEntity] AS [e]");
        }

        public override async Task LineString_Count(bool isAsync)
        {
            await base.LineString_Count(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[LineString].STNumPoints() AS [Count]
FROM [LineStringEntity] AS [e]");
        }

        [ConditionalTheory(Skip = "Needs better argument type inference")]
        public override async Task Crosses(bool isAsync)
        {
            await base.Crosses(isAsync);

            AssertSql(
                @"@__lineString_0='0x000000000114000000000000E03F000000000000E0BF000000000000E03F0000...' (Size = 38) (DbType = Binary)

SELECT [e].[Id], [e].[LineString].STCrosses(@__lineString_0) AS [Crosses]
FROM [LineStringEntity] AS [e]");
        }

        public override async Task Difference(bool isAsync)
        {
            await base.Difference(isAsync);

            AssertSql(
                @"@__polygon_0='0x0000000001040400000000000000000000000000000000000000000000000000...' (Size = 96) (DbType = Binary)

SELECT [e].[Id], [e].[Polygon].STDifference(@__polygon_0) AS [Difference]
FROM [PolygonEntity] AS [e]");
        }

        public override async Task Dimension(bool isAsync)
        {
            await base.Dimension(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[Point].STDimension() AS [Dimension]
FROM [PointEntity] AS [e]");
        }

        public override async Task Disjoint(bool isAsync)
        {
            await base.Disjoint(isAsync);

            AssertSql(
                @"@__point_0='0x00000000010C000000000000F03F000000000000F03F' (Size = 22) (DbType = Binary)

SELECT [e].[Id], [e].[Polygon].STDisjoint(@__point_0) AS [Disjoint]
FROM [PolygonEntity] AS [e]");
        }

        [ConditionalTheory(Skip = "Needs better argument type inference")]
        public override async Task Distance(bool isAsync)
        {
            await base.Distance(isAsync);

            AssertSql(
                @"@__point_0='0x00000000010C0000000000000000000000000000F03F' (Size = 22) (DbType = Binary)

SELECT [e].[Id], [e].[Point].STDistance(@__point_0) AS [Distance]
FROM [PointEntity] AS [e]");
        }

        [ConditionalTheory(Skip = "Needs better result type inference")]
        public override async Task EndPoint(bool isAsync)
        {
            await base.EndPoint(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[LineString].STEndPoint() AS [EndPoint]
FROM [LineStringEntity] AS [e]");
        }

        public override async Task Envelope(bool isAsync)
        {
            await base.Envelope(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[Polygon].STEnvelope() AS [Envelope]
FROM [PolygonEntity] AS [e]");
        }

        public override async Task EqualsTopologically(bool isAsync)
        {
            await base.EqualsTopologically(isAsync);

            AssertSql(
                @"@__point_0='0x00000000010C00000000000000000000000000000000' (Size = 22) (DbType = Binary)

SELECT [e].[Id], [e].[Point].STEquals(@__point_0) AS [EqualsTopologically]
FROM [PointEntity] AS [e]");
        }

        [ConditionalTheory(Skip = "Needs better result type inference")]
        public override async Task ExteriorRing(bool isAsync)
        {
            await base.ExteriorRing(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[Polygon].STExteriorRing() AS [ExteriorRing]
FROM [PolygonEntity] AS [e]");
        }

        public override async Task GeometryType(bool isAsync)
        {
            await base.GeometryType(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[Point].STGeometryType() AS [GeometryType]
FROM [PointEntity] AS [e]");
        }

        [ConditionalTheory(Skip = "Needs better result type inference")]
        public override async Task GetGeometryN(bool isAsync)
        {
            await base.GetGeometryN(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[MultiLineString].STGeometryN(0 + 1) AS [Geometry0]
FROM [MultiLineStringEntity] AS [e]");
        }

        public override async Task GetInteriorRingN(bool isAsync)
        {
            await base.GetInteriorRingN(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[Polygon].STInteriorRingN(0 + 1) AS [InteriorRing0]
FROM [PolygonEntity] AS [e]
WHERE [e].[Polygon].STNumInteriorRing() > 0");
        }

        public override async Task GetPointN(bool isAsync)
        {
            await base.GetPointN(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[LineString].STPointN(0 + 1) AS [Point0]
FROM [LineStringEntity] AS [e]");
        }

        public override async Task InteriorPoint(bool isAsync)
        {
            await base.InteriorPoint(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[Polygon].STPointOnSurface() AS [InteriorPoint], [e].[Polygon]
FROM [PolygonEntity] AS [e]");
        }

        public override async Task Intersection(bool isAsync)
        {
            await base.Intersection(isAsync);

            AssertSql(
                @"@__polygon_0='0x0000000001040400000000000000000000000000000000000000000000000000...' (Size = 96) (DbType = Binary)

SELECT [e].[Id], [e].[Polygon].STIntersection(@__polygon_0) AS [Intersection]
FROM [PolygonEntity] AS [e]");
        }

        [ConditionalTheory(Skip = "Needs better argument type inference")]
        public override async Task Intersects(bool isAsync)
        {
            await base.Intersects(isAsync);

            AssertSql(
                @"@__lineString_0='0x000000000114000000000000E03F000000000000E0BF000000000000E03F0000...' (Size = 38) (DbType = Binary)

SELECT [e].[Id], [e].[LineString].STIntersects(@__lineString_0) AS [Intersects]
FROM [LineStringEntity] AS [e]");
        }

        public override async Task ICurve_IsClosed(bool isAsync)
        {
            await base.ICurve_IsClosed(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[LineString].STIsClosed() AS [IsClosed]
FROM [LineStringEntity] AS [e]");
        }

        public override async Task IMultiCurve_IsClosed(bool isAsync)
        {
            await base.IMultiCurve_IsClosed(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[MultiLineString].STIsClosed() AS [IsClosed]
FROM [MultiLineStringEntity] AS [e]");
        }

        public override async Task IsEmpty(bool isAsync)
        {
            await base.IsEmpty(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[MultiLineString].STIsEmpty() AS [IsEmpty]
FROM [MultiLineStringEntity] AS [e]");
        }

        public override async Task IsRing(bool isAsync)
        {
            await base.IsRing(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[LineString].STIsRing() AS [IsRing]
FROM [LineStringEntity] AS [e]");
        }

        public override async Task IsSimple(bool isAsync)
        {
            await base.IsSimple(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[LineString].STIsSimple() AS [IsSimple]
FROM [LineStringEntity] AS [e]");
        }

        public override async Task IsValid(bool isAsync)
        {
            await base.IsValid(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[Point].STIsValid() AS [IsValid]
FROM [PointEntity] AS [e]");
        }

        [ConditionalTheory(Skip = "Needs better argument type inference")]
        public override async Task IsWithinDistance(bool isAsync)
        {
            await base.IsWithinDistance(isAsync);

            AssertSql(
                @"@__point_0='0x00000000010C0000000000000000000000000000F03F' (Size = 22) (DbType = Binary)

SELECT [e].[Id], CASE
    WHEN [e].[Point].STDistance(@__point_0) <= 1.0E0
    THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT)
END AS [IsWithinDistance]
FROM [PointEntity] AS [e]");
        }

        [ConditionalTheory(Skip = "Needs better result type inference")]
        public override async Task Item(bool isAsync)
        {
            await base.Item(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[MultiLineString].STGeometryN(0 + 1) AS [Item0]
FROM [MultiLineStringEntity] AS [e]");
        }

        public override async Task Length(bool isAsync)
        {
            await base.Length(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[LineString].STLength() AS [Length]
FROM [LineStringEntity] AS [e]");
        }

        public override async Task M(bool isAsync)
        {
            await base.M(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[Point].M AS [M]
FROM [PointEntity] AS [e]");
        }

        public override async Task NumGeometries(bool isAsync)
        {
            await base.NumGeometries(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[MultiLineString].STNumGeometries() AS [NumGeometries]
FROM [MultiLineStringEntity] AS [e]");
        }

        public override async Task NumInteriorRings(bool isAsync)
        {
            await base.NumInteriorRings(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[Polygon].STNumInteriorRing() AS [NumInteriorRings]
FROM [PolygonEntity] AS [e]");
        }

        public override async Task NumPoints(bool isAsync)
        {
            await base.NumPoints(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[LineString].STNumPoints() AS [NumPoints]
FROM [LineStringEntity] AS [e]");
        }

        public override async Task Overlaps(bool isAsync)
        {
            await base.Overlaps(isAsync);

            AssertSql(
                @"@__polygon_0='0x0000000001040400000000000000000000000000000000000000000000000000...' (Size = 96) (DbType = Binary)

SELECT [e].[Id], [e].[Polygon].STOverlaps(@__polygon_0) AS [Overlaps]
FROM [PolygonEntity] AS [e]");
        }

        public override async Task PointOnSurface(bool isAsync)
        {
            await base.PointOnSurface(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[Polygon].STPointOnSurface() AS [PointOnSurface], [e].[Polygon]
FROM [PolygonEntity] AS [e]");
        }

        public override async Task Relate(bool isAsync)
        {
            await base.Relate(isAsync);

            AssertSql(
                @"@__polygon_0='0x0000000001040400000000000000000000000000000000000000000000000000...' (Size = 96) (DbType = Binary)

SELECT [e].[Id], [e].[Polygon].STRelate(@__polygon_0, N'212111212') AS [Relate]
FROM [PolygonEntity] AS [e]");
        }

        public override async Task SRID(bool isAsync)
        {
            await base.SRID(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[Point].STSrid AS [SRID]
FROM [PointEntity] AS [e]");
        }

        public override async Task StartPoint(bool isAsync)
        {
            await base.StartPoint(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[LineString].STStartPoint() AS [StartPoint]
FROM [LineStringEntity] AS [e]");
        }

        public override async Task SymmetricDifference(bool isAsync)
        {
            await base.SymmetricDifference(isAsync);

            AssertSql(
                @"@__polygon_0='0x0000000001040400000000000000000000000000000000000000000000000000...' (Size = 96) (DbType = Binary)

SELECT [e].[Id], [e].[Polygon].STSymDifference(@__polygon_0) AS [SymmetricDifference]
FROM [PolygonEntity] AS [e]");
        }

        public override async Task ToBinary(bool isAsync)
        {
            await base.ToBinary(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[Point].STAsBinary() AS [Binary]
FROM [PointEntity] AS [e]");
        }

        public override async Task ToText(bool isAsync)
        {
            await base.ToText(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[Point].AsTextZM() AS [Text]
FROM [PointEntity] AS [e]");
        }

        [ConditionalTheory(Skip = "Needs better argument type inference")]
        public override async Task Touches(bool isAsync)
        {
            await base.Touches(isAsync);

            AssertSql(
                @"@__polygon_0='0x000000000104040000000000000000000000000000000000F03F000000000000...' (Size = 96) (DbType = Binary)

SELECT [e].[Id], [e].[Polygon].STTouches(@__polygon_0) AS [Touches]
FROM [PolygonEntity] AS [e]");
        }

        public override async Task Union(bool isAsync)
        {
            await base.Union(isAsync);

            AssertSql(
                @"@__polygon_0='0x0000000001040400000000000000000000000000000000000000000000000000...' (Size = 96) (DbType = Binary)

SELECT [e].[Id], [e].[Polygon].STUnion(@__polygon_0) AS [Union]
FROM [PolygonEntity] AS [e]");
        }

        public override async Task Within(bool isAsync)
        {
            await base.Within(isAsync);

            AssertSql(
                @"@__polygon_0='0x00000000010405000000000000000000F0BF000000000000F0BF000000000000...' (Size = 112) (DbType = Binary)

SELECT [e].[Id], [e].[Point].STWithin(@__polygon_0) AS [Within]
FROM [PointEntity] AS [e]");
        }

        public override async Task X(bool isAsync)
        {
            await base.X(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[Point].STX AS [X]
FROM [PointEntity] AS [e]");
        }

        public override async Task Y(bool isAsync)
        {
            await base.Y(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[Point].STY AS [Y]
FROM [PointEntity] AS [e]");
        }

        public override async Task Z(bool isAsync)
        {
            await base.Z(isAsync);

            AssertSql(
                @"SELECT [e].[Id], [e].[Point].Z AS [Z]
FROM [PointEntity] AS [e]");
        }

        private void AssertSql(params string[] expected)
            => Fixture.TestSqlLoggerFactory.AssertBaseline(expected);
    }
#endif
}
