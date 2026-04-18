namespace GildedRoseKata.Updaters;

public class BackstagePassesItemUpdater : IItemUpdater
{
    /// <summary>
    /// Backstage passes increase in quality as sell in decreases. Once 7 days or under , quality increases by 3.
    /// Once 2 days or under, they increase by 4. After concert, quality drops to 0.
    /// </summary>
    /// <param name="item">Backstage Passes Item</param>
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