using System;
using lab2;
using System.Collections.Generic;
using System.Linq;

namespace lab2
{
    class Program
    {
        static async Task Main(string[] args)
        {
           UsdCourse.Current = await UsdCourse.GetUsdCourseAsync();
           Console.WriteLine(UsdCourse.Current);

            List<Fruit> fruits = new List<Fruit>();

            for (int i = 0; i < 15; i ++){
                 Fruit fruit = Fruit.Create();
                 fruits.Add(fruit);
            }

            Console.WriteLine("Fruit list:");
            fruits = fruits.Where(f => f.IsSweet).OrderByDescending(f => f.Price).ToList();
            foreach (Fruit fruitItem in fruits){
                Console.WriteLine(fruitItem.ToString());
                
            }
            

        }
    }
}
