using ApiBackEnd.Model;

namespace ApiBackEnd.Service
{
    public interface IPeopleService
    {
        People Create(People people);
        IEnumerable<People> GetPeople(string name);
        void Update(People people);
        void Delete(People people);
        People? GetPeopleId(int id);
    }
}
