namespace LibraryApplication.ObjectClasses {
    
    public class Book {
        
        private struct BookData {
            public string title, author;
            public uint pages;
            public bool available;
        } // Struct for containing the book object's data.
        private BookData _data; // Object to keep & access data.

        public Book(string title, string author, uint pages) {
            this.Title = title;
            this.Author = author;
            this.Pages = pages;
            this.Available = true;
        } // Book constructor creates objects of this class.

        // Getters & Setters
        public string Title {
            get => this._data.title;
            set => this._data.title = value;  
        } // Title getter & setter
        public string Author {
            get => this._data.author;
            set => this._data.author = value;
        } // Author getter & setter
        public uint Pages {
            get => this._data.pages;
            set => this._data.pages = value;
        } // Pages getter & setter 
        public bool Available {
            get => this._data.available;
            set => this._data.available = value;
        } // Availability getter & setter
    } // Class to create book objects for application.
}