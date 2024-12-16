using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Veterinar
{
    public class Animal
    {
        public string Breed { get; set; }
        public string Species { get; set; }
        public double Weight { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
    public class AnimGenerator
    {
        private static readonly Random r = new Random();
        private static readonly string[] DogBreeds = { "Бульдог", "Лабрадор", "Бігль" };
        private static readonly string[] CatBreeds = { "Сіамский", "Персійський", "Сфінкс" };
        private static readonly string[] RabbitBreeds = { "Толай", "Бельгійський", "Європейський" };
        private static readonly string[] HamsterBreeds = { "Сирійський", "Джунгарський", "Кемпбелла" };
        private static readonly string[] ParrotBreeds = { "Macaw", "Какаду", "Parakeet" };
        private static readonly string[] Species = { "Собака", "Кіт", "Заєць", "Хомяк", "Папуга" };
        private static readonly string[] Names = { "Лев", "Флеш", "Чарлі", "Сімба", "Петро", "Барсік", "Бембі", "Аляска", "Тімі", "Марго", "Ральф", "Пітер", "Нік" };
        private static readonly string[] Colors = { "Чорний", "Білий", "Коричневий", "Рижий", "Сірий" };
        public event EventHandler AllChecked;
        public Animal[] GenerateAnimals(int quantAnims)
        {
            Animal[] animals = new Animal[quantAnims];
            for (int i = 0; i < quantAnims; i++)
            {
                string species = Species[r.Next(Species.Length)];
                string breed = RandBreed(species);
                double weight = RandomWeight(species);
                animals[i] = new Animal
                {
                    Breed = breed,
                    Species = species,
                    Weight = weight,
                    Age = r.Next(1, 15),
                    Name = Names[r.Next(Names.Length)],
                    Color = Colors[r.Next(Colors.Length)]
                };
            }
            return animals;
        }
        private string RandBreed(string species)
        {
            switch (species)
            {
                case "Собака":
                    return DogBreeds[r.Next(DogBreeds.Length)];
                case "Кіт":
                    return CatBreeds[r.Next(CatBreeds.Length)];
                case "Заєць":
                    return RabbitBreeds[r.Next(RabbitBreeds.Length)];
                case "Хомяк":
                    return HamsterBreeds[r.Next(HamsterBreeds.Length)];
                case "Папуга":
                    return ParrotBreeds[r.Next(ParrotBreeds.Length)];
                default:
                    return "Невідомий";
            }
        }

        private double RandomWeight(string species)
        {
            switch (species)
            {
                case "Собака":
                    return Math.Round(r.NextDouble() * (50 - 2) + 2, 2);
                case "Кіт":
                    return Math.Round(r.NextDouble() * (15 - 2) + 2, 2);
                case "Заєць":
                    return Math.Round(r.NextDouble() * (5 - 0.5) + 0.5, 2);
                case "Хомяк":
                    return Math.Round(r.NextDouble() * (0.2 - 0.03) + 0.03, 2);
                case "Папуга":
                    return Math.Round(r.NextDouble() * (1.5 - 0.1) + 0.1, 2);
                default:
                    return 0;
            }
        }
        public void VetVisit(Animal[] animals)
        {
            int totalTime = 0;
            foreach (var animal in animals)
            {
                int visitTime = r.Next(1, 11);
                Console.WriteLine("Оглядаємо тварину: {0}, вид: {1}, порода: {2}, колір: {3}, вік: {4}, вага: {5} кг", animal.Name, animal.Species, animal.Breed, animal.Color, animal.Age, animal.Weight);
                Thread.Sleep(100);
                Console.WriteLine("Час прийому: {0} хвилин\n", visitTime);
                totalTime += visitTime;
            }
            AllAnimalsChecked(totalTime);
        }
        protected virtual void AllAnimalsChecked(int totalTime)
        {
            AllChecked?.Invoke(this, EventArgs.Empty);
            Console.WriteLine("Всі тварини оглянуті за {0} хвилин", totalTime);
        }
    }
}
