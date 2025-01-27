using System;

public class Order
{
    private Customer _customer;
    private List<Product> _productList = new List<Product>();

    public double GetTotalOrderCost()
    {
        double totalOrderCost = 0.0;

        foreach (Product product in _productList)
        {
            totalOrderCost += product.GeTotalProductCost();
        }

        return totalOrderCost;
    }
}