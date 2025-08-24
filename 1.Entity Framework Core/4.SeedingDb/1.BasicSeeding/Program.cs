// See https://aka.ms/new-console-template for more information


using DataAnnotation.Models;
using Microsoft.EntityFrameworkCore;

try
{
    var context = new EFCoreDbContext();

    //All countries
    Console.WriteLine("==== COUNTRIES====");
    var countries = context.Countries.ToList();
    foreach (var country in countries)
    {
        Console.WriteLine($"Country ID: {country.CountryId}, Name: {country.CountryName}, Code: {country.CountryCode}");
    }

    //All states
    Console.WriteLine("\n ==== States====");
    var states = context.States
        .Include(s => s.country)
        .ToList();
    foreach (var state in states)
    {
        Console.WriteLine($"State ID: {state.StateId}, Name: {state.StateName}, Country: {state.country.CountryName}");

    }

    //All cities
    Console.WriteLine("\n ==== CITIES====");
    var cities = context.Cities
        .Include(c => c.State)
        .ThenInclude(s  => s.country)
        .ToList();
    foreach (var city in cities)
    {
        Console.WriteLine($"City ID: {city.CityId}, Name: {city.CityName}, State: {city.State.StateName}, Country: {city.State.country.CountryName}");

    }

}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}