using LibraryApplication.Handlers;
using LibraryApplication.UI;

namespace LibraryApplication {

    public class Application {

        public static bool appStatusAlive { get; set; } // Keeps track of whether or not to keep application alive.
        private FileHandler fileHandler = FileHandler.gethandler();
        private static Application INSTANCE; // Instance of this class.

        public static Application getApp() {
            if (INSTANCE == null) {
                INSTANCE = new Application();
            }
            return INSTANCE;
        } // Singleton. Returns an object of this class

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