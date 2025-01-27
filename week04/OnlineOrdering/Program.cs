using System;

class Program
{
    private static List<Order> _orders = new List<Order>();

    static public void PopulateOrderList()
    {
        Order order1 = new Order("Bob Smith", "123 Test Ave", "Provo", "UT", "USA");

        order1.AddProduct("Wonderful Pistachios In Shell, Sweet Chili Flavored", "B077Y6VP74", 6.64, 3);
        order1.AddProduct("Prophets See around Corners (Hardcover)", "1639932208", 14.68, 2);

        _orders.Add(order1);

        Order order2 = new Order("Mauricio Velez-Koolwont ", "16, Jules Koenig Street", "Port-Louis", "Port Louis", "Mauritius");

        order2.AddProduct("GOOD GOOD No Added Sugar Fruit Jam Variety Pack of 4", "B0C61YPX9B", 27.99, 2);
        order2.AddProduct("Rawlings Official NCAA Air It Out Gametime Football - BYU", "B079K8LXWR", 15.99, 6);
        order2.AddProduct("LLQ 8Pcs Mini Lantern with LED Tealight, Ramadan Lanterns", "B09VKZQ5Y9", 26.99, 2);

        _orders.Add(order2);

    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");
    }
}