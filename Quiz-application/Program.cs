using Microsoft.EntityFrameworkCore;
using Quiz_application.Data;
using Quiz_application.Models.Entities;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConnectionString));

var app = builder.Build();


using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

if (!dbContext.Questions.Any())
{
    var questionAnswer = Guid.NewGuid();
    var question1 = new Question()
    {
        Text = "What is the capital of New Zealand ?",
        Options = new List<Option>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Text = "AuckLand",
            },
            new()
            {
                Id = questionAnswer,
                Text = "WillingTone",
            },
            new()
            {
                Id = Guid.NewGuid(),
                Text = "duckLand",
            },
            new()
            {
                Id = Guid.NewGuid(),
                Text = "lajadjfalckLand",
            },
        },

        CorrectOption = questionAnswer
    };


    var questionTwoAnswer = Guid.NewGuid();
    var question2 = new Question()
    {
        Text = "What is the capital of Bangladesh ?",
        Options = new List<Option>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Text = "Faridpur",
            },
            new()
            {
                Id = Guid.NewGuid(),
                Text = "Chittagong",
            },
            new()
            {
                Id = questionTwoAnswer,
                Text = "Dhaka",
            },
            new()
            {
                Id = Guid.NewGuid(),
                Text = "Rongpur",
            },
        },

        CorrectOption = questionTwoAnswer
    };

    dbContext.Questions.AddRange([question1, question2]);
    dbContext.SaveChanges();
}




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Quiz}/{action=Index}/{id?}");

app.Run();
