namespace GildedRoseKata.Updaters;

public class ConjuredItemUpdater : IItemUpdater
{
    public void Update(Item item)
    {
        item.SellIn--;
        int degradeBy = item.SellIn < 0 ? 4 : 2;

        if (item.Quality > 0)
        {
            item.Quality = item.Quality - degradeBy;
            item.Quality = item.Quality <= 0 ? 0 : item.Quality;
        }
    }
}