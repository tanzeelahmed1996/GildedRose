using System.Collections.Generic;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests;

public class GildedRoseTests
{
    [Fact]
    public void UpdateQuality_NormalItem_DecreasesQualityByOne()
    {
        List<Item> items =
        [
            new Item { Name = "Normal Item", SellIn = 10, Quality = 20 }
        ];

        GildedRose app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(9, items[0].SellIn);
        Assert.Equal(19, items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_ExpiredNormalItem_DecreasesQualityByTwo()
    {
        List<Item> items =
        [
            new Item { Name = "Normal Item", SellIn = 0, Quality = 20 }
        ];

        GildedRose app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(-1, items[0].SellIn);
        Assert.Equal(18, items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_NormalItem_QualityNeverGoesBelowZero()
    {
        List<Item> items =
        [
            new Item { Name = "Normal Item", SellIn = 5, Quality = 0 }
        ];

        GildedRose app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(4, items[0].SellIn);
        Assert.Equal(0, items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_AgedBrie_IncreasesInQuality()
    {
        List<Item> items =
        [
            new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 }
        ];

        GildedRose app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(4, items[0].SellIn);
        Assert.Equal(11, items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_AgedBrie_DoesNotIncreaseAboveForty()
    {
        List<Item> items =
        [
            new Item { Name = "Aged Brie", SellIn = 5, Quality = 40 }
        ];

        GildedRose app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(4, items[0].SellIn);
        Assert.Equal(40, items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_Sulfuras_NeverChanges()
    {
        List<Item> items =
        [
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 40 }
        ];

        GildedRose app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(0, items[0].SellIn);
        Assert.Equal(40, items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_BackstagePass_QualityIncreasesByOneWhenMoreThanSevenDays()
    {
        List<Item> items =
        [
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 }
        ];

        GildedRose app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(14, items[0].SellIn);
        Assert.Equal(21, items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_BackstagePass_QualityIncreasesByThreeWhenSevenDaysOrLess()
    {
        List<Item> items =
        [
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 7, Quality = 20 }
        ];

        GildedRose app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(6, items[0].SellIn);
        Assert.Equal(23, items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_BackstagePass_QualityIncreasesByFourWhenTwoDaysOrLess()
    {
        List<Item> items =
        [
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 2, Quality = 20 }
        ];

        GildedRose app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(1, items[0].SellIn);
        Assert.Equal(24, items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_BackstagePass_DropsToZeroAfterConcert()
    {
        List<Item> items =
        [
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 }
        ];

        GildedRose app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(-1, items[0].SellIn);
        Assert.Equal(0, items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_ConjuredItem_DecreasesQualityTwiceAsFastAsNormalItem()
    {
        List<Item> items =
        [
            new Item { Name = "Conjured Mana Cake", SellIn = 5, Quality = 20 }
        ];

        GildedRose app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(4, items[0].SellIn);
        Assert.Equal(18, items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_ExpiredConjuredItem_DecreasesQualityTwiceAsFastAsExpiredNormalItem()
    {
        List<Item> items =
        [
            new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 20 }
        ];

        GildedRose app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(-1, items[0].SellIn);
        Assert.Equal(16, items[0].Quality);
    }
}
