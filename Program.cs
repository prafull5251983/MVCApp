using MVCApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using MVCApp.Models;
using Microsoft.Extensions.Options;



//for (int i = 0; i < 4; i++)
//{

//    int n = i + 1;

//    string str = "";
//    for (int r = 0; r < n; r++)
//    {
//        int num = n > 1 & r > 0? r + 1 : n;
//        num = n + r;
//        str = str + " " + num.ToString();

//    }
//    Console.WriteLine(str);

//}



//Console.WriteLine("Is "+ MyViewModel.TotalItem("2","2"));
//Console.WriteLine("Is " + MyViewModel.TotalItem(2, 3));


//Dictionary<string, string> dct = new Dictionary<string, string>();
//dct.Add("Prafull", "100");
//dct.Add("Vipul", "200");


//Hashtable hst =new Hashtable();
//hst.Add("Prafull", "100");
//hst.Add("Vipul", "200");


//foreach (KeyValuePair<string,string> p in dct)
//{
//    Console.WriteLine($"Key : { p.Key } and Value is {p.Value} ");
//}

//foreach (DictionaryEntry p in hst)
//{
//    Console.WriteLine($"Hash Table Key : {p.Key} and Hash Table Value is {p.Value} ");
//}

SealedClass fromTeachaer = SealedClass.GetSingleton();
fromTeachaer.PrintDetails("From Teacher");
//Call the GetInstance static method to get the Singleton Instance
SealedClass fromStudent = SealedClass.GetSingleton();
fromStudent.PrintDetails("From Student");



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.
    AddDbContext<MvcAppContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("con")));
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});

builder.Services.AddSession(opt =>
{
    opt.IdleTimeout = TimeSpan.FromSeconds(5);
    opt.Cookie.HttpOnly = true;
    opt.Cookie.IsEssential = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseMiddleware<CustomMiddleware>();
app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();

app.UseAuthorization();

app.UseSession();

//app.MapRazorPages();
app.MapDefaultControllerRoute();


app.Run();
