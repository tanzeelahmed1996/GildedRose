using GildedRoseKata;
using GildedRoseKata.Updaters;
using Xunit;

namespace GildedRoseTests.Updaters;

public class ConjuredUpdaterTests
{
    [Theory]
    [InlineData(5, 20, 4, 18)] // before expiry, quality should decrease by 2
    [InlineData(0, 20, -1, 16)] // after expiry, quality should decrease by 4
    [InlineData(5, 1, 4, 0)] // quality shouldnt go below 0
    public void Update_UpdatesConjuredItemCorrectly(int sellIn, int quality, int expectedSellIn, int expectedQuality)
    {
        Item item = new() { Name = "Conjured Mana Cake", SellIn = sellIn, Quality = quality };
        ConjuredItemUpdater updater = new();

        updater.Update(item);

        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }
}