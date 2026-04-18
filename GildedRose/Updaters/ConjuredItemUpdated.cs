namespace GildedRoseKata.Updaters;

public class ConjuredItemUpdater : IItemUpdater
{
    /// <summary>
    /// Conjured items degrade in quality twice as fast as normal items.
    /// </summary>
    /// <param name="item">Conjured Item</param>
    public void Update(Item item)
    {
        item.SellIn--;
        int degradeBy = item.SellIn < 0 ? 4 : 2; // Normal items degrade by 1 before sell in and 2 after sell in

        if (item.Quality > 0)
        {
            item.Quality = item.Quality - degradeBy;
            item.Quality = item.Quality <= 0 ? 0 : item.Quality;
        }
    }
}