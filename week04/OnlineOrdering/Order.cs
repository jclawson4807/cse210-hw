using System;
using System.Security.Cryptography;

public class Order
{
    private Customer _customer;
    private List<Product> _productList = new List<Product>();

    public Order(string customerName, string streetAddress, string city, string stateOrProvince, string country)
    {
        _customer = new Customer(customerName, streetAddress, city, stateOrProvince, country);
    }

    public void AddProduct(string productName, string productId, double price, int quantity)
    {
        Product product = new Product(productName, productId, price, quantity);

        _productList.Add(product);
    }

    private double GetTotalOrderProductCost()
    {
        double totalProductCost = 0.0;

        foreach (Product product in _productList)
        {
            totalProductCost += product.GetTotalProductCost();
        }

        return totalProductCost;
    }
    
    public double GetTotalOrderCost()
    {
        double totalOrderCost = GetTotalOrderProductCost();

        // add shipping cost to the total order cost

        if (_customer.DoesCustomerLiveInUnitedStates())
        {
            // if customer lives in the US, the shipping cost is $5
            totalOrderCost += 5.0;
        }
        else
        {
            // if customer lives outside of the US, the shipping cost is $35
            totalOrderCost += 35.0;
        }

        return totalOrderCost;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "";

        foreach (Product product in _productList)
        {
            packingLabel += product.GetProductLabelInformationForProduct();
        }

        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return _customer.GetShippingLabel();
    }
}