using System.Collections.Generic;

namespace LibraryApplication.ObjectClasses {
    public class Library : List<Book> {
        private static Library INSTANCE; // Instance of this class.

        public static Library getLibrary() {
            if (INSTANCE == null) { INSTANCE = new Library(); }
            return INSTANCE;
        } // Singleton. Returns an object of this class

        public void registerBook(string title, string author, uint pages) {
            this.Add(new Book(title, author, pages));
        } // Registers a new book in the library.
        
        public Book getBookByTitle(string query) {
            Book book = null;
            foreach (var b in this) {
                if (b.Title.Contains(query)) {
                    book = b;
                    break;
                }
            }
            return book;
        } // Queries the library by title and returns the book.
        
        public List<Book> getBookByAuthor(string query) {
            var books = new List<Book>();
            foreach (var b in this) {
                if (b.Title.Contains(query)) {
                    books.Add(b);
                }
            }
            return books;
        } // Queries the library by author and returns the books.

        public List<Book> getAllBooks() {
            return this;
        } // Returns a list of all books in memory.
    } // This class inherits from the List class.
}