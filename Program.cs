using System;
using System.Collections.Generic;
using System.ComponentModel;

Console.WriteLine("Hello, World!");

//Prima parte
//Dato lo schema in allegato, producete tutte le classi e le relazioni necessarie per poter utilizzare EntityFramework
//(in modalità code-first) al fine di generare il relativo database.

//Seconda Parte
//Considerando che:
//ci sono clienti che effettuano ordini.
//Un ordine viene preparato da un dipendente.
//Un ordine ha associato uno o più pagamenti (considerando eventuali tentativi falliti)

//Realizzate le seguenti funzionalità
//inserite 10 prodotti all’avvio del programma (i prodotti non devono essere inseriti in caso si riavvi l’applicazione)
//quando l’applicazione si avvia chiede se l’utente è un dipendete o un cliente
//se è un dipendente potrà eseguire CRUD sugli ordini
//se è un cliente potrà acquistare degli ordini
//simulate randomicamente l’esito di un acquisto (status = ok | status = ko)

//Bonus
//Il dipendente deve spedire gli ordini acquistati correttamente.
//modificare il db e l’applicazione in modo che venga gestita questa possibilità.

EcommerceDbContext db = new EcommerceDbContext();

List<Customer>myCustomers = db.Customers.ToList<Customer>();
//List<Customer> customers = db.Customers.OrderBy(customer => customer.Name).ToList<Customer>();


if (myCustomers.Count == 0)
{
    // Create Customers
    Customer sandro = new Customer { Name = "Sandro", Surname = "Ficini", Email = "sandro.duck@honk.it" };
    Customer federica = new Customer { Name = "Federica", Surname = "Elia", Email = "fede.duck@honk.it" };
    Customer cirox = new Customer { Name = "Cirox", Surname = "Cirino", Email = "cirox.duck@honk.it" };
    Customer mistre = new Customer { Name = "Mistre", Surname = "Mistretta", Email = "mistre.duck@honk.it" };

    db.Customers.Add(sandro);
    db.Customers.Add(federica);
    db.Customers.Add(cirox);
    db.Customers.Add(mistre);

    db.SaveChanges();
}

List<Employee> myEmployees = db.Employees.ToList<Employee>();

if (myEmployees.Count == 0)
{
    // Create Employee
    Employee chicco = new Employee { Name = "Chicco", Surname = "Ricco"};

    db.Employees.Add(chicco);

    db.SaveChanges();
}

List<Product> myProducts = db.Products.ToList<Product>();

if (myProducts.Count == 0)
{
    // Create Products
    Product product1 = new Product() { Name = "telefono", Description = "molto bello e funzionale", Price = 699.99f };
    Product product2 = new Product() { Name = "borraccia", Description = "molto bello e funzionale", Price = 9.99f };
    Product product3 = new Product() { Name = "pianta", Description = "molto bello e funzionale", Price = 5.99f };
    Product product4 = new Product() { Name = "duck", Description = "molto bello e funzionale", Price = 19.99f };
    Product product5 = new Product() { Name = "libro", Description = "molto bello e funzionale", Price = 8.99f };
    Product product6 = new Product() { Name = "telefono2", Description = "molto bello e funzionale", Price = 499.99f };
    Product product7 = new Product() { Name = "webcam", Description = "molto bello e funzionale", Price = 19.99f };
    Product product8 = new Product() { Name = "giacca", Description = "molto bello e funzionale", Price = 49.99f };
    Product product9 = new Product() { Name = "monitor", Description = "molto bello e funzionale", Price = 299.99f };
    Product product10 = new Product() { Name = "divano", Description = "molto bello e funzionale", Price = 699.99f };

    db.Products.Add(product1);
    db.Products.Add(product2);
    db.Products.Add(product3);
    db.Products.Add(product4);
    db.Products.Add(product5);
    db.Products.Add(product6);
    db.Products.Add(product7);
    db.Products.Add(product8);
    db.Products.Add(product9);
    db.Products.Add(product10);

    db.SaveChanges();
}

