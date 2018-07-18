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
        public static IQueryable<Adoption> GetUserAdoptionStatus(Client client)
        {
            var requiredData =
                from x in database.Adoptions
                where x.ClientId == client.ClientId && x.ApprovalStatus == "Pending"
                select x;
            return requiredData;
        }
        public static IQueryable<Adoption> GetPendingAdoptions()
        {
            var requiredData =
                from x in database.Adoptions
                where x.ApprovalStatus == "Pending"
                select x;
            return requiredData;
        }
        public static void UpdateAdoption(bool x , Adoption adoption)
        {
            var requiredData =
                (from y in database.Adoptions
                 where y.AdoptionId == adoption.AdoptionId
                 select y).First();
            if (x)
            {
                requiredData.ApprovalStatus = "Approved";
            }
            else
            {
                requiredData.ApprovalStatus = "Denied";
            }
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
        public static void RemoveAnimal(Animal animal)
        {
            var requiredData =
                (from x in database.Animals
                 where x.AnimalId == animal.AnimalId
                 select x).First();
            if(requiredData != null)
            {
                database.Animals.DeleteOnSubmit(requiredData);
                database.SubmitChanges();
            }
        }
        public static void AddAnimal(Animal animal)
        {
            database.Animals.InsertOnSubmit(animal);
            database.SubmitChanges();
        }
        public static Species GetSpecies()
        {
            var requiredData =
                from x in database.Species
                select x;
            return (Species)requiredData;
        }
        public static DietPlan GetDietPlan()
        {
            var requiredData =
                from x in database.DietPlans
                select x;
            return (DietPlan)requiredData;
        }
        public static void Adopt(Animal animal, Client client)
        {
            Adoption newAdd = new Adoption();
            newAdd.Client = client;
            newAdd.Animal = animal;
            database.Adoptions.InsertOnSubmit(newAdd);
            database.SubmitChanges();
        }
        public static Client RetrieveClients()
        {
            
        }
        public static USState GetStates()
        {

        }
        public static void AddNewClient(string firstName, string lastName, string username, string password, string email, string streetAddress, int zipCode, int state)
        {
            Client newClient = new Client
            {
                FirstName = firstName,
                LastName = lastName,
                UserName = username,
                Password = password,
                Email = email
            };
            newClient.Address.USState.USStateId = state;
            newClient.Address.Zipcode = zipCode;
            newClient.Address.AddressLine1 = streetAddress;
            database.Clients.InsertOnSubmit(newClient);
            database.SubmitChanges();
        }
        public static void UpdateClient(Client client)
        {
            var requiredData =
                (from x in database.Clients
                 where x.ClientId == client.ClientId
                 select x).First();
            requiredData = client;
            database.SubmitChanges();
        }
        public static void UpdateUsername(Client client)
        {
            var requiredData =
                   (from x in database.Clients
                    where x.ClientId == client.ClientId
                    select x).First();
            requiredData.UserName = client.UserName;
            database.SubmitChanges();
        }
        public static void UpdateEmail(Client client)
        {
            var requiredData =
                   (from x in database.Clients
                    where x.ClientId == client.ClientId
                    select x).First();
            requiredData.Email = client.Email;
            database.SubmitChanges();
        }
        public static void UpdateAddress(Client client)
        {
            var requiredData =
                  (from x in database.Clients
                   where x.ClientId == client.ClientId
                   select x).First();
            requiredData.Address = client.Address;
            database.SubmitChanges();
        }
        public static void UpdateFirstName(Client client)
        {
            var requiredData =
                   (from x in database.Clients
                    where x.ClientId == client.ClientId
                    select x).First();
            requiredData.FirstName = client.FirstName;
            database.SubmitChanges();
        }
        public static void UpdateLastName(Client client)
        {
            var requiredData =
                   (from x in database.Clients
                    where x.ClientId == client.ClientId
                    select x).First();
            requiredData.LastName = client.LastName;
            database.SubmitChanges();
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