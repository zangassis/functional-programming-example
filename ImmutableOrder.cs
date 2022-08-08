namespace FPExampleApp;
public class ImmutableOrder
{
    public int UnitPrice { get; }
    public int Discount { get; }

    public ImmutableOrder(int unitPrice, int discount)
    {
        UnitPrice = unitPrice;
        Discount = discount;
    }

    public ImmutableOrder SpecialCustomer(int unitPrice, int discount) 
        => new ImmutableOrder(unitPrice, Discount + discount);
}