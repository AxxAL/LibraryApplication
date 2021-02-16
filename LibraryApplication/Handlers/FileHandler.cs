using System;
using System.IO;
using LibraryApplication.ObjectClasses;

namespace LibraryApplication.Handlers {
    public class FileHandler {
        private static FileHandler INSTANCE;
        private Library library = Library.getLibrary();
        
        public static FileHandler gethandler() {
            if (INSTANCE == null) {
                INSTANCE = new FileHandler();
            }
            INSTANCE.createSaveFile();
            return INSTANCE;
        } // Singleton. Returns an object of this class
        
        public void saveBooks() {
            using var writeFile = new StreamWriter("books.txt");
            foreach (var book in library) {
                writeFile.WriteLine(book.Id + "|" + book.Title + "|" + book.Author + "|" + book.Available);
            }
            writeFile.Close();
            writeFile.Dispose();
        } // Copies books from memory to disk.
        
        public void loadBooks() {
            library.Clear();
            string s;
            using var readFile = new StreamReader("books.txt");
            while ((s = readFile.ReadLine()) != null) {
                string[] sArr = s.Split("|");
                library.registerSavedBook(UInt32.Parse(sArr[0]), sArr[1], sArr[2], Boolean.Parse(sArr[3]));
            }
            readFile.Close();
            readFile.Dispose();
        } // Loads books into memory.
        
        public void createSaveFile() {
            if (!File.Exists("books.txt")) {
                using var write = new StreamWriter("books.txt");
                write.Close();
                write.Dispose();
            }
        } // Creates save file if it doesn't exist.
    }
} // Class handles books in save file.