Console.WriteLine("Benvenut nell'ecommerce 'Papere ed Oche'");
Console.WriteLine("Sei un dipendente o un cliente? [1/2]");
int user = Convert.ToInt32(Console.ReadLine());

if (user == 1)
{
    //Si possono eseguire operazioni sugli ordini
    //Read customers
    Console.WriteLine();
    Console.WriteLine("lista utenti: ");
    foreach (Customer customer in myCustomers)
    {
        Console.WriteLine(customer.Name);
    }
    //Read products
    Console.WriteLine();
    Console.WriteLine("lista prodotti: ");
    foreach (Product product in myProducts)
    {
        Console.WriteLine(product.Name);
    }

    //Read orders
    Console.WriteLine();
    Console.WriteLine("lista ordini: ");
    List<Order> myOrders = db.Orders.OrderBy(order => order.Date).ToList<Order>();

    foreach (Order order in myOrders)
    {
        Console.WriteLine("Data: {0}\nQuantità: {1}\nStatus: {2}\nCustomer Id: {3}\nEmployee Id: {4}\nOrder Id: {5}", order.Date, order.Amount, order.Status, order.CustomerId, order.EmployeeId, order.Id);
        Console.WriteLine("--------------------------------");
    }

    //Update
    Console.WriteLine();
    Console.WriteLine("Quale ordine vuoi modificare? Inserire ID");
    int orderId = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    Console.WriteLine("Nuova data ordine");
    DateTime orderDate = DateTime.Parse(Console.ReadLine());

    Console.WriteLine("Nuovo totale ordine");
    int orderAmount = Convert.ToInt32(Console.ReadLine()); 

    Console.WriteLine("Nuovo status");
    int orderStatus = Convert.ToInt32(Console.ReadLine());
    bool boolStatus = Convert.ToBoolean(orderStatus);

    Console.WriteLine("Nuovo customer id");
    int orderCustomerId = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Nuova employee id");
    int orderEmployeeID = Convert.ToInt32(Console.ReadLine());

    foreach (Order order in myOrders)
    {
        if(order.Id == orderId)
        {
            order.Date = orderDate;
            order.Amount = orderAmount;
            order.Status = boolStatus;
            order.CustomerId = orderCustomerId;
            order.EmployeeId = orderEmployeeID;
        }
    }
    db.SaveChanges();
    //Console.WriteLine("update " + order.Date);
}
else if (user == 2)
{
    //READ vengono mostrati i prodotti
    Console.WriteLine("I prodotti presenti nel nostro ecommerce sono: ");
    foreach (Product product in myProducts)
    {
        Console.WriteLine("Nome: {0}\ndescrizione: {1}\nprezzo: {2} euro", product.Name, product.Description, product.Price);
        Console.WriteLine("--------------------------------");
    }
    Console.WriteLine("Vuoi effettuare un ordine? [si/no]");
    string inputOrder = Console.ReadLine();
    if (inputOrder == "si")
    {
        Console.WriteLine("Scrivi quanti prodotti vuoi acquistare:");
        int numberItems = Convert.ToInt32(Console.ReadLine());
        List<String> items = new List<String>();

        for (int i = 0; i < numberItems; i++)
        {
            Console.WriteLine("Scrivi il nome del prodotto:");
            string inputItem = Console.ReadLine();
            items.Add(inputItem);
        }

        Random rnd = new Random();
        Order newOrder = new Order() { Date = DateTime.Today, Amount = numberItems, Status = rnd.Next(2) == 1, CustomerId = 1, EmployeeId = 1 };

        newOrder.Products = new List<Product>();
        foreach (String item in items)
        {
            Product orderedProduct = db.Products.Where(product => product.Name == item).FirstOrDefault();
            newOrder.Products.Add(orderedProduct);
        }

        db.Orders.Add(newOrder);
        db.SaveChanges();
    }
}
else
    Console.WriteLine("Inserire un'opzione valida");


// Delete
//db.Customers.Remove(sandro);
//db.SaveChanges();
//foreach (Customer customer in customers)
//{
//    Console.WriteLine("lista dopo la rimozione " + customer.Name);
//}
