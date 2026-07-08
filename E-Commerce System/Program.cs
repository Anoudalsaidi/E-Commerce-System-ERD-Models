using E_Commerce_System.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Identity.Client;
using System.Globalization;

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
        public static void AddCategory()
        {
            Console.WriteLine("Enter category Name:");
            string categoryName = Console.ReadLine();

            Console.WriteLine("Enter category description:");
            string description = Console.ReadLine();

            Console.WriteLine("Enter image Url:");
            string imageUrl = Console.ReadLine();

            Category category = new Category
            {
                categoryName=categoryName,
                description=description,
                imageUrl=imageUrl
            };

            Context.categories.Add(category);
            Context.SaveChanges();
            Console.WriteLine($"category ID : {category.categoryId}");
        }
        //case 3
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

            Product produc = new Product
            {
                productName=productName,
                description=description,
                price=price,
                stockQuantity=stockQuantity,
                imageUrl=imageUrl,
                createdAt=DateTime.Now,
                isAvailable =true
            };
            Context.products.Add(produc);
            Context.SaveChanges();
            Console.WriteLine($"Product ID : {produc.productId}  ");
            //----------------------------

            //assigened product id to category

            //show  All categories
            List<Category> categories = Context.categories.ToList();

            foreach(Category categs in categories)
            {
                Console.WriteLine($"Category ID:{categs.categoryId} | Category Name: {categs.categoryName}");
            }

            // select Category
            Console.WriteLine("Enter selected Category ID: ");
            int userCategory = int.Parse(Console.ReadLine());

            //check input
            Category category = Context.categories.FirstOrDefault(c => c.categoryId == userCategory);

            if(category == null) 
            {
                Console.WriteLine("this ID No match with any Category ");
                return;
            }

            //add product
            Product product = new Product();

            Console.WriteLine("enter product name: ");
            string productname = Console.ReadLine();


            Console.WriteLine("enter product price: ");
            decimal productprice = decimal.Parse(Console.ReadLine());

            //assiged Category
            product.categoryId = category.categoryId;

            Context.products.Add(product);
            Context.SaveChanges();
            Console.WriteLine("product added successfuly");


        }

        //case 4
        public static void PlaceOrder()
        {
            //creat order
            Console.WriteLine("-- User Order --");
            Console.WriteLine("enter shipping Address :");
            string address = Console.ReadLine();

            Console.WriteLine("Enter user ID :");
            int userid = int.Parse(Console.ReadLine());

            //check input 
            User selectuserid = Context.users.FirstOrDefault(u => u.userId == userid);

            if (selectuserid == null)
            {
                Console.WriteLine(" No match with any User ID");
                return;
            }




            Console.WriteLine("select mathed Payment :");
            Console.WriteLine("A- CreditCard");
            Console.WriteLine("B- DebitCard");
            Console.WriteLine("C- PayPal");
            Console.WriteLine("D- Cash");
            string optionpayment = Console.ReadLine();

            Order orderuser = new Order
            {
                userId = userid,
                orderDate = DateTime.Now,
                totalAmount = 0,
                status = "pending",
                shippingAddress = address,
                paymentMethod = optionpayment

            };
            Context.orders.Add(orderuser);
            Context.SaveChanges();
            Console.WriteLine($"Order Added successfully with ID: {orderuser.orderId}");

            //Add multiple products
            decimal totalamount = 0;

            bool addmoreproduct = true;
            while (addmoreproduct == true)
            {
                //inter product ID & Quantity

                Console.WriteLine("Enter product ID :");
                int productid = int.Parse(Console.ReadLine());

                Console.WriteLine("enter Quantity :");
                int quantity = int.Parse(Console.ReadLine());

                //check if available or not
                Product checkproducts = Context.products.FirstOrDefault(p => p.productId == productid);
                
                if (checkproducts == null)
                {
                    Console.WriteLine("no product found");
                    return;
                }

                //check if Quantity enough 
                if (checkproducts.stockQuantity < quantity)
                {
                    Console.WriteLine("Quantity Not Enough ");
                    return;
                }



                //after order add total amount

                totalamount += checkproducts.price * quantity;

                //Decrement stockQuantity on each product

                checkproducts.stockQuantity -= quantity;

                //add order
                OrderDetail userorderdetail = new OrderDetail()
                {
                    orderId = orderuser.orderId,
                    productId = checkproducts.productId,
                    Quantity = quantity,
                    unitPrice = checkproducts.price
                };
                Context.orderDetails.Add(userorderdetail);

                Console.WriteLine("Do you want add more ?? (y/n)");
                string answer = Console.ReadLine();

                if (answer != "y")
                {
                    addmoreproduct = false;

                }
            }

            orderuser.totalAmount = totalamount;
            Context.SaveChanges();
            Console.WriteLine($"Order ID: {orderuser.orderId}");
            Console.WriteLine($"Total Amount : {orderuser.totalAmount}");
            Console.WriteLine(" Order placed successfully");


        }

        //case 4
        public static void ProductReview()
        {
            //Display user & product 
            foreach(User u in Context.users)
            {
                Console.WriteLine("All User Available ");
                Console.WriteLine($"User ID : {u.userId} | User Name : {u.username}");

            }

            foreach(Product p in Context.products)
            {
                Console.WriteLine("All product Avialable ");
                Console.WriteLine($"Product ID : {p.productId} | product Name : {p.productName}");
            }

            //Input user id product id
            Console.WriteLine("Enter user ID :");
            int userid = int.Parse(Console.ReadLine());

            //check input
            User checkuserid = Context.users.FirstOrDefault(u => u.userId == userid);

            if(checkuserid == null)
            {
                Console.WriteLine("No match with this user ID");
                return;
            }


            Console.WriteLine("Enter product ID :");
            int productid = int.Parse(Console.ReadLine());

            //check product
            Product checkproductid = Context.products.FirstOrDefault(p=> p.productId==productid);

            if (checkproductid == null)
            {
                Console.WriteLine("No match with this Product ID");
                return;
            }

            //input Review
            Console.WriteLine("Enter your comment :");
            string usercomment = Console.ReadLine();

            Console.WriteLine("Enter Product Rating ");
            int userrat = int.Parse(Console.ReadLine());

            //check range rating
            if(userrat != 1 - 5)
            {
                Console.WriteLine("Rating out of the Range");
                return;
            }

            Review userreviews = new Review()
            {
                userId=userid,
                productId=productid,
                comment=usercomment,
                rating=userrat,
                reviewDate=DateTime.Now
            };

            Context.reviews.Add(userreviews);
            Context.SaveChanges();
            Console.WriteLine($" User Review added successfully with Review ID : {userreviews.reviewId}");

        }

        //case 5
        public static void UpdateProductPriceandAvailability() { }







        static void Main(string[] args)
        {

            bool flag = false;
            while (flag == false)
            {
                Console.WriteLine("Welcome To E_Commerce_System\n");
                Console.WriteLine("choose an option :");
                Console.WriteLine("1- Register a New User");
                Console.WriteLine("2- Add a New Product to a Category ");
                Console.WriteLine("3- Place an Order ");
                Console.WriteLine("4- Write a Product Review");
                Console.WriteLine("5- Update Product Price and Availability");
                Console.WriteLine("6- Cancel an Order ");
                Console.WriteLine("7- Delete a Review ");
                Console.WriteLine("8- View All Products  ");
                Console.WriteLine("9- Filter Products by Category and Price Range ");
                Console.WriteLine("10- Get Category with All Its Products ");
                Console.WriteLine("11- View Order History with Full Detail ");
                Console.WriteLine("12- Product Summary Report");
                Console.WriteLine("0- Exit");


                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        RegisterNewUser();
                break;
                    case 2:
                        AddCategory();
                        break;
                    case 3:
                        AddNewProducttoCategory();
                        break;
                    case 4:
                        PlaceOrder();
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    case 9:
                        break;
                    case 10:
                        break;
                    case 11:
                        break;
                    case 12:
                        break;
                    case 0:
                        flag = true;
                        break;
                    default:
                        Console.WriteLine("Invalied Input");
                        break;



                }

            



            Console.WriteLine("press any key to Continue...");
            Console.ReadKey();
            Console.Clear();



        }


    } 
    }
}
