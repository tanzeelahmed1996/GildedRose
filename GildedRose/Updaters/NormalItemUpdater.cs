namespace GildedRoseKata.Updaters;

public class NormalItemUpdater : IItemUpdater
{
    /// <summary>
    /// Normal items degrade in quality by 1 each day before the sell by date, and by 2 each day after the sell by date.
    /// </summary>
    /// <param name="item">Normal Item</param>
    public void Update(Item item)
    {
        //Decrease sell in so we have an accurate value to determine how much to degrade by.
        item.SellIn--;
        int degradeBy = item.SellIn < 0 ? 2 : 1;

        // Calculate new quality
        if (item.Quality > 0)
        {
            item.Quality = item.Quality - degradeBy;
            item.Quality = item.Quality <= 0 ? 0 : item.Quality;
        }
    }
}