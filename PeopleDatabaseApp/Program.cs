
using System;
using PeopleDatabaseLibrary;

var db = new PersonDatabase();

db.AddGeneratedTeachers(5);
db.AddGeneratedStudents(20);

db.Sort();

var total = db.GetTeachers().Count + db.GetStudents().Count;
Console.WriteLine($"Total people: {total} (Teachers: {db.GetTeachers().Count}, Students: {db.GetStudents().Count})");

Console.WriteLine("First 10 people:");
for (int i = 0; i < Math.Min(10, total); i++)
    Console.WriteLine(db[i]);

if (total > 27)
    Console.WriteLine($"Person at index 27: {db[27]}");

if (total > 0)
{
    var first = db[0];
    var (firstName, lastUpper) = first.GetFullName();
    Console.WriteLine($"Tuple GetFullName: {firstName}, {lastUpper}");

    first.Deconstruct(out var fn, out var ln, out var gender);
    Console.WriteLine($"Deconstructed: {fn} {ln}, gender: {gender}");

    var found = db[fn, ln];
    Console.WriteLine($"Found by name indexer: {found}");
}

Console.WriteLine("All people:");
db.PrintToConsole();
