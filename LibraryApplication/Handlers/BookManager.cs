using System.Collections.Generic;
using System.Linq;
using LibraryApplication.ObjectClasses;

namespace LibraryApplication.Handlers {
    public class BookManager {
        
        private static BookManager INSTANCE; // Instance of this class.
        private List<Book> books = new List<Book>(); // List containing all books currently in memory.
        
        public static BookManager getManager() {
            if (INSTANCE == null) {
                INSTANCE = new BookManager();
            }
            return INSTANCE;
        } // Singleton. Returns an object of this class
        
        public List<Book> getBookDictionary() {
            return this.books;
        } // Returns book list

        public void clearBookDictionary() {
            this.books.Clear();
        } // Clears the entire book list
        
        public void registerBook(string title, string author, uint pages) {
            this.books.Add(new Book(title, author, pages));
        } // Registers a new book in the book list
        
        public Book getBookByTitle(string query) {
            Book book = null;
            foreach (var b in getBookDictionary()) {
                if (b.Title.Contains(query)) {
                    book = b;
                    break;
                }
            }
            return book;
        } // Queries book list by title and returns the book.
        
        public List<Book> getBookByAuthor(string query) {
            var books = new List<Book>();
            foreach (var b in getBookDictionary().Where(b => b.Author.Contains(query))) {
                books.Add(b);
                break;
            }
            return books;
        } // Queries book list by author and returns the books.
    }
} // Class handles books in memory.