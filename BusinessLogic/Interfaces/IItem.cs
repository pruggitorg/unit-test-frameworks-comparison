namespace BusinessLogic.Interfaces
{
    public interface IItem
    {
        string ItemId { get; set; }
        string ItemName { get; set; }
        decimal Price { get; set; }
    }
}