
using System.Globalization;

namespace lab2{

    class MyFormatter{
            public static string FormatUsdPrice(double price){
                var usc = new CultureInfo("en-us");
                return price.ToString("C2", usc);
            }
        }
    public class Fruit
        {
            public string Name { get; set; }
            public bool IsSweet { get; set; }
            public double Price { get; set; }

            public double UsdPrice => Price / UsdCourse.Current;

            public static Fruit Create()
            {
                Random random = new Random();
                string[] names = new string[] { "Apple", "Banana","Cherry", "Durian", "Edelberry", "Grape", "Jackfruit" };

                return new Fruit
                {
                    Name = names[random.Next(names.Length)],
                    IsSweet = random.NextDouble() > 0.5,
                    Price = random.NextDouble() * 10
                };
            }
            public override string ToString()
            {
                return $"Name={Name}, IsSweet={IsSweet}, Price={Price:C2}, USD Price={MyFormatter.FormatUsdPrice(UsdPrice)}";
            }
        }
}
