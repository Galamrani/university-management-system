namespace GalAmrani;

/// Represents the management system that interacts with the university.
/// Handles user actions and seed data initialization.
public class ManagementSystem : IDisposable
{
    /// The university instance being managed.
    private readonly University _university;


    public ManagementSystem(University university)
    {
        _university = university;
        SeedData();
    }

    /// Runs the management system, prompting the user for actions until quit.
    public void Run()
    {
        ConsoleUI.ClearConsole();
        UserAction action = UserAction.Quit;
        do
        {
            try
            {
                action = ConsoleUI.PromptForUserAction();
                CommandFactory.GetCommand(action, _university).Execute();
            }
            catch (Exception ex)
            {
                ConsoleUI.PrintErrorMessage(ex.Message);
                continue;
            }
        } while (action != UserAction.Quit);
    }

    /// Seeds the university with initial data, including professors and students.
    public void SeedData()
    {
        // Seed Data for Professors
        var professor1 = new Professor("P001", "Dr. John Smith", 45, 75000m);
        professor1.AssignSubject("Mathematics");
        professor1.AssignSubject("Physics");

        var professor2 = new Professor("P002", "Dr. Emily Johnson", 50, 82000m);
        professor2.AssignSubject("Computer Science");
        professor2.AssignSubject("Artificial Intelligence");

        // Seed Data for Students
        var student1 = new Student("S001", "Alice Brown", 20);
        student1.EnrollCourse("Mathematics", 85);
        student1.EnrollCourse("Physics", 90);

        var student2 = new Student("S002", "Bob Williams", 22);
        student2.EnrollCourse("Computer Science", 88);
        student2.EnrollCourse("Artificial Intelligence", 92);

        _university.AddPerson(professor1);
        _university.AddPerson(professor2);
        _university.AddPerson(student1);
        _university.AddPerson(student2);
    }

    /// Releases resources used by the management system.
    public void Dispose()
    {
        _university.Dispose();
    }
}
