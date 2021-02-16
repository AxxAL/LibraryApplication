using System;

namespace LibraryApplication {
    class Program {
        static void Main(string[] args) {
            
            if (args.Length > 0) {
                switch (args[0]) {
                    case "-v":
                        Console.Write("LibraryApplication Version {0}\n", Application.version);
                        break;
                    case "-h":
                        Console.Write("Run the application without arguments to start the app.\n-v Displays application version.\n-h Displays this message.\n");
                        break;
                    default:
                        Console.Write("Use -h to see syntax.\n");
                        break;
                }
            } // Handles startup if arguments are provided,
            
            if (args.Length == 0) {
                var application = new Application(); // Creates new instance of application.
                application.run(); // Runs the newly created instance.
                Console.Write("\nApplication paused. Press any button to exit."); Console.Read(); // Pauses the program after application exits.
            } // Standard startup.
        } // Program entrypoint.
    }
}