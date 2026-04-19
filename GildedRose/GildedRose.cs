using System.Collections.Generic;
using GildedRoseKata.Updaters;

namespace GildedRoseKata;

public class GildedRose(IList<Item> items)
{
    private const string AGED_BRIE = "Aged Brie";
    private const string BACKSTAGE_PASSES = "Backstage passes to a TAFKAL80ETC concert";
    private const string SULFURAS = "Sulfuras, Hand of Ragnaros";
    private const string CONJURED = "Conjured Mana Cake";
    private readonly IList<Item> _items = items;

    public void UpdateQuality()
    {
        foreach (Item item in _items)
        {
            IItemUpdater updater = GetUpdater(item);
            updater.Update(item);
        }
    }

    private IItemUpdater GetUpdater(Item item)
    {
        return item.Name switch
        {
            AGED_BRIE => new AgedBrieItemUpdater(),
            BACKSTAGE_PASSES => new BackstagePassesItemUpdater(),
            SULFURAS => new SulfurasItemUpdater(),
            CONJURED => new ConjuredItemUpdater(),
            _ => new NormalItemUpdater()
        };
    }
}