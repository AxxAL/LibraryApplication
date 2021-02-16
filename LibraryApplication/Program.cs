using System;

namespace LibraryApplication {
    class Program {
        static void Main(string[] args) {
            
            if (args.Length > 0) {
                switch (args[0]) {
                    case "-v":
                        Console.Write("LibraryApplication Version 1.0\n");
                        break;
                    case "-h":
                        Console.Write("Run the application without arguments to start the app.\n-v Displays application version.\n");
                        break;
                    default:
                        Console.Write("Use -h to see syntax.\n");
                        break;
                }
            } // Arguments to run application.

            if (args.Length == 0) {
                var application = new Application(); // Creates new instance of application.
                application.run(); // Runs the newly created instance.
            } // Standard run.

            Console.Read(); // Pauses the program after application exits.
        } // Program entrypoint.
    }
}