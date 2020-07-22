using BusinessLogic.Interfaces;

namespace BusinessLogic.Interfaces
{
    public interface IPurchaseItem : IItem
    {
        decimal Quantity { get; set; }
    }
}
