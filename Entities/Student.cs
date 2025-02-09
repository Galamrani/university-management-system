namespace GalAmrani;

public class Student : Person
{
    public Dictionary<string, int> Courses { get; private set; } = new();
    public double GPA => Courses.Count > 0 ? Courses.Values.Average() : 0.0;

    public Student(string id, string name, int age) : base(id, name, age)
    {
        /// Validates all properties including inherited ones from Person.
        /// And throw ValidationException with all the errors if necessary.        
        this.Validate();
    }

    public bool IsEnrolledToCourse(string course) => Courses.ContainsKey(course);

    public void EnrollCourse(string course, int grade)
    {
        Courses[course] = grade;
    }

    public override string GetInfo()
    {
        string coursesInfo = Courses.Count > 0
            ? string.Join(", ", Courses.Select(c => $"{c.Key}: {c.Value}"))  // Convert dictionary to readable format
            : "No courses enrolled";

        return $"{this.GetType().Name} => {base.GetInfo()}, GPA: {GPA}, Courses: {coursesInfo}\n";
    }

}
