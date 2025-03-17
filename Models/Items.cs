using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace MVCApp.Models;



public sealed class SealedClass
{
    private static SealedClass _scls;
    private static int Counter = 0;
    private SealedClass()
    {
        Counter++;
        Console.WriteLine("Counter Value " + Counter.ToString());
    }

    public static SealedClass GetSingleton()
    {
        if (_scls == null)
        {
            _scls = new SealedClass();

        }

        return _scls;
    }
    public void PrintDetails(string message)
    {
        Console.WriteLine(message);
    }
}

public class MyViewModel
{

    public int SelectedItemId { get; set; }
    public IEnumerable<SelectListItem> sitms { get; set; }
    public IEnumerable<Items> Items { get; set; }



    public static bool TotalItem<T>(T a1, T a2)
    {
        return a1.Equals(a2);
    }

}

public class Items
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Price { get; set; }
    public int Price2 { get; set; }
}
public class Shop
{
    public int ShopId { get; set; }
    public string Name { get; set; }
    public string Price { get; set; }
}

[PrimaryKey(nameof(Name), nameof(Price))]
public class CompositePrimaryKey
{
    public int ShopId { get; set; }
    public string Name { get; set; }
    public string Price { get; set; }
}

//[PrimaryKey(nameof(Name), nameof(Price))]
public class CompositePrimaryKey2
{
    [Key]
    public int ShopId { get; set; }
    public string Name { get; set; }
    public string Price { get; set; }
}


// Principal (parent)
public class Blog
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Post> Posts { get; } = new List<Post>(); // Collection navigation containing dependents
}

// Dependent (child)
public class Post
{
    public int Id { get; set; }
    public string PostName { get; set; }
    [ForeignKey("Id")]
    public int? BlogId { get; set; } // Optional foreign key property
    public Blog? Blog { get; set; } // Optional reference navigation to principal
    public ICollection<PostPrice> PostPrices { get; } = new List<PostPrice>(); // Collection navigation containing dependents

}


public class PostPrice
{
    [Key]
    public int Id { get; set; }
    public int Price { get; set; }
    [ForeignKey("Id")]
    public int? PostId { get; set; } // Optional foreign key property
    public Post? Post { get; set; } // Optional reference navigation to principal
}


// ManyToMany
public class ManyToMany1
{
    public int Id { get; set; }
    public string ManyToMany1Name { get; set; } // Optional foreign key property
    public ICollection<ManyToMany2> manyToMany2 { get; } = new List<ManyToMany2>(); // Collection navigation containing dependents
}

// // ManyToMany

public class ManyToMany2
{
    public int Id { get; set; }
    public string ManyToMany2Name { get; set; } // Optional foreign key property
    public ICollection<ManyToMany1> manyToMany1 { get; } = new List<ManyToMany1>(); // Collection navigation containing dependents

}


// Principal (parent)
public class OneToManySHadow
{
    public int Id { get; set; }
    public ICollection<OneToManySHadowForeignKey> oneToManyshadowForeignKey { get; } = new List<OneToManySHadowForeignKey>(); // Collection navigation containing dependents
}

// Dependent (child)
public class OneToManySHadowForeignKey
{
    public int Id { get; set; }
    public Blog OneToManyShadow { get; set; } = null!; // Required reference navigation to principal
}


//public class Department
//{
//    [Key]
//    public int Did { get; set; }
//    public string DeptName { get; set; }
//    public ICollection<Employee> Employee { get; set; }
//    public ICollection<Salary> deptsalary { get; set; }

//}
//public class Employee
//{
//    [Key]
//    public int Empid { get; set; }
//    public string EmpName { get; set; }
//    public int Did { get; set; }
//    [ForeignKey("Did")]
//    public Department Department { get; set; }

//    public ICollection<Salary> empsalary { get; set; }
//}

//public class Salary
//{
//    [Key]
//    public int Salid { get; set; }
//    public int EMpSalary { get; set; }
//    public int Did { get; set; }
//    [ForeignKey("Did")]
//    public Department Department { get; set; }
//    public int Empid { get; set; }
//    [ForeignKey("Empid")]
//    public Employee Employee { get; set; }
//}