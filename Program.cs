using System;
using System.Collections.Generic;

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

//Console.WriteLine("Sei un dipendente o un cliente?");
//string user = Console.ReadLine();
//if (user == "dipendente")
//{
//    //si possono eseguire operazioni sugli ordini
//}
//else if (user == "cliente")
//{
//    //si possono acquistare gli ordini
//}
//else
//    Console.WriteLine("Inserire un'opzione valida");


EcommerceDbContext db = new EcommerceDbContext();

List<Customer>myCustomers = db.Customers.ToList<Customer>();

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

// Read
Console.WriteLine();
//List<Customer> customers = db.Customers.OrderBy(customer => customer.Name).ToList<Customer>();
Console.WriteLine("lista utenti: ");
foreach (Customer customer in myCustomers)
{
    Console.WriteLine(customer.Name);
}
Console.WriteLine();
Console.WriteLine("lista prodotti: ");
foreach (Product product in myProducts)
{
    Console.WriteLine(product.Name);
}

// Update
//sandro.Name = "Papera";
//db.SaveChanges();
//Console.WriteLine("update " + sandro.Name);

// Delete
//db.Customers.Remove(sandro);
//db.SaveChanges();
//foreach (Customer customer in customers)
//{
//    Console.WriteLine("lista dopo la rimozione " + customer.Name);
//}