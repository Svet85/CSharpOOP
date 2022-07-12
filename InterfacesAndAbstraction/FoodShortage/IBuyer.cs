namespace FoodShortage
{
    public interface IBuyer
    {
        int Food { get; set; }
        abstract void BuyFood();

    }
}