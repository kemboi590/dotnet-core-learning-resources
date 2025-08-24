using EagerLoading.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagerLoading.Loading
{
    public class EagerLoadingInclude
    {
        public static void Run()
        {
            var context = new EFCoreDbContext();
            try
            {
                // Method Syntax with Include (using lambda expression) 
                Console.WriteLine("Method Syntax: Loading Students and their Addresses\n");
                // Eagerly load Student entities along with their related Address entities using method syntax.
                var studentsWithAddressesMethod = context.Students
                    .Include(s => s.Address) // Eager load Address entity using a lambda expression
                    .ToList();



                // Method Syntax with Include (using string parameter)
                // Eagerly load Student entities along with their related Address entities using string-based Include.
                var studentsWithAddressesMethodString = context.Students
                    .Include("Address") // Eager load Address entity using string parameter
                    .ToList();



                // Eager Loading using Query Syntax with Lambda Expression
                var studentsWithAddressesQueryLambda = (from student in context.Students
                                                        .Include(s => s.Address) // Eagerly load Address entity using lambda in query syntax
                                                        select student).ToList();


                // Eager Loading using Query Syntax with String
                var studentsWithAddressesQueryString = (from student in context.Students
                                                        .Include("Address") // Eagerly load Address entity using string in query syntax
                                                        select student).ToList();



                // Display results
                Console.WriteLine(); // Display a new line before displaying the data
                foreach (var student in studentsWithAddressesMethodString)
                {
                    if (student.Address != null)
                    {
                        // Address exists, display the full address details
                        Console.WriteLine($"Student: {student.FirstName} {student.LastName}, Address: {student.Address.Street}, {student.Address.City}, {student.Address.State}");
                    }
                    else
                    {
                        // Address is null, display "No Address"
                        Console.WriteLine($"Student: {student.FirstName} {student.LastName}, Address: No Address");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred while fetching the data. Error: {ex.Message}");
            }

            // Final Output
            Console.WriteLine("Eager loading completed.");


        }
    }
}
