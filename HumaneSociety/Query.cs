﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    public static class Query
    {
        public static HumaneSocietyDataContext database = new HumaneSocietyDataContext();

        public static Client GetClient(string username, string password)
        {
            var requiredData =
                from x in database.Clients
                where x.UserName == username && x.Password == password
                select x;
            requiredData.ToList();
            return (Client)requiredData;
        }
        public static IQueryable<string> GetUserAdoptionStatus(Client client)
        {
            var requiredData =
                from x in database.Adoptions
                where x.ClientId == client.ClientId
                select x.ApprovalStatus;
            return requiredData;
        }
        public static List<Adoption> GetPendingAdoptions()
        {

        }
        public static bool UpdateAdoption(bool x , Adoption adoption)
        {

        }
        public static Animal GetAnimalByID(int iD)
        {
            var requiredData =
                from x in database.Animals
                where x.AnimalId == iD
                select x;
            requiredData.ToList();
            return (Animal)requiredData;
        }
        public static Animal RemoveAnimal(Animal animal)
        {

        }
        public static Animal AddAnimal(Animal animal)
        {

        }
        public static Species GetSpecies()
        {

        }
        public static DietPlan GetDietPlan()
        {

        }
        public static void Adopt(Animal animal, Client client)
        {

        }
        public static Client RetrieveClients()
        {

        }
        public static USState GetStates()
        {

        }
        public static void AddNewClient(string firstName, string lastName, string username, string password, string email, string streetAddress, int zipCode, int state)
        {

        }
        public static void UpdateClient(Client client)
        {

        }
        public static void UpdateUsername(Client client)
        {

        }
        public static void UpdateEmail(Client client)
        {

        }
        public static void UpdateAddress(Client client)
        {

        }
        public static void UpdateFirstName(Client client)
        {

        }
        public static void UpdateLastName(Client client)
        {

        }
        public static object EnterUpdate(Animal animal, Dictionary<int, string>)
        {

        }
        public static IQueryable<AnimalShot> GetShots(Animal animal)
        {
            var requiredData =
                from x in database.AnimalShots
                where x.AnimalId == animal.AnimalId
                select x;
            return requiredData;
        }
        public static object UpdateShot(string, Animal animal)
        {

        }
        public static Employee EmployeeLogin(string username, string password)
        {

        }
        public static Employee RetrieveEmployeeUser(string email, int employeeNumber)
        {

        }
        public static void AddUsernameAndPassword(Employee employee)
        {

        }
        public static bool CheckEmployeeUserNameExist(string username)
        {

        }

        public static void RunEmployeeQueries(Employee employee, string message)
        {

        }
        public static Room GetRoom(int animalID)
        {

        }
    }
}