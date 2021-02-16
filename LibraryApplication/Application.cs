using LibraryApplication.Handlers;
using LibraryApplication.UI;

namespace LibraryApplication {

    public class Application {

        public static bool appStatusAlive { get; set; } // Keeps track of whether or not to keep application alive.
        private static FileHandler fileHandler = FileHandler.gethandler();

        public void run() {
            appStatusAlive = true;
            fileHandler.createSaveFile();
            fileHandler.loadBooks();
            Menu.start();
        } // Method that starts the entire application.

        public static void exit() {
            fileHandler.saveBooks();
            appStatusAlive = false;
        } // Method that safely kills the entire application.
    } // Root class of the application.
}