using System;

interface ILocation
{
    string Name { get; set; }
    string Country { get; set; }
    void Show();
}

interface IPopulated
{
    int Population { get; set; }
}

interface ICityInfo
{
    bool IsCapital { get; set; }
}

interface IMegapolisInfo
{
    int Skyscrapers { get; set; }
}

class Place : ILocation, IComparable<Place>, ICloneable
{
    public string Name { get; set; }
    public string Country { get; set; }

    public Place(string name = "Невiдоме мiсце", string country = "Невiдома країна")
    {
        Name = name;
        Country = country;
        Console.WriteLine("Викликано конструктор Place");
    }

    public virtual void Show()
    {
        Console.WriteLine($"Мiсце: {Name}, Країна: {Country}");
    }

    public int CompareTo(Place other)
    {
        return Name.CompareTo(other.Name);
    }

    public virtual object Clone()
    {
        return new Place(Name, Country);
    }
}

class Region : Place, IPopulated
{
    public int Population { get; set; }

    public Region(string name, string country, int population)
        : base(name, country)
    {
        Population = population;
        Console.WriteLine("Викликано конструктор Region");
    }

    public override void Show()
    {
        Console.WriteLine($"Область: {Name}, Країна: {Country}, Населення: {Population}");
    }

    public override object Clone()
    {
        return new Region(Name, Country, Population);
    }
}

class City : Region, ICityInfo
{
    public bool IsCapital { get; set; }

    public City(string name, string country, int population, bool isCapital)
        : base(name, country, population)
    {
        IsCapital = isCapital;
        Console.WriteLine("Викликано конструктор City");
    }

    public override void Show()
    {
        Console.WriteLine($"Мiсто: {Name}, Країна: {Country}, Населення: {Population}, Столиця: {(IsCapital ? "Так" : "Нi")}");
    }

    public override object Clone()
    {
        return new City(Name, Country, Population, IsCapital);
    }
}

class Megapolis : City, IMegapolisInfo
{
    public int Skyscrapers { get; set; }

    public Megapolis(string name, string country, int population, bool isCapital, int skyscrapers)
        : base(name, country, population, isCapital)
    {
        Skyscrapers = skyscrapers;
        Console.WriteLine("Викликано конструктор Megapolis");
    }

    public override void Show()
    {
        Console.WriteLine($"Мегаполiс: {Name}, Країна: {Country}, Населення: {Population}, Столиця: {(IsCapital ? "Так" : "Нi")}, Хмарочоси: {Skyscrapers}");
    }

    public override object Clone()
    {
        return new Megapolis(Name, Country, Population, IsCapital, Skyscrapers);
    }
}

class Program
{
    static void Main()
    {
        ILocation[] places = new ILocation[]
        {
            new Place("Парк", "Україна"),
            new Region("Київська область", "Україна", 1800000),
            new City("Київ", "Україна", 2900000, true),
            new Megapolis("Нью-Йорк", "США", 8400000, false, 300)
        };

        Console.WriteLine("\n--- Вивід інформації ---");
        foreach (var place in places)
        {
            place.Show();
        }

        Console.WriteLine("\n--- Клонування прикладу ---");
        var original = new City("Львів", "Україна", 720000, false);
        var clone = (City)original.Clone();
        clone.Show();
    }
}
