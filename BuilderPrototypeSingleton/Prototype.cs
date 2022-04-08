using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPrototypeSingleton
{
    public interface IPrototype
    {
        IPrototype Clone();
    }

    public class Human: IPrototype
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public byte Age { get; set; }


        public Human() { }

        public Human(Human human)
        {
            Name = new(human.Name);
            Surname = new(human.Surname);
            Age = human.Age;
        }

        public Human(string name, string surname, byte age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }


        public IPrototype Clone() => new Human(this);

        public override string ToString()
            => string.Format("Name: {0}, Surname: {1}, Age: {2}", Name, Surname, Age);
    }
}
