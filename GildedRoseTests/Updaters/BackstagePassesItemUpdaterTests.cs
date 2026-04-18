using GildedRoseKata;
using GildedRoseKata.Updaters;
using Xunit;

namespace GildedRoseTests.Updaters;

public class BackstagePassesUpdaterTests
{
    [Theory]
    [InlineData(15, 20, 14, 21)] // More than 7 days, quality should increase by 1
    [InlineData(7, 20, 6, 23)] // 7 or fewer days, quality should increase by 2
    [InlineData(2, 20, 1, 24)] // 2 or fewer days, quality should increase by 3
    public void Update_IncreasesQualityBasedOnSellIn(int sellIn, int quality, int expectedSellIn, int expectedQuality)
    {
        Item item = new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality };
        BackstagePassesItemUpdater updater = new();

        updater.Update(item);

        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }

    [Fact]
    public void Update_DropsQualityToZeroAfterConcert()
    {
        Item item = new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 };
        BackstagePassesItemUpdater updater = new();

        updater.Update(item);

        Assert.Equal(-1, item.SellIn);
        Assert.Equal(0, item.Quality);
    }
}