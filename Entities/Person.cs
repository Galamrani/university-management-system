using System.ComponentModel.DataAnnotations;

namespace GalAmrani;

public abstract class Person
{
    [Required(ErrorMessage = "ID is required.")]
    public string Id { get; private set; } = null!;

    [Required(ErrorMessage = "Name is required.")]
    [RegularExpression(@"^[\p{L}\s.'-]{2,50}$", ErrorMessage = "Name can only contain letters, spaces, hyphens (-), apostrophes ('), and dots (.) with 2-50 characters.")]
    public string Name { get; private set; } = null!;

    [Range(16, 120, ErrorMessage = "Age must be between 16 and 120.")]
    public int Age { get; private set; }


    public Person(string id, string name, int age)
    {
        Id = id;
        Name = name;
        Age = age;
    }

    public virtual string GetInfo()
    {
        return $"Id: {Id}, Name: {Name}, Age: {Age}";
    }


    /// <summary>
    /// Validates the properties using data annotations.
    /// When a new Professor for example instance is created, it calls Validate methoed,
    /// which in turn validates all properties including inherited ones from Person.
    /// And throw ValidationException with all the errors if necessary.
    /// </summary>
    protected void Validate()
    {
        var validationContext = new ValidationContext(this);
        var validationResults = new List<ValidationResult>();

        if (!Validator.TryValidateObject(this, validationContext, validationResults, true))
        {
            string errors = string.Join("\n", validationResults.Select(vr => vr.ErrorMessage));
            throw new ValidationException(errors);
        }
    }
}
