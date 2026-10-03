using System;
using System.Collections.Generic;
using System.Linq;

namespace PeopleDatabaseLibrary;

public record Teacher : Person
{
    public Teacher(string firstName, string lastName, DateTime? birthdate, Gender gender = Gender.Unknown)
        : base(firstName, lastName, birthdate, gender)
    {
    }

    public Teacher() : base() { }

    public override string ToString() => $"Teacher: {base.ToString()}";
}

public record Subject
{
    public string Name { get; init; }
    public List<Teacher> Teachers { get; } = new List<Teacher>();

    public Subject(string name)
    {
        Name = name ?? string.Empty;
    }

    public Subject() : this(string.Empty) { }

    public override string ToString() => Name;
}

public record Student : Person
{
    public List<Subject> Subjects { get; } = new List<Subject>();

    public Student(string firstName, string lastName, DateTime? birthdate, Gender gender = Gender.Unknown, IEnumerable<Subject>? subjects = null)
        : base(firstName, lastName, birthdate, gender)
    {
        if (subjects != null)
            Subjects.AddRange(subjects);
    }

    public Student() : base()
    {
    }

    public override string ToString()
        => $"Student: {base.ToString()}, Subjects: [{string.Join(", ", Subjects.Select(s => s.Name))}]";
}
