using System;
using Essential2.Library;

var p1 = new Person { 
    FirstName = "Matt",
    LastName= "Milner",
    Age = 50,
};
var p2 = new Person
{
    FirstName = "Cris",
    LastName = "Bruk",
    Age = 31,
};

int x = 5, y = 7;

Swap(x, y);
Console.WriteLine($"X: {x} Y: {y}");

Swap(p1, p2);
Console.WriteLine($"P1: {p1.FirstName} Y: {p2.FirstName}");

static void Swap(object first, object second) {
    object temp = second;
    second = first;
    first = temp;
}
