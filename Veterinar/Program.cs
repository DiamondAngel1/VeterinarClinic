using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinar
{
    internal class Program
    {
        static void AllAnimalsChecked(object sender, EventArgs e)
        {
            Console.WriteLine("Всі тварини успішно оглянуті ветеринаром");
        }
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            var generator = new AnimGenerator();
            generator.AllChecked += AllAnimalsChecked;
            Animal[] animals = generator.GenerateAnimals(10);
            generator.VetVisit(animals);
        }
    }
}
