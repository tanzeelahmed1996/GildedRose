using GildedRoseKata;
using GildedRoseKata.Updaters;
using Xunit;

namespace GildedRoseTests.Updaters;

public class SulfurasUpdaterTests
{
    [Fact]
    public void Update_DoesNotChangeSulfuras()
    {
        Item item = new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 40 };
        SulfurasItemUpdater updater = new();

        updater.Update(item);

        Assert.Equal(0, item.SellIn);
        Assert.Equal(40, item.Quality);
    }
}