using System;

class Program
{
    static void Main(string[] args)
    {
        // First customer (USA)
        Address address1 = new Address("123 Main St", "Boise", "ID", "USA");
        Customer customer1 = new Customer("John Smith", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "P101", 850.00, 1));
        order1.AddProduct(new Product("Mouse", "P102", 25.00, 2));

        // Second customer (International)
        Address address2 = new Address("45 King Road", "Toronto", "Ontario", "Canada");
        Customer customer2 = new Customer("Emma Brown", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Keyboard", "P201", 75.00, 1));
        order2.AddProduct(new Product("Headphones", "P202", 120.00, 1));
        order2.AddProduct(new Product("USB Cable", "P203", 10.00, 3));

        DisplayOrder(order1);
        Console.WriteLine("-----------------------------------");
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.GetPackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order.GetShippingLabel());

        Console.WriteLine($"Total Cost: ${order.GetTotalCost():F2}");
        Console.WriteLine();
    }
}