namespace GildedRoseKata.Updaters;

public class BackstagePassesItemUpdater : IItemUpdater
{
    public void Update(Item item)
    {
        item.SellIn--;

        if (item.SellIn < 0)
        {
            item.Quality = 0;
            return;
        }

        int upgradeBy = 1;

        if (item.SellIn <= 2)
        {
            upgradeBy = 4;
        }
        else if (item.SellIn <= 7)
        {
            upgradeBy = 3;
        }

        item.Quality = item.Quality + upgradeBy;
        item.Quality = item.Quality >= 40 ? 40 : item.Quality;
        
    }
}