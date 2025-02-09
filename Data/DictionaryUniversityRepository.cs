namespace GalAmrani;


/// Repository implementation using a dictionary for storing university members. Implements the IUniversityRepository
public class DictionaryUniversityRepository : IUniversityRepository
{
    /// Storage for university members (Persons) using a dictionary.
    private readonly Dictionary<string, Person> _members;

    public DictionaryUniversityRepository()
    {
        _members = new Dictionary<string, Person>();
    }

    public List<Student> Graduate()
    {
        return _members.Values.OfType<Student>().Where(student => student.GPA >= 98).ToList();
    }

    public void AddPerson(Person person)
    {
        _members.Add(person.Id, person);
    }

    public Person? FindPerson(string id)
    {
        if (!ContainsId(id)) return null;
        return _members[id];
    }

    public void RemovePerson(string id)
    {
        _members.Remove(id);
    }

    public void DisplayAllPeople()
    {
        foreach (Person person in _members.Values)
        {
            ConsoleUI.PrintPersonInfo(person.GetInfo());
        }
    }

    public bool ContainsId(string id)
    {
        return _members.ContainsKey(id);
    }

    public void Dispose() { }
}
