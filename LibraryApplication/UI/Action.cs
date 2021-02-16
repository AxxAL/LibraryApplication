using System;
using System.Collections.Generic;
using LibraryApplication.Handlers;
using LibraryApplication.ObjectClasses;

namespace LibraryApplication.UI{
    public class Action {
        private static Library library = Library.getLibrary();
        
        public static void registerABook() {
            Console.Clear();
            Console.Write("You've selected the option to register a book.\n");
            Console.Write("Please enter the title of the book: ");
            string title = Console.ReadLine();
            Console.Write("Please enter the author of the book: ");
            string author = Console.ReadLine();
            Console.Clear();

            if (title.Length == 0 || author.Length == 0) {
                Console.Write("Could not register the book.\n");
                cls();
                return;
            } // Prevents crashing if user did not provide proper details.
            
            library.registerNewBook(title, author);
            Console.Write("You've registered a book! Title: {0} | Author: {01}\n", title, author);
            cls();
        } // Function for registering a book with user input and giving response to user.

        public static void removeBook() {
            Console.Clear();
            listAllBooks();
            Console.Write("Please provide the id of the book you want to remove: ");
            string id = Console.ReadLine();

            if (id.Length == 0) {
                Console.Write("You did not provide a proper ID...\n");
                cls();
                return;
            } // Prevents crashing if user did not provide proper details.

            Book book = library.getBookById(id);

            if (book == null) {
                Console.Write("Could not find that book...\n");
                cls();
                return;
            } // Prevents crashing in case book was not found.

            library.Remove(book);
            Console.Write("You have removed a book from the library!\n");
            cls();
        } // Removes a book from the system.

        public static void searchForBookByTitle() {
            string query;
            
            Console.Clear();
            Console.Write("You've selected the option to search for a book by title.\n");
            Console.Write("Please enter title of the book (case sensitive): ");
            query = Console.ReadLine();

            if (query.Length > 0) {
                
                var book = library.getBookByTitle(query);
                if (book == null) {
                    Console.Write("Couldn't find the book you searched for :\\\n");
                    return;
                }
                Console.Write("Found a book: ID: {0} | Title: {01} | Author: {02} | Available: {03}\n", book.Id, book.Title, book.Author, book.Available);
            }
            cls();
        } // Function for searching for a book by title, returns a message to the user.

        public static void searchForBookByAuthor() {
            Console.Clear();
            Console.Write("You've selected the option to search for a book by author.\n");
            Console.Write("Please enter author of the book (case sensitive): ");
            string query = Console.ReadLine();

            if (query.Length == 0) {
                Console.Write("You did not provide a proper query.\n");
                return;
            }

            List<Book> books = library.getBookByAuthor(query);
                
            if (books == null) { 
                Console.WriteLine("Couldn't find the author you searched for :\\");
                cls();
                return;
            } // Prevents crashing.

            if (books.Count == 0) {
                Console.WriteLine("Couldn't find the author you searched for :\\");
                cls();
                return;
            } // Prevents printing nothing.
            
            foreach (var book in books) {
                Console.Write("Found a book: ID: {0} | Title: {01} | Author: {02} | Available: {03}\n", book.Id, book.Title, book.Author, book.Available);
            }
            cls();
        } // Function for searching for a book by author, returns a message to the user.

        public static void listAllBooks() {
            Console.Clear();
            Console.Write("List of all books in the library. Total amount of books: {0}\n--------------------------------------------------------------------\n", library.Count);
            foreach (var book in library) {
                Console.Write("   ID: {0} | Title: {01} | Author: {02} | Available: {03}\n", book.Id, book.Title, book.Author, book.Available);
            }
            Console.Write("--------------------------------------------------------------------\n");
        } // Prints out a list of all books in library.

        public static void loanBook() {
            Console.Clear();
            listAllBooks();
            Console.Write("Please enter the id of the book you want to loan: ");
            Book book = library.getBookById(Console.ReadLine());

            if (book == null) { 
                Console.Write("Couldn't find the book you searched for :\\\n");
            }
            
            if (book.Available) {
                book.Available = false;
                Console.Write("You successfully loaned: {0}\n", book.Title);
            }
            else {
                Console.Write("That book is not available...\n");
            }
            cls();
        } // Checks if book is available and loans it if it is.

        public static void returnBook() {
            Console.Clear();
            listAllBooks();
            Console.Write("Please enter the id of the book you want to return: ");
            Book book = library.getBookById(Console.ReadLine());
            if (!book.Available) {
                book.Available = true;
                Console.Write("You successfully returned: {0}\n", book.Title);
            }
            else {
                Console.Write("That book is not loaned.\n");
            }
            cls();
        } // Checks if book is loaned and returns it if it is.

        public static void cls() {
            Console.Write("\nPlease press any key to continue...");
            Console.ReadLine();
            Console.Clear();
        } // I use this to let the user take their time to read the messages the application spits at them.
    } // Actions to be used in the Menu class. This is not my proudest class :P
}