using System.Diagnostics.Metrics;
using System.Drawing;
using System.Globalization;
using System.Xml.Linq;

namespace G_NET_55_LINQ_01
{
    public class Customer
    {
        public string CustomerID { get; set; }
        public List<Order> Orders { get; set; }
    }

    public class Order
    {
        public DateTime OrderDate { get; set; }
    }
    public class  Product
    {
     
         public string Name { get; set; }
         public string Category { get; set; }
         public decimal Price { get; set; }
         public int UnitsInStock { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            #region  Assignment01LINQ
            var catalog = new List<Product>
        {
            new Product { Name = "Salmon", Category = "Seafood", Price = 12.5m , UnitsInStock=0},
            new Product { Name = "Tuna", Category = "Seafood", Price = 9.8m , UnitsInStock=30 },
            new Product { Name = "Bread", Category = "Bakery", Price = 2.3m , UnitsInStock=1 }
        };
            //1.Get all products from the "Seafood" category , Print each product's name and price.
            var seafoodProducts = catalog.Where(p => p.Category == "Seafood")
                                         .ToList();
            Console.WriteLine("---Seafood Products---");
            foreach (var p in seafoodProducts)
            {
                Console.WriteLine($"{p.Name} - ${p.Price}");
            }

            //-----------------------------------------------------------------

            //2.Get a list of only the product names from ProductList , Print each name

            var ProductList = new List<Product>
        {
            new Product { Name = "Salmon", Category = "Seafood", Price = 12.5m , UnitsInStock = 0},
            new Product { Name = "Tuna", Category = "Seafood", Price = 9.8m , UnitsInStock = 20},
            new Product { Name = "Bread", Category = "Bakery", Price = 2.3m , UnitsInStock=30}

        };
            var productNames = ProductList.Select(p => p.Name)
                                          .ToList();


            Console.WriteLine("--- Product Names ---");
            foreach (var name in productNames)
            {
                Console.WriteLine(name);
            }

            //-----------------------------------------------------------------

            //3.Sort all products by UnitPrice(ascending). Print each product's name and price.
            var sortedProducts = ProductList.OrderBy(p => p.Price)
                                            .ToList();

            Console.WriteLine("--- Products Sorted by Price ---");
            foreach (var p in sortedProducts)
            {
                Console.WriteLine($"{p.Name} - ${p.Price}");
            }

            //-----------------------------------------------------------------


            //4.Get all products where UnitPrice is between 10 and 30
            var filteredProducts = ProductList.Where(p => p.Price >= 10 && p.Price <= 30)
                                              .ToList();
            Console.WriteLine("--- Products with Price between 10 and 30 ---");
            foreach (var p in filteredProducts)
            {
                Console.WriteLine($"{p.Name} - ${p.Price}");
            }

            //-----------------------------------------------------------------


            //5.Get all products that are in stock(UnitsInStock > 0) and belong to the "Condiments" category.
            var condimentsInStock = ProductList.Where(p => p.UnitsInStock > 0 && p.Category == "Condiments")
                                               .ToList();

            Console.WriteLine("--- Condiments In Stock ---");
            foreach (var p in condimentsInStock)
            {
                Console.WriteLine($"{p.Name} - {p.UnitsInStock} units available - ${p.Price}");
            }

            //-----------------------------------------------------------------


            //6.Create a new anonymous type with three properties:  
            //● Name → the product name
            //● Price → the unit price
            //● StockStatus → a string: "Available" if UnitsInStock > 0,otherwise "Out of Stock"
            //● Print the result.

            var productSummary = ProductList
             .Select(p => new
             {
               p.Name,
               p.Price,
               StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
             })
             .ToList();

            Console.WriteLine("--- Product Summary ---");
            foreach (var item in productSummary)
            {
                Console.WriteLine($"{item.Name} - ${item.Price} - {item.StockStatus}");
            }


            //-----------------------------------------------------------------


            //7.Print each product's name along with its position (1-based) in the list. Expected format: 1.Chai, 2.Chang, etc.
            var productsWithIndex = ProductList.Select((p, index) => $"{index + 1}. {p.Name}")
                                                .ToList();
            Console.WriteLine("--- Products with Position ---");
            foreach (var item in productsWithIndex)
            {
                Console.WriteLine(item);
            }

            //-----------------------------------------------------------------


            //8.Sort ProductList by Category ascending, then within each category, sort by UnitPrice descending.
            var sorteddProducts = ProductList.OrderBy(p => p.Category)
                                             .ThenByDescending(p => p.Price)
                                             .ToList();
            Console.WriteLine("--- Products Sorted by Category & Price ---");
            foreach (var p in sorteddProducts)
            {
                Console.WriteLine($"{p.Category} - {p.Name} - ${p.Price}");
            }

            //-----------------------------------------------------------------



            //9.Get all products from the "Beverages" category, sorted by UnitsInStock descending. Print name and stock.
            var beveragesSorted = ProductList.Where(p => p.Category == "Beverages")
                                             .OrderByDescending(p => p.UnitsInStock)
                                             .ToList();
            Console.WriteLine("--- Beverages Sorted by Stock ---");
            foreach (var p in beveragesSorted)
            {
                Console.WriteLine($"{p.Name} - {p.UnitsInStock} units");
            }


            //-----------------------------------------------------------------


            //10.Using QUERY SYNTAX with a compound from clause, list all orders placed in 1997 or later showing CustomerID and OrderDate.
            var Customers = new List<Customer>
        {
            new Customer
            {
                CustomerID = "Mohamed",
                Orders = new List<Order>
                {
                    new Order { OrderDate = new DateTime(1996, 7, 4) },
                    new Order { OrderDate = new DateTime(1997, 8, 25) }
                }
            },
        };
            var ordersQuery =
                from c in Customers
                from o in c.Orders
                where o.OrderDate.Year >= 1997
                select new
                {
                    c.CustomerID,
                    o.OrderDate
                };

            Console.WriteLine("--- Orders from 1997 or later ---");
            foreach (var item in ordersQuery)
            {
                Console.WriteLine($"{item.CustomerID} - {item.OrderDate:d}");
            }

            //-----------------------------------------------------------------

            //11.Show position number alongside ProductName
            var productsWithPosition = ProductList.Select((p, index) => $"{index + 1}. {p.Name}")
                                                 .ToList();
            Console.WriteLine("--- Products with Position ---");
            foreach (var item in productsWithPosition)
            {
                Console.WriteLine(item);
            }


            #endregion
        }
    }
}
