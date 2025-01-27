using System;

public class Customer
{
    private string _customerName;
    private Address _customerAddress;

    public Customer(string customerName, Address customerAddress)
    {
        _customerName = customerName;
        _customerAddress = customerAddress;
    }

    public Customer(string customerName, string streetAddress, string city, string stateOrProvince, string country)
    {
        _customerName = customerName;

        Address customerAddress = new Address(streetAddress, city, stateOrProvince, country);

        _customerAddress = customerAddress;
    }

    public bool DoesCustomerLiveInUnitedStates()
    {
        return _customerAddress.IsAddressInUnitedStates();
    }

    public string GetShippingLabel()
    {
        return $"{_customerName}\n{_customerAddress.GetFormattedAddress()}";
    }
}