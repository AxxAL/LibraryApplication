using LibraryApplication.Handlers;
using LibraryApplication.UI;

namespace LibraryApplication {

    public class Application {
        private bool appStatusAlive { get; set; } // Keeps track of whether or not to keep application alive.
        public const float version = 1.0f; // To keep track of application version.
        private static FileHandler fileHandler = FileHandler.gethandler();
        
        public void run() {
            appStatusAlive = true;
            fileHandler.createSaveFile();
            fileHandler.loadBooks();
            Menu.start();
        } // Method that starts the entire application.

        public void exit() {
            fileHandler.saveBooks();
            appStatusAlive = false;
        } // Method that safely kills the entire application.
    } // Root class of the application.
}