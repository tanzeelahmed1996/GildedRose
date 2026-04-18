using System.Collections.Generic;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests;

public class GildedRoseTests
{

    [Theory]
    [InlineData("Normal Item", 10, 20, 9, 19)]
    [InlineData("Aged Brie", 5, 10, 4, 11)]
    [InlineData("Backstage passes to a TAFKAL80ETC concert", 15, 20, 14, 21)]
    [InlineData("Conjured Mana Cake", 5, 20, 4, 18)]
    [InlineData("Sulfuras, Hand of Ragnaros", 0, 40, 0, 40)]
    public void UpdateQuality_UsesCorrectUpdater(string name, int sellIn, int quality, int expectedSellIn, int expectedQuality)
    {
        List<Item> items =
        [
            new Item { Name = name, SellIn = sellIn, Quality = quality }
        ];

        GildedRose app = new(items);

        app.UpdateQuality();

        Assert.Equal(expectedSellIn, items[0].SellIn);
        Assert.Equal(expectedQuality, items[0].Quality);
    }
    
}
