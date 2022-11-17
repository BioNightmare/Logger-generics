using System;
using System.IO;

namespace Logger_generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person giacomo = new("Giacomo","Bianchi",20);
            Logger(giacomo);
        }
        public static void Logger<T>(T item) where T : class
        {
            var proprieta = item.GetType().GetProperties();
            var nomeItem = item.GetType().Name;
            string percorso = Path.Combine(Environment.CurrentDirectory, $"{nomeItem}.txt");
            if (!File.Exists(percorso))
            {
                foreach (var prop in proprieta)
                {
                    File.AppendAllText(percorso, prop.Name);
                    File.AppendAllText(percorso, " ");
                }
            }
            File.AppendAllText(percorso, "\n");
            foreach (var prop in proprieta)
            {
                File.AppendAllText(percorso, prop.GetValue(item).ToString());
                File.AppendAllText(percorso, " ");
            }
            File.AppendAllText(percorso, "\n");
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Person(string name, string lastName, int age)
        {
            Name = name;
            LastName = lastName;
            Age = age;
        }
    }
}
