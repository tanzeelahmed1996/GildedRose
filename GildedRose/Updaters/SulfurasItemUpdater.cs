namespace GildedRoseKata.Updaters;

public class SulfurasItemUpdater : IItemUpdater
{
    /// <summary>
    /// Sulfuras' quality does not change and it doesnt have to be sold.
    /// </summary>
    /// <param name="item">Sulfuras Item</param>
    public void Update(Item item)
    {
        // Sulfuras does not change in quality or sell in, so we do nothing here.
    }
}