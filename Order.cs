namespace FPExampleApp;
public class Order
{
    public int UnitPrice { get; set; }
    public int Discount { get; set; }

    public void SpecialCustomer(int unitPrice, int discount)
    {
        UnitPrice = unitPrice;
        Discount += discount;
    }
}