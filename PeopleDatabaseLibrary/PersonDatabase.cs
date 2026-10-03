using System;
using System.Collections.Generic;
using System.Linq;

namespace PeopleDatabaseLibrary;

public class PersonDatabase
{
    private readonly List<Person> _people = new List<Person>();

    public void Add(Person person)
    {
        _people.Add(person);
    }

    public void Add(params Person[] people)
    {
        _people.AddRange(people);
    }

    public void AddGeneratedTeachers(int count)
    {
        var people = PersonGenerator.Generate(count);
        foreach (var p in people)
        {
            var t = new Teacher(p.FirstName, p.LastName, p.Birthdate, p.Gender);
            Add(t);
        }
    }

    public void AddGeneratedStudents(int count)
    {
        var people = PersonGenerator.Generate(count);
        if (_subjects.Count == 0)
        {
            var defaultNames = new[] { "Matematika", "Fyzika", "Biologia", "Historia", "Chemia", "Literatura", "Hudba" };
            _subjects.AddRange(defaultNames.Select(n => new Subject(n)));
        }
        foreach (var p in people)
        {
            var s = new Student(p.FirstName, p.LastName, p.Birthdate, p.Gender);
            if (_subjects.Count > 0)
            {
                int subjectCount = _random.Next(1, Math.Min(6, _subjects.Count + 1));
                var chosen = _subjects.OrderBy(_ => _random.Next()).Take(subjectCount);
                s.Subjects.AddRange(chosen);
            }
            Add(s);
        }
    }

    public void Remove(Person person)
    {
        _people.Remove(person);
    }

    public Person this[int index]
    {
        get
        {
            if (index < 0 || index >= _people.Count) throw new ArgumentOutOfRangeException(nameof(index));
            return _people[index];
        }
        set
        {
            if (index < 0 || index >= _people.Count) throw new ArgumentOutOfRangeException(nameof(index));
            _people[index] = value;
        }
    }

    public Person? this[string firstName, string lastName]
    {
        get
        {
            foreach (var person in _people)
            {
                if (string.Equals(person.FirstName, firstName, StringComparison.OrdinalIgnoreCase) && string.Equals(person.LastName, lastName, StringComparison.OrdinalIgnoreCase))
                    return person;
            }

            return null;
        }
    }



    public List<Person> Find(string text, Gender? gender = null)
    {
        var result = new List<Person>();

        foreach (var person in _people)
        {
            if (person.FullName.Contains(text))
            {
                if (gender == null || gender.Value == person.Gender)
                    result.Add(person);
            }
        }

        return result;
    }

    public void Sort()
    {
        _people.Sort();
    }


    public void PrintToConsole()
    {
        foreach (var person in _people)
        {
            Console.WriteLine(person);
        }
    }

    private readonly List<Subject> _subjects = new List<Subject>();
    private static readonly Random _random = new Random();

    public IReadOnlyList<Subject> Subjects => _subjects.AsReadOnly();

    public List<Teacher> GetTeachers() => _people.OfType<Teacher>().ToList();

    public List<Student> GetStudents() => _people.OfType<Student>().ToList();


}
