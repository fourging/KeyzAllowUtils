using System.Collections.Generic;
using JetBrains.Annotations;
using KeyzAllowUtilities;
using RimWorld;
using Verse;
using Xunit;

namespace KeyzAllowUtilities.Tests
{
    [TestSubject(typeof(FilterUtils))]
    public class FilterUtilsTest
    {
        [Fact]
        public void NotFogged_WhenCellIsFogged_ReturnsFalse()
        {
            var foggedCell = new IntVec3(1, 0, 1);
            var map = new Map();
            foggedCell.Fogged(map);

            List<Thing> things = new();

            things.Add(ThingMaker.MakeThing(ThingDefOf.Sandstone));


            bool result = FilterUtils.NotFogged(foggedCell, map);

            Assert.False(result);
        }

        [Fact]
        public void NotFogged_WhenCellIsNotFogged_ReturnsTrue()
        {
            var unfoggedCell = new IntVec3(1, 0, 1);
            var map = new Map();

            bool result = FilterUtils.NotFogged(unfoggedCell, map);

            Assert.True(result);
        }
    }
}
