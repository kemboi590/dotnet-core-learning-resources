using DataAnnotation.Models;
using DataAnnotation.Models.one_many;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnnotation
{
    public class CascadeBehaviour
    {
        public static void Run()
        {
            try
            {
                var context = new EFCoreDbContext();

                //create two orders with two orderItems
                var order1 = new Order
                {
                    OrderNumber = "ORDOO1",
                    OrderDate = DateTime.Now,
                    OrderItems = new List<OrderItem>
                    {
                        new OrderItem {ProductName = "Product A"},
                        new OrderItem {ProductName = "Product B"}
                    }
                };

                //second order
                var order2 = new Order
                {
                    OrderNumber = "ORDOO2",
                    OrderDate = DateTime.Now,
                    OrderItems = new List<OrderItem>
                    {
                        new OrderItem {ProductName = "Product C"},
                        new OrderItem {ProductName = "Product D"}
                    }
                };

                //add the order items in the context
                context.Orders.Add(order1);
                context.Orders.Add(order2);

                //save the changes to the db
                context.SaveChanges();

                //confirmation
                Console.WriteLine("Two orders have been created");
                Console.WriteLine($"Order 1: {order1.OrderNumber} with {order1.OrderItems.Count} items.");
                Console.WriteLine($"Order 2: {order2.OrderNumber} with {order2.OrderItems.Count} items.");


                //retrive the orders from the database
                var orders = context.Orders
                    .Include(ord => ord.OrderItems) //Eager loading
                    .ToList();

                Console.WriteLine("\n Fetching all orders and orderItems");

                foreach (var order in orders)
                {
                    Console.WriteLine($"\n Order ID: {order.Id}, Order Number: {order.OrderNumber}, Order Date: {order.OrderDate}");

                    //the related order items
                    foreach (var item in order.OrderItems)
                    {
                        Console.WriteLine($"\t OrderItem ID: {item.Id}, Product Name: {item.ProductName}");
                    }
                }



                //Delete-Cascade behaviour
                //Order to delete
                var orderToDelete = context.Orders
                    .Include(ord => ord.OrderItems)
                    .FirstOrDefault(o => o.Id == 1);

                if (orderToDelete != null)
                {
                    // Output the order details before deletion
                    Console.WriteLine($"Order to be deleted: {orderToDelete.OrderNumber}");

                    // Output the related order items before deletion
                    foreach (var item in orderToDelete.OrderItems)
                    {
                        Console.WriteLine($"\tOrderItemId: {item.Id}, Product Name: {item.ProductName}");
                    }


                    //Delete the order
                    context.Orders.Remove(orderToDelete);

                    context.SaveChanges();

                    // Output the success message
                    Console.WriteLine($"Order '{orderToDelete.OrderNumber}' and its related items were successfully deleted.");

                }
                else
                {
                    // Output if the order with the specified ID was not found
                    Console.WriteLine("Order not found. No deletion performed.");
                }

                //Verify that the order and related order items are deleted by attempting to retrieve them again
                var deletedOrder = context.Orders.FirstOrDefault(o => o.Id == 1); // Trying to find the deleted order
                if (deletedOrder == null)
                {
                    Console.WriteLine("Order with ID 1 has been deleted from the database.");
                }
                // Verify the related OrderItems are also deleted
                var deletedOrderItems = context.OrderItems.Where(oi => oi.OrderId == 1).ToList();
                if (deletedOrderItems.Count == 0)
                {
                    Console.WriteLine("All related OrderItems for Order ID 1 have been deleted.");
                }
                else
                {
                    Console.WriteLine("Some OrderItems for Order ID 1 are still present, which should not happen with Cascade delete.");
                }



            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the operation
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
