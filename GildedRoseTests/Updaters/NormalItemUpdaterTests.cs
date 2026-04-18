using GildedRoseKata;
using GildedRoseKata.Updaters;
using Xunit;

namespace GildedRoseTests.Updaters;

public class NormalItemUpdaterTests
{
    [Theory]
    [InlineData(10, 20, 9, 19)] // Before expiry, quality should decrease by 1
    [InlineData(0, 20, -1, 18)] // After expiry, quality should decrease by 2
    [InlineData(5, 0, 4, 0)] // Quality shouldnt go below 0
    public void Update_UpdatesNormalItemCorrectly(int sellIn, int quality, int expectedSellIn, int expectedQuality)
    {
        Item item = new() { Name = "Normal Item", SellIn = sellIn, Quality = quality };
        NormalItemUpdater updater = new();

        updater.Update(item);

        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }
}