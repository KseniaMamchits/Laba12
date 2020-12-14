using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    public partial class Student
    {
        private string surname;
        private string name;
        private string adress;
        public string Surname { get { return this.surname; } set { this.surname = value; } }
        public string Name { get { return this.name; } set { this.name = value; } }
        public string Adress { get { return this.adress; } set { this.adress = value; } }
        public Student(string Name, string Surname, string Adress)
        {
            name = Name;
            surname = Surname;
            adress = Adress;
        }
    }
    interface IHouse
    {
        void Move();
    }
    abstract class House
    {
        public int agelimit=25;
        public int number;
    }

    class Flat : House, IHouse
    {
        public string street;
        public int num;
        public int flats = 30;
        public string Street{ get { return this.street; } set { this.street = value; } }
        public int Num { get { return this.num; } set { this.num = value; } }
        public Flat() { }
        public Flat(string street, int num)
        {
            this.num = this.num;
            this.street = street;
        }
        public void Move()
        {
            if (num> flats)
            {
                Console.WriteLine("Квартира не может находиться в этом доме");
            }
            else
            {
                Console.WriteLine("Квартира находится в этом доме");
            }
        }
        public override string ToString()
        {
            return $"Количество квартир в этом доме: {flats}";
        }
        public void Show(string s)
        {
            Console.WriteLine(s);
        }
    }

    class Reflector
    {
        public void AllClass(string str) //Всё содержимое класса
        {
            Type type = Type.GetType(str);
            var all = type.GetMembers();//Получаем все члены типа
            StreamWriter write = new StreamWriter(@"C:\users\ksenia\Lab12\1.txt", true);
            write.WriteLine($"Все содержимое класса {type}:");
            foreach (var info in all)
            {
                write.WriteLine(info.MemberType + " - " + info.Name);
            }
            write.WriteLine();
            Console.WriteLine("Информация записана в файл!");
            write.Close();
        }

        public void PublicMethods(string str) // Публичные методы 
        {
            Type type = Type.GetType(str);
            var methods = type.GetMethods(BindingFlags.Instance|BindingFlags.Static|BindingFlags.Public);//получаем методы
            StreamWriter write = new StreamWriter(@"C:\users\ksenia\Lab12\2.txt", true);
            write.WriteLine($"Все публичные методы класса {type}:");
            foreach (var info in methods)
            {
                    write.WriteLine("Method Name - " + info.Name + ". Method Return Type - " + info.ReturnType);
            }
            write.WriteLine();
            Console.WriteLine("Информация записана в файл!");
            write.Close();
        }

        public void FieldsAndProperties(string str) // Информацию о полях и свойствах
        {
            Type type = Type.GetType(str);
            var fields = type.GetFields();//получаем поля
            var properties = type.GetProperties();//получаем свойства 
            StreamWriter write = new StreamWriter(@"C:\users\ksenia\Lab12\3.txt", true);
            write.WriteLine($"Вся информация о полях и свойствах {type}:");
            foreach (var info in fields)
            {
                write.WriteLine("Type - " + info.MemberType + ". Name - " + info.Name);
            }
            foreach (var info in properties)
            {
                write.WriteLine("Type - " + info.MemberType + ". Name - " + info.Name);
            }
            write.WriteLine();
            Console.WriteLine("Информация записана в файл!");
            write.Close();
        }

        public void Interf(string str) // Реализованные интерфейсы
        {
            Type type = Type.GetType(str);
            var interfaces = type.GetInterfaces();//получаем интерфейсы
            StreamWriter write = new StreamWriter(@"C:\users\ksenia\Lab12\4.txt", true);
            write.WriteLine($"Все реализованный классом интерфейсы {type}:");
            foreach (var info in interfaces)
            {
                write.WriteLine("Name - " + info.Name);
            }
            write.WriteLine();
            Console.WriteLine("Информация записана в файл!");
            write.Close();
        }

        public void ParMethod(string str)//по имени класса параметры
        {
            Type type = Type.GetType(str);
            Console.Write("Ввести тип параметра: ");
            string parametrS = Console.ReadLine();
            var methodsP = type.GetMethods();
            Console.WriteLine($"Имена методов, содержащих параметр типа {parametrS}: ");
            foreach (var info in methodsP)
            {
                foreach (var i in info.GetParameters())
                    if (i.ParameterType.Name.ToLower() == parametrS)
                    {
                        Console.WriteLine("Name - " + info.Name);
                    }
            }
        }
        public void ReadMethod(string str, string method)
        {
            Type type = Type.GetType(str);
            StreamReader reading = new StreamReader(@"C:\users\ksenia\Lab12\5.txt");
            string parametrs = reading.ReadLine();
            var Method = type.GetMethod(method);
            object obj = Activator.CreateInstance(type);
            object result = Method.Invoke(obj, new object[] { parametrs });
            Console.WriteLine((result));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Reflector reflector = new Reflector();
            reflector.AllClass("lab12.Flat");
            reflector.PublicMethods("lab12.Flat");
            reflector.FieldsAndProperties("lab12.Flat");
            reflector.Interf("lab12.Flat");
            reflector.ParMethod("lab12.Flat");
            reflector.ReadMethod("lab12.Flat", "Show");

            reflector.AllClass("lab12.Student");
            reflector.PublicMethods("lab12.Student");
            reflector.FieldsAndProperties("lab12.Student");
            reflector.Interf("lab12.Student");
            reflector.ParMethod("lab12.Student");
        }
    }
}


