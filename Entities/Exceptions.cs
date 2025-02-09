namespace GalAmrani;

public class BaseException : Exception
{
    public BaseException(string message) : base(message) { }
}

public class InvalidActionException : BaseException
{
    public InvalidActionException(UserAction action) : base($"Invalid user action: {action}. Please choose a valid option.") { }
}

public class ValidationException : BaseException
{
    public ValidationException(string message) : base($"Validation errors: {message}. Please try again.") { }
}

public class PersonNotFoundException : BaseException
{
    public PersonNotFoundException(string id) : base($"Person with id: {id} not found. Please try again.") { }
}

public class IdExistException : BaseException
{
    public IdExistException(string id) : base($"A person with id '{id}' already exists. Please use a different ID.") { }
}

public class PersonTypeMismatchException : BaseException
{
    public PersonTypeMismatchException(string id, string expectedType) : base($"The person with ID '{id}' is not of the expected type '{expectedType}'.") { }
}

public class CourseAlreadyEnrolledException : BaseException
{
    public CourseAlreadyEnrolledException(string id, string course) : base($"Student with ID '{id}' is already enrolled in the course '{course}'. Cannot re-enroll.") { }
}

public class SubjectAlreadyAssignedException : BaseException
{
    public SubjectAlreadyAssignedException(string id, string subject) : base($"Professor with ID '{id}' is already assigned to the subject '{subject}'. Cannot reassign.") { }
}




