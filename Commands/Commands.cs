namespace GalAmrani;

/// Command to add a new student to the university.
public class AddStudentCommand : BaseCommand
{
    public AddStudentCommand(University university) : base(university) { }

    public override void Execute()
    {
        string id = ConsoleUI.PromptForId();

        if (_university!.ContainsId(id)) throw new IdExistException(id);

        string name = ConsoleUI.PromptForName();
        int age = ConsoleUI.PromptForAge();

        Student student = new Student(id, name, age);
        _university.AddPerson(student);
    }
}

/// Command to add a new professor to the university.
public class AddProfessorCommand : BaseCommand
{
    public AddProfessorCommand(University university) : base(university) { }

    public override void Execute()
    {
        string id = ConsoleUI.PromptForId();

        if (_university!.ContainsId(id)) throw new IdExistException(id);

        string name = ConsoleUI.PromptForName();
        int age = ConsoleUI.PromptForAge();
        decimal salary = ConsoleUI.PromptForSalary();

        Professor professor = new Professor(id, name, age, salary);
        _university.AddPerson(professor);
    }
}

/// Command to enroll a student in a course.
public class EnrollStudentCourseCommand : BaseCommand
{
    public EnrollStudentCourseCommand(University university) : base(university) { }

    public override void Execute()
    {
        string id = ConsoleUI.PromptForId();
        Person? person = _university!.FindPerson(id);

        if (person == null) throw new PersonNotFoundException(id);
        if (person is not Student student) throw new PersonTypeMismatchException(id, "Student");

        string course = ConsoleUI.PromptForCourse();

        if (student.IsEnrolledToCourse(course)) throw new CourseAlreadyEnrolledException(id, course);

        int grade = ConsoleUI.PromptForCourseGrade();

        student.EnrollCourse(course, grade);
    }
}

/// Command to assign a subject to a professor.
public class AssignProfessorSubjectCommand : BaseCommand
{
    public AssignProfessorSubjectCommand(University university) : base(university) { }

    public override void Execute()
    {
        string id = ConsoleUI.PromptForId();
        Person? person = _university!.FindPerson(id);

        if (person == null) throw new PersonNotFoundException(id);
        if (person is not Professor professor) throw new PersonTypeMismatchException(id, "Professor");

        string subject = ConsoleUI.PromptForSubject();

        if (professor.IsTeachingSubject(subject)) throw new SubjectAlreadyAssignedException(id, subject);

        professor.AssignSubject(subject);
    }
}

/// Command to graduate students who meet the requirements.
public class GraduateStudentsCommand : BaseCommand
{
    public GraduateStudentsCommand(University university) : base(university) { }

    public override void Execute()
    {
        List<Student> graduatedStudents = _university!.Graduate();

        if (graduatedStudents.Count == 0)
        {
            ConsoleUI.PrintNoGraduationMessage();
            return;
        }
        graduatedStudents.ForEach(s => ConsoleUI.PrintGraduationMessage(s));
    }
}

/// Command to display all people in the university.
public class DisplayPeopleCommand : BaseCommand
{
    public DisplayPeopleCommand(University university) : base(university) { }

    public override void Execute()
    {
        _university!.DisplayAllPeople();
    }
}

/// Command to terminate the system execution.
public class QuitCommand : BaseCommand
{
    public QuitCommand() : base() { }

    public override void Execute()
    {
        ConsoleUI.PrintQuitMessage();
    }
}


