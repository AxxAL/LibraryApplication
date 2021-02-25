using System;

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
            "8. Exit. (Exit with this option in order to prevent data loss)\n" +
            "------------------------------------------\n"
        }; // Start menu UI
        
        public static void start() {
            bool loop = true;
            while (loop) {
                foreach (var line in startMenu) { Console.Write(line); } // Loops through each line of the menu and prints it.
                Console.Write("Select an option: ");
                string selection = Console.ReadLine();
                switch (selection) {
                    case "1":
                        Action.registerABook();
                        break;
                    case "2":
                        Action.searchForBookByTitle();
                        break;
                    case "3":
                        Action.searchForBookByAuthor();
                        break;
                    case "4":
                        Action.listAllBooks();
                        Action.cls();
                        break;
                    case "5":
                        Action.loanBook();
                        break;
                    case "6":
                        Action.returnBook();
                        break;
                    case "7":
                        Action.removeBook();
                        break;
                    case "8":
                        loop = false;
                        break;
                    default:
                        Console.Clear();
                        Console.Write("\n{0} is not a valid option...", selection);
                        Action.cls();
                        break;
                }
            } // Loops until user chooses to exit.
        } // Print out UI & also lets user interact with application.
    } // Class contains the application UI.
}