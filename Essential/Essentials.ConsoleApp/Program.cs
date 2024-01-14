// See https://aka.ms/new-console-template for more information
using Essential2.Library;

var c = new Customer {
    Id = 7,
    FirstName = "First",
    LastName = "Customer",
    CreateDate = new DateOnly(2023, 1, 17),
};
var c2 = new Customer
{
    Id = 3,
    FirstName = "Second",
    LastName = "Customer",
    CreateDate = new DateOnly(2024, 1, 17),
};

var sorter = new Sorter<Customer>();
var customers = new Customer[] { c, c2 };
sorter.Sort(customers);

foreach (var item in customers)
{
    Console.WriteLine($"Customer {item.FirstName} {item.Id}"); 
}

var mapper = new CustomerToPersonMapper();
// var p = mapper.Map(c);
var p = c.Map<Person>(mapper);
Console.WriteLine(p.FirstName);

string jsonPerson = @"{""Id"":0, 
    ""FirstName"":""Matt"", 
    ""LastName"":""Milner"", 
    ""Age"":50}";

var pj = System.Text.Json.JsonSerializer.Deserialize<Person>(jsonPerson);
Console.WriteLine($"JSON Person: {pj?.FirstName} is {pj?.Age}");

Nullable<DateTime> maybeNull = null;
Console.WriteLine($"Maybe date {maybeNull.GetValueOrDefault()}");

var p1 = new Person
{
    FirstName = "Matt",
    LastName = "Milner",
    Age = 50,
};
var p2 = new Person
{
    FirstName = "Cris",
    LastName = "Bruk",
    Age = 31,
};

int x = 5, y = 7;

Swap<int>(ref x, ref y);
Console.WriteLine($"X: {x} Y: {y}");

Swap<Person>(ref p1, ref p2);
Console.WriteLine($"P1: {p1.FirstName} Y: {p2.FirstName}");

static void Swap<T>(ref T first, ref T second)
{
    T temp = second;
    second = first;
    first = temp;
}
