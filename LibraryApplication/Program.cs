using System;

namespace LibraryApplication {
    class Program {
        static void Main(string[] args) { 
            
            var application = Application.getApp(); // Creates the application.
            application.run(); // Runs the application.

            Console.Read(); // Pauses the program after application exits.
        } // Program entrypoint.
    }
}