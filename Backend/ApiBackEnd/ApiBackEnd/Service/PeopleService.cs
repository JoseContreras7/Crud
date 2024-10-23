using ApiBackEnd.Model;

namespace ApiBackEnd.Service
{
    public class PeopleService : IPeopleService
    {
        private static List<People> ListMemory = new List<People>();
        private static int Id = 1;

        public People Create(People people)
        {
            people.id = Id;
            ListMemory.Add(people);
            Id++; //Increase ID
            return people;
        }

        public void Delete(People people)
        {
            ListMemory.Remove(people);
        }

        public IEnumerable<People> GetPeople(string name)
        {
            return ListMemory.Where(t=> t.nombre.ToLower().Contains(name.ToLower())).ToList();
        }

        public People? GetPeopleId(int id)
        {
            return ListMemory.FirstOrDefault(p => p.id == id);
        }

        public void Update(People people)
        {
            var peopleMemory = ListMemory.FirstOrDefault(p => p.id == people.id);

            if (peopleMemory == null)
            {
                throw new KeyNotFoundException("No se encontro la persona.");
            }

            // update properties
            peopleMemory.nombre = people.nombre;
            peopleMemory.telefono = people.telefono;
            peopleMemory.correo = people.correo;
            peopleMemory.direccion = people.direccion;
            peopleMemory.edad = people.edad;

        }


    }
}
