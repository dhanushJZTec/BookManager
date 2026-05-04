//using System;
//using System.Collections.Generic;
//using System.Linq;

//class Program
//{
//    static List<Book> books = new List<Book>();

//    static void Main(string[] args)
//    {
//        while (true)
//        {
//            try
//            {
//                Console.WriteLine("\n--- Book Manager ---");
//                Console.WriteLine("1. Add Book");
//                Console.WriteLine("2. Remove Book");
//                Console.WriteLine("3. Search Book");
//                Console.WriteLine("4. Sort Books");
//                Console.WriteLine("5. Display All");
//                Console.WriteLine("0. Exit");

//                Console.Write("Enter choice: ");
//                int choice = Convert.ToInt32(Console.ReadLine());

//                switch (choice)
//                {
//                    case 1:
//                        AddBook();
//                        break;
//                    case 2:
//                        RemoveBook();
//                        break;
//                    case 3:
//                        SearchBook();
//                        break;
//                    case 4:
//                        SortBooks();
//                        break;
//                    case 5:
//                        DisplayBooks();
//                        break;
//                    case 0:
//                        return;
//                    default:
//                        Console.WriteLine("Invalid choice");
//                        break;
//                }
//            }
//            catch (FormatException)
//            {
//                Console.WriteLine("Please enter a valid number!");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(" Unexpected error: " + ex.Message);
//            }
//            finally
//            {
//                Console.WriteLine("Operation completed.\n");
//            }
//        }
//    }

//    static void AddBook()
//    {
//        try
//        {
//            Console.Write("Enter ID: ");
//            int id = Convert.ToInt32(Console.ReadLine());

//            Console.Write("Enter Title: ");
//            string title = Console.ReadLine();

//            Console.Write("Enter Author: ");
//            string author = Console.ReadLine();

//            books.Add(new Book(id, title, author));
//            Console.WriteLine("Book added!");
//        }
//        catch (FormatException)
//        {
//            Console.WriteLine(" ID must be a number!");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine(" Error: " + ex.Message);
//        }
//        finally
//        {
//            Console.WriteLine(" Add operation finished.");
//        }
//    }

//    static void RemoveBook()
//    {
//        try
//        {
//            Console.Write("Enter Book ID to remove: ");
//            int id = Convert.ToInt32(Console.ReadLine());

//            var book = books.FirstOrDefault(b => b.Id == id);

//            if (book != null)
//            {
//                books.Remove(book);
//                Console.WriteLine("Book removed!");
//            }
//            else
//            {
//                Console.WriteLine("Book not found!");
//            }
//        }
//        catch (FormatException)
//        {
//            Console.WriteLine(" Invalid ID format!");
//        }
//        finally
//        {
//            Console.WriteLine(" Remove operation finished.");
//        }
//    }

//    static void SearchBook()
//    {
//        try
//        {
//            Console.Write("Enter title to search: ");
//            string title = Console.ReadLine();

//            var results = books
//                .Where(b => b.Title.ToLower().Contains(title.ToLower()))
//                .ToList();

//            if (results.Any())
//            {
//                foreach (var b in results)
//                {
//                    Console.WriteLine($"{b.Id} - {b.Title} by {b.Author}");
//                }
//            }
//            else
//            {
//                Console.WriteLine(" No books found!");
//            }
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine(" Error: " + ex.Message);
//        }
//        finally
//        {
//            Console.WriteLine(" Search operation finished.");
//        }
//    }

//    static void SortBooks()
//    {
//        try
//        {
//            books = books.OrderBy(b => b.Title).ToList();
//            Console.WriteLine(" Books sorted!");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine(" Error: " + ex.Message);
//        }
//    }

//    static void DisplayBooks()
//    {
//        if (!books.Any())
//        {
//            Console.WriteLine("No books available!");
//            return;
//        }

//        foreach (var b in books)
//        {
//            Console.WriteLine($"{b.Id} - {b.Title} by {b.Author}");
//        }
//    }
//}


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static List<Book> books = new List<Book>();
    static string filePath = "books.json";

    static async Task Main(string[] args)
    {
        await LoadBooksAsync();

        while (true)
        {
            try
            {
                Console.WriteLine("\n--- Book Manager ---");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Remove Book");
                Console.WriteLine("3. Search Book");
                Console.WriteLine("4. Sort Books");
                Console.WriteLine("5. Display All");
                Console.WriteLine("0. Exit");

                Console.Write("Enter choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        await AddBookAsync();
                        break;
                    case 2:
                        await RemoveBookAsync();
                        break;
                    case 3:
                        SearchBook();
                        break;
                    case 4:
                        SortBooks();
                        break;
                    case 5:
                        DisplayBooks();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine(" Enter a valid number!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Error: " + ex.Message);
            }
        }
    }

    
    static async Task LoadBooksAsync()
    {
        try
        {
            if (File.Exists(filePath))
            {
                string json = await File.ReadAllTextAsync(filePath);
                books = JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading books: " + ex.Message);
        }
    }


    static async Task SaveBooksAsync()
    {
        try
        {
            string json = JsonSerializer.Serialize(books, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            await File.WriteAllTextAsync(filePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving books: " + ex.Message);
        }
    }

    static async Task AddBookAsync()
    {
        try
        {
            Console.Write("Enter ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (books.Any(b => b.Id == id))
            {
                Console.WriteLine(" Duplicate ID!");
                return;
            }

            Console.Write("Enter Title: ");
            string title = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Enter Author: ");
            string author = Console.ReadLine()?.Trim() ?? "";

            books.Add(new Book(id, title, author));
            await SaveBooksAsync();

            Console.WriteLine(" Book added!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    
    static async Task RemoveBookAsync()
    {
        try
        {
            Console.Write("Enter Book ID to remove: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var book = books.FirstOrDefault(b => b.Id == id);

            if (book != null)
            {
                books.Remove(book);
                await SaveBooksAsync();
                Console.WriteLine(" Book removed!");
            }
            else
            {
                Console.WriteLine(" Book not found!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    
    static void SearchBook()
    {
        Console.Write("Enter title: ");
        string title = Console.ReadLine()?.Trim() ?? "";

        var results = books
            .Where(b => b.Title.ToLower().Contains(title.ToLower()))
            .ToList();

        if (results.Any())
        {
            foreach (var b in results)
                Console.WriteLine($"{b.Id} - {b.Title} by {b.Author}");
        }
        else
        {
            Console.WriteLine(" No books found!");
        }
    }

    
    static void SortBooks()
    {
        books = books.OrderBy(b => b.Title).ToList();
        Console.WriteLine(" Sorted by title");
    }

    
    static void DisplayBooks()
    {
        if (!books.Any())
        {
            Console.WriteLine("No books available.");
            return;
        }

        foreach (var b in books)
        {
            Console.WriteLine($"{b.Id} - {b.Title} by {b.Author}");
        }
    }
}