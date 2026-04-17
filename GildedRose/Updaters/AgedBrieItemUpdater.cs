namespace GildedRoseKata.Updaters;

public class AgedBrieItemUpdater : IItemUpdater
{
    public void Update(Item item)
    {
        item.SellIn--;

        if (item.Quality < 40)
        {
            item.Quality++;
        }
    }
}