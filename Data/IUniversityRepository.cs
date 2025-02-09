namespace GalAmrani;

/// Defines the contract for a university repository.
public interface IUniversityRepository : IDisposable, IGraduatable
{
    void AddPerson(Person person);

    void RemovePerson(string id);

    Person? FindPerson(string id);

    void DisplayAllPeople();

    bool ContainsId(string id);

}
