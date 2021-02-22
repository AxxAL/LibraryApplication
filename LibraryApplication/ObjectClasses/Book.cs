using System;

namespace LibraryApplication.ObjectClasses {
    
    public class Book {
        
        private struct BookData{
            public string title, author;
            public uint id;
            public bool available;
        } // Struct for containing the book object's data.
        private BookData _data; // Object to keep & access data.
        private Random random = new Random(); // For randomising book id.
        
        public Book(string title, string author) {
            this.Id = (uint) random.Next(1, 2000);
            this.Title = title;
            this.Author = author;
            this.Available = true;
        } // Book constructor creates objects of this class.

        public Book(uint id, string title, string author, bool available) {
            this.Id = id;
            this.Title = title;
            this.Author = author;
            this.Available = available;
        } // Book constructor used for loading registered books from save file.

        // Getters & Setters
        public uint Id {
            get => this._data.id;
            set => this._data.id = value;
        } // Id getter & setter
        public string Title {
            get => this._data.title;
            set => this._data.title = value;  
        } // Title getter & setter
        public string Author {
                     get => this._data.author;
                     set => this._data.author = value;
                 } // Author getter & setter
        public bool Available {
            get => this._data.available;
            set => this._data.available = value;
        } // Availability getter & setter
    } // Class to create book objects for application.
}