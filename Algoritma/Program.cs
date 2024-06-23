using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

public class Product
{
    private static int id = 1;
    public int Id { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public int Qty { get; set; }
    public DateTime ExpiredDate { get; set; }

    public Product(string name, float price, int qty, DateTime expiredDate)
    {
        Id = id++;
        Name = name;
        Price = price;
        Qty = qty;
        ExpiredDate = expiredDate;
    }
}

public class Util
{
    private static List<Product> listProduct = new List<Product>();

    public static void AddProduct()
    {
        Console.WriteLine("Enter 'back' for cancel or have a wrong input ");
        
        while (true)
        {
            string nameProduct = "";
            float priceProduct = 0;
            int qtyProduct = 0;
            DateTime expiredDate = DateTime.MinValue;

                Console.Write("Input product name: "); // minimum 3 characters and letters only
                nameProduct = Console.ReadLine();

                if (nameProduct.ToLower() == "back")
                {
                    Console.WriteLine("Canceled.");
                    return;
                }

                if (nameProduct.Length < 3 || !nameProduct.All(char.IsLetter))
                {
                    Console.WriteLine("Item name must be at least 3 characters and letters only. Please try again.");
                    continue;
                }

                if (listProduct.Any(p => p.Name.Equals(nameProduct)))
                {
                    Console.WriteLine("Item already exist. Plase try another name");
                    continue;
                }

        while (true)
        {
            Console.Write("Input product price: Rp.");

            string inputPrice = Console.ReadLine();

            if (inputPrice.ToLower() == "back")
            {
                Console.WriteLine("Canceled.");
                return;
            }

            if (!float.TryParse(inputPrice, out priceProduct) || priceProduct < 100)
            {
                Console.WriteLine("Price must be a number and minimun Rp.100. Please try again");
                continue;
            }

            break;
        }

        while (true)
        {
            Console.Write("Input product quantity: ");

            string quantity = Console.ReadLine();

            if (quantity.ToLower() == "back")
            {
                Console.WriteLine("Canceled");
                return;
            }

            if (!int.TryParse(quantity, out qtyProduct) || qtyProduct < 1)
            {
                Console.WriteLine("Quantity must be a number and minimun 1. Please try again");
                continue;
            }

            break;
        }

        while (true)
        {
            Console.Write("Input product expired date (dd-MM-yyyy HH:mm:ss): ");

            string expired = Console.ReadLine();

            if (expired.ToLower() == "back")
            {
                Console.WriteLine("Canceled");
                return;
            }

            if (!DateTime.TryParseExact(expired, "dd-MM-yyyy HH:mm:ss", CultureInfo.CurrentCulture,
                    DateTimeStyles.None, out expiredDate))
            {
                Console.WriteLine("Invalid date format. Please try again (DD-MM-YYYY HH:MM:SS)");
                continue;
            }

            if (expiredDate <= DateTime.Today)
            {
                Console.WriteLine("Expired date must be at least 1 day of today. Please try again");
                continue;
            }

            break;
        }

        Product product = new Product(nameProduct, priceProduct, qtyProduct, expiredDate);
        listProduct.Add(product);
        Console.WriteLine(
            $"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}, Qty: {product.Qty}, Expired: {product.ExpiredDate}");

        Console.WriteLine("Do you want to add another items? (yes/no)");
        string addItems = Console.ReadLine();
        if (addItems.ToLower() != "yes")
            break;
    }
}

    public static void ListProducts()
    {
        Console.WriteLine("List of all products:");

        foreach (var product in listProduct)
        {
            Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}, Qty: {product.Qty}, Expired: {product.ExpiredDate}");
        }
    }

