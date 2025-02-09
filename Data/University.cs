namespace GalAmrani;

/// Represents a university, managing members through a repository.
public class University : IDisposable
{
    /// The repository used to manage university members, Implements IUniversityRepository.
    private readonly IUniversityRepository _repository;

    public University(IUniversityRepository repository)
    {
        _repository = repository;
    }

    public void AddPerson(Person person)
    {
        _repository.AddPerson(person);
    }

    public Person? FindPerson(string id)
    {
        return _repository.FindPerson(id);
    }

    public void DisplayAllPeople()
    {
        _repository.DisplayAllPeople();
    }

    public bool ContainsId(string id)
    {
        return _repository.ContainsId(id);
    }

    public List<Student> Graduate()
    {
        List<Student> graduatingStudents = _repository.Graduate();

        foreach (Student student in graduatingStudents)
        {
            _repository.RemovePerson(student.Id);
        }

        return graduatingStudents;
    }

    public void Dispose()
    {
        _repository.Dispose();
    }
}
