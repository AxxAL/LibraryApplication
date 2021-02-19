using System;
using System.Collections.Generic;
using LibraryApplication.ObjectClasses;

namespace LibraryApplication.Handlers {
    public class Library : List<Book> {
        private static Library INSTANCE; // Instance of this class.
        
        public static Library getLibrary() {
            if (INSTANCE == null) { INSTANCE = new Library(); }
            return INSTANCE;
        } // Singleton. Returns an object of this class.
        
        public void registerNewBook(string title, string author) {
            
            foreach (var book in this) {
                if (book.Title == title && book.Author == author) { return; }
            } // Checks if book already exists and if it exists the method will not register a new book.

            this.Add(new Book(title, author));
        } // Registers a new book in the library.

        public void registerSavedBook(uint id, string title, string author, bool available) {
            this.Add(new Book(id, title, author, available));
        } // Used to register books that have been stored in save file.

        public Book getBookById(uint query) {
            Book book = null;
            foreach (var b in this) {
                if (b.Id.Equals(query)) {
                    book = b;
                    break;
                }
            }
            return book;
        } // Queries the library by id and returns the book.

        public Book getBookByTitle(string query) {
            Book book = null;
            foreach (var b in this) {
                if (b.Title.Equals(query)) {
                    book = b;
                    break;
                }
            }
            return book;
        } // Queries the library by title and returns the book.

        public List<Book> getBookByAuthor(string query) {
            var books = new List<Book>();
            foreach (var b in this) {
                if (b.Author.Equals(query)) {
                    books.Add(b);
                }
            }
            return books;
        } // Queries the library by author and returns the books.
    } // This class inherits from the List class.
}