    public static void UpdateProducts()
    {
        Console.WriteLine("Input product ID or name product to update: ");

        string input = Console.ReadLine();

        var productUpdate = listProduct.FirstOrDefault(p => p.Id.ToString() == input || p.Name.ToLower() == input.ToLower());

        if (productUpdate == null)
        {
            Console.WriteLine("Product not found");
            return;
        }

        Console.WriteLine("Product:");
        Console.WriteLine($"Id: {productUpdate.Id}, Name: {productUpdate.Name}, Price: {productUpdate.Price}, Qty: {productUpdate.Qty}, Expired: {productUpdate.ExpiredDate}");
        
        Console.WriteLine("Update product: ");

        Console.WriteLine("New name: ");
        string newName = Console.ReadLine();
        if (!string.IsNullOrEmpty(newName))
        {
            Console.WriteLine($"Name : {productUpdate.Name}");
            productUpdate.Name = newName;
        }
        else
        {
            Console.WriteLine();
        }

        Console.WriteLine("New price: Rp. ");
        
        string newPrice = Console.ReadLine();

        if (!string.IsNullOrEmpty(newPrice))
        {
            if (float.TryParse(newPrice, out float newPrices) && newPrices >= 100)
            {
                Console.WriteLine($"Price: {productUpdate.Price}");
                productUpdate.Price = newPrices;
                Console.WriteLine("Price updated successfully");
            }
            else
            {
                Console.WriteLine();
            }   
        }

        Console.WriteLine("New quantity: ");
        
        string newQty = Console.ReadLine();

        if (!string.IsNullOrEmpty(newQty))
        {   
            if (int.TryParse(newQty, out int newQtys) && newQtys > 0)
            {
                Console.WriteLine($"Quantity: {productUpdate.Qty}");
                productUpdate.Qty = newQtys;
                Console.WriteLine("Quantity updated successfully");
            }
            else
            {
                Console.WriteLine();
            }
        }

        Console.WriteLine("New expired date: "); // Please make sure format date is (dd-MM-yyyy HH:mm:ss)

        string newExpired = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newExpired) && DateTime.TryParseExact(newExpired, "dd-MM-yyyy HH:mm:ss", CultureInfo.CurrentCulture,
                DateTimeStyles.None, out DateTime newExpiredDate) && newExpiredDate > DateTime.Today)
        {
            Console.WriteLine($"Expired Date: {productUpdate.ExpiredDate}");
            productUpdate.ExpiredDate = newExpiredDate;
        }
        else
        {
            Console.WriteLine();
        }

        Console.WriteLine("New updated product: ");
        Console.WriteLine($"Id: {productUpdate.Id}, Name: {productUpdate.Name}, Price: {productUpdate.Price}, Qty: {productUpdate.Qty}, Expired: {productUpdate.ExpiredDate}");
    }

    public static void DeleteProducts()
    {
        Console.WriteLine("Input product ID or name product to delete: ");

        string input = Console.ReadLine();

        var productDelete = listProduct.FirstOrDefault(p => p.Id.ToString() == input || p.Name.ToLower() == input.ToLower());

        if (productDelete == null)
        {
            Console.WriteLine("Product not found");
            return;
        }

        Console.WriteLine($"Are you sure want to delete the product with ID {productDelete.Id} and Name {productDelete.Name}? (yes/no)");
        string confirmation = Console.ReadLine();

        if (confirmation.ToLower() == "yes")
        {
            listProduct.Remove(productDelete);
            Console.WriteLine("Product deleted successfully");
        }
        else
        {
            Console.WriteLine("Deletion cancelled");
        }
    }

    public static void ExpiredItemSoon()
    {
        Console.WriteLine("Item will be expired in 3 days :");

        var sortedProducts = listProduct.OrderBy(p => p.ExpiredDate);
        int IdExpSn = 1;
        bool expireSoon = false;
        
        foreach (var item in sortedProducts)
        {
            if (item.ExpiredDate > DateTime.Now && item.ExpiredDate <= DateTime.Now.AddDays(3))
            {
                Console.WriteLine(
                    $"Id: {IdExpSn}, Name: {item.Name}, Price: {item.Price}, Qty: {item.Qty}, Expired Date: {item.ExpiredDate.ToString("dd-MM-yyyy HH:mm:ss")}");
                expireSoon = true;
                IdExpSn++;
            }
        }

        if (!expireSoon)
        {
            Console.WriteLine("No item expired soon");
        }
    }
    
    public static void ExpiredItem()
    {
        Console.WriteLine("Expired item :");

        var sortedProducts = listProduct.OrderBy(p => p.ExpiredDate);

        int IdExp = 1;
        bool expired = false;
        
        foreach (var item in sortedProducts)
        {
            if (item.ExpiredDate < DateTime.Now)
            {
                Console.WriteLine($"Id: {IdExp}, Name: {item.Name}, Price: {item.Price}, Qty: {item.Qty}, Expired Date: {item.ExpiredDate.ToString("dd-MM-yyyy HH:mm:ss")}");
                expired = true;
                IdExp++;
            }
        }

        if (!expired)
        {
            Console.WriteLine("No item expired");
        }
    }
}

public class Program
{
    public void Main(String[] args)
    {
        while (true)
        {
            Console.WriteLine("Menu :");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. List of Products");
            Console.WriteLine("3. Update Products");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Expired Item Soon");
            Console.WriteLine("6. Expired Item");
            Console.WriteLine("7. Logout");

            Console.Write("Input a number: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Util.AddProduct();
                    break;
                case "2":
                    Util.ListProducts();
                    break;
                case "3":
                    Util.UpdateProducts();
                    break;
                case "4":
                    Util.DeleteProducts();
                    break;
                case "5":
                    Util.ExpiredItemSoon();
                    break;
                case "6":
                    Util.ExpiredItem();
                    break;
                case "7":
                    Console.WriteLine("Exiting... Have a good day");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please input 1-7.");
                    break;
            }

            Console.WriteLine();
        }
    }

}

