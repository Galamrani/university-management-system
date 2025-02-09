namespace GalAmrani;

/// Factory class for creating command instances based on user actions.
public static class CommandFactory
{
    /// Gets the command corresponding to the given user action.
    public static BaseCommand GetCommand(UserAction action, University university)
    {
        return action switch
        {
            UserAction.Quit => new QuitCommand(),
            UserAction.AddStudent => new AddStudentCommand(university),
            UserAction.AddProfessor => new AddProfessorCommand(university),
            UserAction.EnrollStudent => new EnrollStudentCourseCommand(university),
            UserAction.AssignSubject => new AssignProfessorSubjectCommand(university),
            UserAction.DisplayAllPeople => new DisplayPeopleCommand(university),
            UserAction.GraduateStudents => new GraduateStudentsCommand(university),
            _ => throw new InvalidActionException(action)
        };
    }
}
