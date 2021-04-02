using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_0326
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("백찬호", 24);

            Console.WriteLine(person.ToString());            

            person = ChangePersonAge(person);

            Console.WriteLine(person.ToString());

            ClassPerson classperson = new ClassPerson("백찬호", 22);

            Console.WriteLine(classperson.ToString());

            ChangePersonAge(classperson);

            Console.WriteLine(classperson.ToString());

            MyInt myint = new MyInt(5);

            Console.WriteLine($"{myint + 10}");

            myint = 50;


        }

        static Person ChangePersonAge(Person person)
        {
            person.AddAge();
            return person;
        }

        static void ChangePersonAge(ClassPerson person)
        {
            person.AddAge();
        }
    }

    class MyInt
    {
        public int Value { get; set; }

        public MyInt(int i) => this.Value = i;

        public static implicit operator MyInt(int i)
        {
            return new MyInt(i);
        }

        public static implicit operator int(MyInt i)
        {
            return i.Value;
        }
    }

    struct Person
    {
        private string Name;
        private int Age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void AddAge() => Age++;

        public string ToString() => $"{Name} {Age}";
    }

    class ClassPerson
    {
        private string Name;
        public int Age;

        public ClassPerson(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void AddAge() => Age++;

        public override string ToString() => $"{Name} {Age}";
    }
}
