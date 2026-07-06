using E_Commerce_System.Models;
using Microsoft.Identity.Client;

namespace E_Commerce_System
{
   public class Program
    {
        //object of Context
        public static E_CommerceContextb Context = new E_CommerceContextb();

        //case 1
        public  static void RegisterNewUser()
        {
            Console.WriteLine("Enter Your Name :");
            string username = Console.ReadLine();

            Console.WriteLine("Enter Your Email :");
            string email = Console.ReadLine();

            Console.WriteLine("Enter Password :");
            string passwordhash = Console.ReadLine();

            Console.WriteLine("Enter Full Name :");
            string fullname = Console.ReadLine();

            Console.WriteLine("Enter phone number :");
            string phonenumber = Console.ReadLine();

            Console.WriteLine("Enter Address :");
            string Address = Console.ReadLine();

          
            User registeruser = new User
            {
                username=username,
                email=email,
                passwordHash=passwordhash,
                fullName=fullname,
                phoneNumber=phonenumber,
                address=Address,
                registrationDate=DateTime.Now,
                isActive=true


            };


            Context.users.Add(registeruser);
            Context.SaveChanges();
            Console.WriteLine($"User ID:{registeruser.userId}");
        }

        //case 2
        public static void AddNewProducttoCategory()
        {
            //add product
            Console.WriteLine("Enter product Name:");
            string productName = Console.ReadLine();


            Console.WriteLine("Enter product description:");
            string description = Console.ReadLine();

            Console.WriteLine("Enter product price:");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter product stock Quantity:");
            int stockQuantity = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter image Url:");
            string imageUrl = Console.ReadLine();

            Product product = new Product
            {
                productName=productName,
                description=description,
                price=price,
                stockQuantity=stockQuantity,
                imageUrl=imageUrl,
                createdAt=DateTime.Now,
                isAvailable =true
            };
            Context.products.Add(product);
            Context.SaveChanges();
            Console.WriteLine($"Product ID : {product.productId}  ");
            //----------------------------



        }












        static void Main(string[] args)
        {

            Console.WriteLine("E_Commerce_System");

           
            
        }
    }
}
