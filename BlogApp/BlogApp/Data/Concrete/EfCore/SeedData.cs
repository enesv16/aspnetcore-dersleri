using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.Efcore;

public static class SeedData
{
    public static void TestVerileriniDoldur(IApplicationBuilder app)
    {
        var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

        if (context != null)
        {
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();

            }
            if (!context.Tags.Any())
            {
                context.Tags.AddRange(
                    new Entity.Tag { Text = "web programlama", Url="web-programlama"},
                    new Entity.Tag { Text = "backend" , Url="backend"},
                    new Entity.Tag { Text = "frontend" , Url="frontend"},
                    new Entity.Tag { Text = "php", Url="php" },
                    new Entity.Tag { Text = "fullstack", Url="fullstack" }
                );
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User { UserName = "enesvardar" },
                    new User { UserName = "dilarasm" }
                );
                context.SaveChanges();
            }
            if (!context.Posts.Any())
            {
                context.Posts.AddRange(
                    new Post
                    {
                        Title = "Asp.net Core",
                        Content = "Asp.net Core dersleri",
                        Url = "aspnet-core",
                        IsActive = true,
                        PublishedOn = DateTime.Now.AddDays(-10),
                        Tags = context.Tags.Take(3).ToList(),
                        Image = "1.jpg",
                        UserId = 1
                    },
                    new Post
                    {
                        Title = "Php Core",
                        Content = "Php Core dersleri",
                        Url = "php-core",
                        IsActive = true,
                        PublishedOn = DateTime.Now.AddDays(-20),
                        Tags = context.Tags.Take(2).ToList(),
                        Image = "2.jpg",
                        UserId = 2
                    },
                    new Post
                    {
                        Title = "Django",
                        Content = "Django dersleri",
                        Url = "django",
                        IsActive = true,
                        PublishedOn = DateTime.Now.AddDays(-5),
                        Tags = context.Tags.Take(4).ToList(),
                        Image = "3.jpg",
                        UserId = 2
                    },
                    new Post
                    {
                        Title = "React",
                        Content = "React dersleri",
                        Url = "react",
                        IsActive = true,
                        PublishedOn = DateTime.Now.AddDays(-30),
                        Tags = context.Tags.Take(4).ToList(),
                        Image = "3.jpg",
                        UserId = 2
                    },
                    new Post
                    {
                        Title = "Angular",
                        Content = "Angular dersleri",
                        Url = "angular",
                        IsActive = true,
                        PublishedOn = DateTime.Now.AddDays(-50),
                        Tags = context.Tags.Take(4).ToList(),
                        Image = "3.jpg",
                        UserId = 2
                    },
                    new Post
                    {
                        Title = "Web Tasarım",
                        Content = "Web Tasarım dersleri",
                        Url = "web-tasarim",
                        IsActive = true,
                        PublishedOn = DateTime.Now.AddDays(-60),
                        Tags = context.Tags.Take(4).ToList(),
                        Image = "3.jpg",
                        UserId = 2
                    }
                );
                context.SaveChanges();
            }
        }
    }
}