namespace GildedRoseKata.Updaters;

public interface IItemUpdater
{
    /// <summary>
    /// Update the quality and sell in value of an item.
    /// </summary>
    /// <param name="item"></param>
    void Update(Item item);
}