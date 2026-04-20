I wrote some unit tests for the varying behaviours and confirm the existing logic works as per the business rules.
I found an issue with the quality exceeding 40, in some places 50 was still being used for the upper limit of quality so I changed that to 40.

I read through the existing logic and used that alongside the brief to consolidate my understanding of the rules. For AgedBrie
I stuck with an increase in qulaity of 1 even after the expiry. I was questioning whether it would increase twice as fast after expiry
but the existing logic had it as one so I kept it as that.

I decided the best way to handle the different logic paths would be to separate the update logic for each item into its own updater class, all 
implementing a common IItemUpdater interface. This would make it easier to maintain as well as improving readibility and testability.

The GildedRose class uses a resolver method to select the appropriate updater based on string matching. 
My preference would have been to have a new property "TypeOfItem" in the Item class which would likely be an enum denoting the type of item but the brief said not to modify this class.

After the refactoring was completed, I moved the tests around and used paramaterised tests to decrease duplication.

If I had a bit more time I would have used an abstract class instead of an interface, as this would help with removing 
duplication of some of the logic when checking the upper and lower limits of quality. I would have also liked to use a factory class to further seperate concerns.
