using GildedRoseKata;
using GildedRoseKata.Updaters;
using Xunit;

namespace GildedRoseTests.Updaters;

public class AgedBrieUpdaterTests
{
    [Theory]
    [InlineData(5, 10, 4, 11)] // Before expiry should increase by 1
    [InlineData(5, 40, 4, 40)] // Quality shouldnt go above 40
    public void Update_UpdatesAgedBrieCorrectly(int sellIn, int quality, int expectedSellIn, int expectedQuality)
    {
        Item item = new() { Name = "Aged Brie", SellIn = sellIn, Quality = quality };
        AgedBrieItemUpdater updater = new();

        updater.Update(item);

        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }
}