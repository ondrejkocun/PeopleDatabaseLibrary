namespace PeopleDatabaseLibrary;

public record Person : IComparable<Person>, IComparable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public DateTime? Birthdate { get; set; }
    public Gender Gender { get; set; }

    public int Age
    {
        get
        {
            var birthday = Birthdate;
            if (!birthday.HasValue)
                return 0;

            var today = DateTime.Today;
            var age = today.Year - birthday.Value.Year;
            if (today.Month < birthday.Value.Month || (today.Month == birthday.Value.Month && today.Day < birthday.Value.Day))
                age--;

            return age;
        }
    }

    public Person(string firstName, string lastName, DateTime? birthday, Gender gender = Gender.Unknown)
        => (FirstName, LastName, Birthdate, Gender) = (firstName, lastName, birthday, gender);

    public Person()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
    }

    public (string firstName, string lastNameUpper) GetFullName()
        => (FirstName, LastName.ToUpper());
    public void Deconstruct(out string firstName, out string lastName, out Gender gender)
    {
        firstName = FirstName;
        lastName = LastName;
        gender = Gender;
    }

    public void Deconstruct(out string firstName, out string lastName, out DateTime? birthdate, out Gender gender, out int age)
    {
        firstName = FirstName;
        lastName = LastName;
        birthdate = Birthdate;
        gender = Gender;
        age = Age;
    }

    public int CompareTo(Person? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (other is null) return 1;

        int result = string.Compare(LastName, other.LastName, StringComparison.OrdinalIgnoreCase);
        if (result != 0) return result;

        result = string.Compare(FirstName, other.FirstName, StringComparison.OrdinalIgnoreCase);
        if (result != 0) return result;

        result = Gender.CompareTo(other.Gender);
        if (result != 0) return result;

        return Nullable.Compare(Birthdate, other.Birthdate);
    }

    int IComparable.CompareTo(object? obj)
    {
        if (obj == null) return 1;
        if (obj is Person other) return CompareTo(other);
        throw new ArgumentException($"Object must be of type {nameof(Person)}");
    }

    public override string ToString() => $"{FirstName} {LastName}, {(Birthdate.HasValue ? Birthdate.Value.ToString("dd.MM.yyyy") : "n/a")}, age: ({Age}), gender: {Gender}";


}