using System.Collections.Generic;
using System.Linq;
using BooksAPI.REST.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksAPI
{
    internal static class BooksInitializer
    {
        private static bool _initialized = false;
        private static object _lock = new object();
        private static List<Author> authors;
        private static List<Book> books;
        private static List<Publisher> publishers;

        public static void Seed(BooksContext context)
        {
            AddPublishers(context);
            AddAuthors(context);
            AddBooks(context);
        }

        internal static void Initialize(BooksContext context)
        {
            if (!_initialized)
            {
                lock (_lock)
                {
                    if (_initialized)
                        return;

                    InitializeData(context);
                }
            }
        }

        private static void AddAuthors(BooksContext context)
        {
            authors = new List<Author>
            {
                new Author
                {
                    Name = "Dan Brown",
                },
                new Author
                {
                    Name = "Robert C. Martin",
                },
                new Author
                {
                    Name = "J.K. Rowling",
                },
                new Author
                {
                    Name = "Jon Krakauer",
                }
            };
            if (!context.Authors.Any())
            {
                context.Authors.AddRange(authors);
                context.SaveChanges();
            }
        }

        private static void AddBooks(BooksContext context)
        {
            var pa = context.Publishers.Single(r => r.Name == "Anchor");
            var pp = context.Publishers.Single(r => r.Name == "Prentice Hall");
            var ps = context.Publishers.Single(r => r.Name == "Scholastic");

            var db = context.Authors.Single(r => r.Name == "Dan Brown");
            var rm = context.Authors.Single(r => r.Name == "Robert C. Martin");
            var jr = context.Authors.Single(r => r.Name == "J.K. Rowling");
            var jk = context.Authors.Single(r => r.Name == "Jon Krakauer");
            books = new List<Book>
            {
                new Book
                {
                    Name = "Into Thin Air",
                    Publisher = pa,
                    Author = jk
                },
                new Book
                {
                    Name = "Into the Wild",
                    Publisher = pa,
                    Author = jk
                },
                new Book
                {
                    Name = "Under the Banner of Heaven: A Story of Violent Faith",
                    Publisher = pa,
                    Author = jk
                },
                new Book
                {
                    Name = "The Lost Symbol",
                    Publisher = pa,
                    Author = db
                },
                new Book
                {
                    Name = "Inferno",
                    Publisher = pa,
                    Author = db
                },
                new Book
                {
                    Name = "The Da Vinci Code",
                    Publisher = pa,
                    Author = db
                },
                new Book
                {
                    Name = "The Clean Coder: A Code of Conduct for Professional Programmers",
                    Publisher = pp,
                    Author = rm
                },
                new Book
                {
                    Name = "Clean Code: A Handbook of Agile Software Craftsmanship",
                    Publisher = pp,
                    Author = rm
                },
                new Book
                {
                    Name = "Clean Architecture: A Craftsman's Guide to Software Structure and Design",
                    Publisher = pp,
                    Author = rm
                },
                new Book
                {
                    Name = "Harry Potter and the Sorcerer's Stone",
                    Publisher = ps,
                    Author = jr
                },
                new Book
                {
                    Name = "Harry Potter And The Chamber Of Secrets",
                    Publisher = ps,
                    Author = jr
                },
                new Book
                {
                    Name = "Harry Potter and the Prisoner of Azkaban",
                    Publisher = ps,
                    Author = jr
                },
                new Book
                {
                    Name = "Harry Potter And The Goblet Of Fire",
                    Publisher = ps,
                    Author = jr
                }
            };

            if (!context.Books.Any())
            {
                context.Books.AddRange(books);
                context.SaveChanges();
            }
        }

        private static void AddPublishers(BooksContext context)
        {
            publishers = new List<Publisher>
            {
                new Publisher
                {
                    Name = "Prentice Hall"
                },
                new Publisher
                {
                    Name = "Anchor"
                },
                new Publisher
                {
                    Name = "Scholastic"
                }
            };
            if (!context.Publishers.Any())
            {
                context.Publishers.AddRange(publishers);
                context.SaveChanges();
            }
        }

        private static void InitializeData(BooksContext context)
        {
            context.Database.Migrate();
            Seed(context);
        }
    }
}