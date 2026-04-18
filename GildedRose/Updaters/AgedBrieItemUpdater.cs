namespace GildedRoseKata.Updaters;

public class AgedBrieItemUpdater : IItemUpdater
{
    /// <summary>
    /// Aged Brie increases in quality the older it gets. Quality can never be more than 40.
    /// </summary>
    /// <param name="item">Aged Brie Item</param>
    public void Update(Item item)
    {
        item.SellIn--;

        if (item.Quality < 40)
        {
            item.Quality++;
        }
    }
}