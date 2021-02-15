using System;
using System.IO;

namespace LibraryApplication.Handlers {
    public class FileHandler {

        private BookManager bookManager = BookManager.getManager();
        private static FileHandler INSTANCE;
        
        public static FileHandler gethandler() {
            if (INSTANCE == null) {
                INSTANCE = new FileHandler();
            }
            INSTANCE.createSaveFile();
            return INSTANCE;
        } // Singleton. Returns an object of this class
        
        public void saveBooks() {
            deleteSaveFile();
            using var writeFile = new StreamWriter("books.txt");
            foreach (var book in bookManager.getBookDictionary()) {
                writeFile.WriteLine(book.Title + "|" + book.Author + "|" + book.Pages + "|" + book.Available);
            }
            writeFile.Close();
        } // Copies books from memory to disk.
        
        public void loadBooks() {
            bookManager.clearBookDictionary();
            string s;
            using var readFile = new StreamReader("books.txt");
            while ((s = readFile.ReadLine()) != null) {
                string[] sArr = s.Split("|");
                bookManager.registerBook(sArr[0], sArr[1], UInt32.Parse(sArr[2]));
            }
            readFile.Close();
        } // Loads books into memory.
        
        public void createSaveFile() {
            if (!File.Exists("books.txt")) {
                File.Create("books.txt");
            }
        } // Creates save file if it doesn't exist.

        public void deleteSaveFile() {
            if (!File.Exists("books.txt")) {
                File.Delete("books.txt");
            }
        } // Deletes save file if it exists.
    }
} // Class handles books in save file.