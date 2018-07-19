using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    public class Program
    {
        static void Main(string[] args)
        {
            //PointOfEntry.Run();
            void AnimalCSVToDatabase()
            {
                var output = LoadAnimalCSV();
                ImportCSVDataToDatabase(output);
            }
            string[][] LoadAnimalCSV()
            {
                string path = @"animals.csv";
                string[] csvDataLines = File.ReadAllLines(path);
                var output = File.ReadAllLines(path).Select(x => x.Split(new[] { ',', '"', ' ' }, StringSplitOptions.RemoveEmptyEntries)).AsQueryable<string[]>().ToArray();
                return output;
            }
            void ImportCSVDataToDatabase(string[][] csvOutputData)
            {
                for(int i = 0; i < csvOutputData.Count(); i++)
                {
                    Animal newAnimal = new Animal();
                    newAnimal.AnimalId = int.Parse(csvOutputData[i][0]);
                    newAnimal.Name = csvOutputData[i][1];
                    newAnimal.Weight = int.Parse(csvOutputData[i][3]);
                    newAnimal.Age = int.Parse(csvOutputData[i][4]);
                    newAnimal.Demeanor = csvOutputData[i][7];
                    newAnimal.KidFriendly = (int.Parse(csvOutputData[i][8]) == 1) ? true : false;
                    newAnimal.PetFriendly = (int.Parse(csvOutputData[i][9]) == 1) ? true : false;
                    newAnimal.AdoptionStatus = csvOutputData[i][10];
                }
            }
            AnimalCSVToDatabase();
            Console.ReadLine();

        }
        
    }
}
