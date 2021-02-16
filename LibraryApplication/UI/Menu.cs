using System;
using LibraryApplication.Handlers;
using LibraryApplication.ObjectClasses;

namespace LibraryApplication.UI {
    
    public class Menu {

        private static readonly string[] startMenu = {
            "------------------------------------------\n" +
            "Welcome to Axel's Library Application!\n" +
            "Use the shown characters in order to select a function.\n" +
            "1. Register a book.\n" +
            "2. Search for a book by title.\n" +
            "3. Search for a book by author.\n" +
            "4. List all books.\n" +
            "5. Loan a book.\n" +
            "6. Return a book.\n" +
            "7. Remove book from system.\n" +
            "8. Exit.\n" +
            "------------------------------------------\n"
        }; // Start menu UI
        
        public static void start() {
            while (Application.appStatusAlive) {
                foreach (var line in startMenu) { Console.Write(line); }
                
                Console.Write("Select an option: ");
                var selection = int.Parse(Console.ReadLine());
                switch (selection) {
                    case 1:
                        Option.registerABook();
                        break;
                    case 2:
                        Option.searchForBookByTitle();
                        break;
                    case 3:
                        Option.searchForBookByAuthor();
                        break;
                    case 4:
                        Option.listAllBooks();
                        break;
                    case 8:
                        Application.exit();
                        break;
                    default:
                        Console.Write("\n{0} is not a valid option...", selection);
                        Option.cls();
                        break;
                }
            }
        } // Print out UI & also lets user interact with application.
    } // Class contains the application UI.

    internal class Option {
        
        private static Library library = Library.getLibrary();

        public static void registerABook() {
            string title, author;
            uint pages = 0;

            Console.Clear();
            Console.Write("You've selected the option to register a book.\n");
            Console.Write("Please enter the title of the book: ");
            title = Console.ReadLine();
            Console.Write("Please enter the author of the book: ");
            author = Console.ReadLine();
            Console.Write("Please enter the amount of pages the book has: ");
            pages = UInt32.Parse(Console.ReadLine());
            Console.Clear();

            if (title.Length != 0 && author.Length != 0 && pages != 0) {
                try {
                    library.registerBook(title, author, pages);
                    Console.Write("You've registered a book!  {0}, written by {01}\n\n", title, author);
                }
                catch (Exception e) {
                    Console.Write("Could not register the book...\n" + e.Message);
                    throw;
                }
            }
            cls();
        } // Function for registering a book with user input and giving response to user.

        public static void searchForBookByTitle() {
            string query;
            
            Console.Clear();
            Console.Write("You've selected the option to search for a book by title.\n");
            Console.Write("Please enter title of the book: ");
            query = Console.ReadLine();

            if (query != "") {
                try {
                    var book = library.getBookByTitle(query);
                    Console.Write("Found a book: {0}, written by {01}, Availability: {02}", book.Title, book.Author, book.Available);
                }
                catch (Exception e) {
                    Console.WriteLine("Couldn't find the book you searched for :\\" + e.Message);
                    throw;
                }
            }
            cls();
        } // Function for searching for a book by title, returns a message to the user.

        public static void searchForBookByAuthor() {
            string query;
            
            Console.Clear();
            Console.Write("You've selected the option to search for a book by author.\n");
            Console.Write("Please enter author of the book: ");
            query = Console.ReadLine();

            if (query != "") {
                try {
                    var books = library.getBookByAuthor(query);
                    foreach (var book in books) {
                        Console.Write("Found a book: {0}, written by {01}, Availability: {02}\n", book.Title, book.Author, book.Available);
                    }
                }
                catch (Exception e) {
                    Console.WriteLine("Couldn't find the book you searched for :\\" + e.Message);
                    throw;
                }
            }
            cls();
        } // Function for searching for a book by author, returns a message to the user.

        public static void listAllBooks() {
            Console.Clear();
            Console.Write("List of all books in the library:\n");
            foreach (var book in library) {
                Console.Write("{0}, written by {01}, Available: {02}\n", book.Title, book.Author, book.Available);
            }
            cls();
        } // Prints out a list of all books in library.

        public static void cls() {
            Console.Write("\nPlease press any key to continue...");
            Console.ReadLine();
            Console.Clear();
        } // I use this to let the user take their time to read the messages the application spits at them.
    } // Class to contain the options for the user menu.
}