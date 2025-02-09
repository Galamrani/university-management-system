using System.ComponentModel.DataAnnotations;

namespace GalAmrani;

public class Professor : Person
{
    [Range(0.01, double.MaxValue, ErrorMessage = "Salary must be greater than 0.")]
    public decimal Salary { get; set; }
    public List<string> SubjectsTaught { get; private set; } = new();


    public Professor(string id, string name, int age, decimal salary) : base(id, name, age)
    {
        Salary = salary;

        /// Validates all properties including inherited ones from Person.
        /// And throw ValidationException with all the errors if necessary. 
        this.Validate();
    }

    public bool IsTeachingSubject(string subject) => SubjectsTaught.Contains(subject);

    public void AssignSubject(string subject)
    {
        SubjectsTaught.Add(subject);
    }

    public override string GetInfo()
    {
        string subjectsInfo = SubjectsTaught.Count > 0
            ? string.Join(", ", SubjectsTaught)  // Convert list to readable format
            : "No subjects assigned";

        return $"{this.GetType().Name} => {base.GetInfo()}, Salary: {Salary}, Subjects Taught: {subjectsInfo}\n";
    }

}
