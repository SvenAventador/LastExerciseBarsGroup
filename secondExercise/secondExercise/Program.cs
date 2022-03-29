using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace secondExercise
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Entity> entities = new List<Entity>()
            {
               new Entity { Id = 1, ParentId = 0, Name = "Root entity"},
               new Entity { Id = 2, ParentId = 1, Name = "Child of 1 entity"},
               new Entity { Id = 3, ParentId = 1, Name = "Child of 1 entity"},
               new Entity { Id = 4, ParentId = 2, Name = "Child of 2 entity"},
               new Entity { Id = 5, ParentId = 4, Name = "Child of 4 entity"}
            };

            var dictionary = DictionaryToList(entities);

            foreach(var firstItems in dictionary)
            {
                Console.Write("Key = {0}, ", firstItems.Key);

                foreach(var secondItems in firstItems.Value)
                {

                    if (firstItems.Value.Count > 1)
                    {
                        Console.Write($"Value = List [Entity[Id = {secondItems.Id}]], ");
                    }

                    else
                    {
                        Console.WriteLine($"Value = List [Entity[Id = {secondItems.Id}]]");
                    }

                }

                if(firstItems.Value.Count > 1)
                {
                    Console.WriteLine();
                }

            }

            Console.ReadLine();

        }

        public class Entity
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int ParentId { get; set; }
        }

        public static Dictionary<int, List<Entity>> DictionaryToList(List<Entity> entities)
        {
            var list = entities;
            entities = entities.GroupBy(x => x.ParentId).Select(a => a.OrderBy(x => x.Id).First()).ToList();
            var dictionary = entities.ToDictionary(x => x.ParentId, x => new List<Entity>());

            foreach(var item in list)
            {
                dictionary[item.ParentId].Add(item);
            }

            return dictionary;
        }

    }
}