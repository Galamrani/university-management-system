namespace GalAmrani;

/// Entry point of the University Management System.
public class Program
{
    /// Main method that initializes and runs the management system.
    static void Main(string[] args)
    {
        // Initialize the university chosen repository
        IUniversityRepository repository = new DictionaryUniversityRepository();

        // Create the university instance using the repository
        University university = new University(repository);

        // Initialize the management system and start execution
        ManagementSystem managementSystem = new ManagementSystem(university);
        managementSystem.Run();
    }
}
