using System;
using System.Collections.Generic;

// Інтерфейс Телефонного довідника
interface IPhoneBook
{
    void ShowInfo();
    bool MatchesCriteria(string criteria);
}

// Базовий клас: Персона
class Person : IPhoneBook, IComparable<Person>
{
    public string Surname { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }

    public Person(string surname, string address, string phone)
    {
        Surname = surname;
        Address = address;
        PhoneNumber = phone;
    }

    public virtual void ShowInfo()
    {
        Console.WriteLine($"[Персона] {Surname}, {Address}, Тел.: {PhoneNumber}");
    }

    public virtual bool MatchesCriteria(string criteria)
    {
        return Surname.Contains(criteria, StringComparison.OrdinalIgnoreCase);
    }

    public int CompareTo(Person other)
    {
        return Surname.CompareTo(other.Surname);
    }
}

// Похідний клас: Організація
class Organization : IPhoneBook
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public string ContactPerson { get; set; }

    public Organization(string name, string address, string phone, string fax, string contactPerson)
    {
        Name = name;
        Address = address;
        Phone = phone;
        Fax = fax;
        ContactPerson = contactPerson;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"[Організація] {Name}, {Address}, Тел.: {Phone}, Факс: {Fax}, Контакт: {ContactPerson}");
    }

    public bool MatchesCriteria(string criteria)
    {
        return Name.Contains(criteria, StringComparison.OrdinalIgnoreCase) ||
               ContactPerson.Contains(criteria, StringComparison.OrdinalIgnoreCase);
    }
}

// Похідний клас: Друг
class Friend : Person
{
    public DateTime BirthDate { get; set; }

    public Friend(string surname, string address, string phone, DateTime birthDate)
        : base(surname, address, phone)
    {
        BirthDate = birthDate;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"[Друг] {Surname}, {Address}, Тел.: {PhoneNumber}, Дата нар.: {BirthDate.ToShortDateString()}");
    }

    public override bool MatchesCriteria(string criteria)
    {
        return base.MatchesCriteria(criteria) || BirthDate.ToShortDateString().Contains(criteria);
    }
}

class Program
{
    static void Main()
    {
        List<IPhoneBook> phoneBook = new List<IPhoneBook>
        {
            new Person("Іваненко", "Київ, вул. Хрещатик, 1", "+380501234567"),
            new Organization("УкрПошта", "Київ, вул. Сагайдачного, 2", "+380444445566", "+380444445567", "Петренко"),
            new Friend("Петренко", "Львів, вул. Зеленa, 5", "+380673335577", new DateTime(1995, 5, 20))
        };

        Console.WriteLine("Всі записи в довіднику:\n");
        foreach (var entry in phoneBook)
            entry.ShowInfo();

        Console.WriteLine("\nПошук по критерію 'Петренко':\n");
        foreach (var entry in phoneBook)
        {
            if (entry.MatchesCriteria("Петренко"))
                entry.ShowInfo();
        }
    }
}
