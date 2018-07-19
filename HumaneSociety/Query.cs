using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HumaneSociety
{
    public static class Query
    {
        public delegate void Del(Employee employee);
        public static HumaneSocietyDataContext database = new HumaneSocietyDataContext();
        public static Client GetClient(string username, string password)
        {
            var requiredData =
                (from x in database.Clients
                where x.UserName == username && x.Password == password
                select x).First();
            //requiredData.ToList();
            return requiredData;
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
        public static void UpdateAdoption(bool x, Adoption adoption)
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
            if (requiredData != null)
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
        public static Species GetSpecies(string speciesName)
        {
            
            try
            {
                var requiredData =
                (from x in database.Species
                 where x.Name == speciesName
                 select x).First();
                return requiredData;
            }
            catch
            {
                Species newSpecies = new Species();
                newSpecies.Name = speciesName;
                database.Species.InsertOnSubmit(newSpecies);
                database.SubmitChanges();
                return newSpecies;
            }
        }
        public static DietPlan GetDietPlan(string dietPlanName)
        {
            try
            {
                var requiredData =
                (from x in database.DietPlans
                 where x.Name == dietPlanName
                 select x).First();
                return requiredData;
            }
            catch
            {
                DietPlan newPlan = new DietPlan();
                newPlan.Name = dietPlanName;
                return newPlan;
            }
        }
        public static void Adopt(Animal animal, Client client)
        {
            Adoption newAdd = new Adoption();
            newAdd.Client = client;
            newAdd.Animal = animal;
            database.Adoptions.InsertOnSubmit(newAdd);
            database.SubmitChanges();
        }
        public static IQueryable<Client> RetrieveClients()
        {
            var requiredData =
               from x in database.Clients
               select x;
            return requiredData;
        }
        public static IQueryable<USState> GetStates()
        {
            var requiredData =
               from x in database.USStates
               select x;
            return requiredData;
        }
        public static void AddNewClient(string firstName, string lastName, string username, string password, string email, string streetAddress, int zipCode, int state)
        {
            Client newClient = new Client();
            newClient.FirstName = firstName;
            newClient.LastName = lastName;
            newClient.UserName = username;
            newClient.Password = password;
            newClient.Email = email;
            //newClient.Address.USStateId = state;
            //newClient.Address.USState.USStateId = state;
            //newClient.Address.Zipcode = zipCode;
            //newClient.Address.AddressLine1 = streetAddress;
            Address newAddress = new Address();
            newAddress.AddressLine1 = streetAddress;
            newAddress.USStateId = state;
            newAddress.Zipcode = zipCode;
            database.Addresses.InsertOnSubmit(newAddress);
            database.SubmitChanges();
            newClient.Address = newAddress;
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
        public static void EnterUpdate(Animal animal, Dictionary<int, string> dictionayrOfChanges)
        {
            var requiredData =
                (from x in database.Animals
                 where x.AnimalId == animal.AnimalId
                 select x).First();
            foreach(KeyValuePair<int, string> item in dictionayrOfChanges)
            {
                switch (item.Key)
                {
                    case '1':
                        requiredData.Species.Name = item.Value;
                        break;
                    case '2':
                        requiredData.Species.Name = item.Value;
                        break;
                    case '3':
                        requiredData.Name = item.Value;
                        break;
                    case '4':
                        requiredData.Age = int.Parse(item.Value);
                        break;
                    case '5':
                        requiredData.Demeanor = item.Value;
                        break;
                    case '6':
                        if (item.Value == "true")
                        {
                            requiredData.KidFriendly = true;
                        }
                        else
                        {
                            requiredData.KidFriendly = false;
                        }
                        break;
                    case '7':
                        if (item.Value == "true")
                        {
                            requiredData.PetFriendly = true;
                        }
                        else
                        {
                            requiredData.PetFriendly = false;
                        }
                        break;
                    case '8':
                        requiredData.Weight = int.Parse(item.Value);
                        break;
                }
            }
        }
        public static IQueryable<AnimalShot> GetShots(Animal animal)
        {
            var requiredData =
                from x in database.AnimalShots
                where x.AnimalId == animal.AnimalId
                select x;
            return requiredData;
        }
        public static void UpdateShot(string newShot, Animal animal) // unaccounted for error
        {
            AnimalShot newAnimalShot = new AnimalShot();
            newAnimalShot.AnimalId = animal.AnimalId;
            newAnimalShot.Shot.Name = newShot;
            database.AnimalShots.InsertOnSubmit(newAnimalShot);
            database.SubmitChanges();
        }
        public static Employee EmployeeLogin(string username, string password)
        {
            var requiredData =
               (from x in database.Employees
               where x.UserName == username && x.Password == password
               select x).First();
            return requiredData;
        }
        public static Employee RetrieveEmployeeUser(string email, int employeeNumber)
        {
            var requiredData =
            (from x in database.Employees
             where x.Email == email || x.EmployeeNumber == employeeNumber
             select x).First();
            return requiredData;
        }
        public static void AddUsernameAndPassword(Employee employee)
        {
            var requiredData =
                (from x in database.Employees
                 where x.EmployeeId == employee.EmployeeId
                 select x).First();
            if (requiredData != null)
            {
                requiredData.UserName = employee.UserName;
                requiredData.Password = employee.Password;
                database.SubmitChanges();
            }
        }
        public static bool CheckEmployeeUserNameExist(string username)
        {
            try
            {
                var requiredData =
                (from x in database.Employees
                 where x.UserName == username
                 select x).First();

                if (requiredData.UserName == username)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            
        }
        public static void RunEmployeeQueries(Employee employee, string message)
        {

            switch (message)
            {
                case "create":
                    Del create = new Del(CreateEmployee);
                    create(employee);
                    break;
                case "delete":
                    Del delete = new Del(DeleteEmployee);
                    delete(employee);
                    break;
                case "read":
                    Del read = new Del(ReadEmployee);
                    read(employee);
                    break;
                case "update":
                    Del update = new Del(UpdateEmployee);
                    update(employee);
                    break;
                default:
                    UserInterface.DisplayUserOptions("Input not recognized please try again or type exit");
                    break;
            }

        }
        public static void CreateEmployee(Employee employee)
        {
            database.Employees.InsertOnSubmit(employee);
            database.SubmitChanges();
        }
        public static void DeleteEmployee(Employee employee)
        {
            var requiredData =
               (from x in database.Employees
                where x.EmployeeNumber == employee.EmployeeNumber
                select x).First();
            if (requiredData != null)
            {
                database.Employees.DeleteOnSubmit(requiredData);
                database.SubmitChanges();
            }
        }
        public static void ReadEmployee(Employee employee)
        {
            var requiredData =
               (from x in database.Employees
                where x.EmployeeNumber == employee.EmployeeNumber
               select x).First();
            Console.WriteLine(requiredData.FirstName);
            Console.WriteLine(requiredData.LastName);
            Console.WriteLine(requiredData.Email);
            Console.ReadLine();
        }
        public static void UpdateEmployee(Employee employee)
        {
            var requiredData =
               (from x in database.Employees
                where x.EmployeeNumber == employee.EmployeeNumber
                select x).First();
            requiredData.FirstName = employee.FirstName;
            requiredData.LastName = employee.FirstName;
            requiredData.Email = employee.Email;
            database.SubmitChanges();
        }
        public static void UpdateEmployeeUserName(Employee employee, string username)
        {
            var requiredData =
               (from x in database.Employees
                where x.EmployeeNumber == employee.EmployeeNumber
                select x).First();
            requiredData.UserName = username;
            database.SubmitChanges();
        }
        public static Room GetRoom(int animalID)
        {
            var requiredData =
                from x in database.Rooms
                where animalID == x.Animal.AnimalId
                select x;
            return (Room)requiredData;
        }
        public static void ImportCSVDataToDatabase(string[][] csvOutputData) // CSV Data to New Record
        {
            for (int i = 0; i < csvOutputData.Count(); i++)
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
                database.Animals.InsertOnSubmit(newAnimal);
                database.SubmitChanges();
            }
        }
        public static double ChargeAdoptionFee(Adoption adoption)
        {
            if(adoption.AdoptionFee != null)
            {
                int? payment = adoption.AdoptionFee;
                double paymentConverted = Convert.ToDouble(payment);
                adoption.PaymentCollected = true;
                return paymentConverted;
            }
            else
            {
                adoption.PaymentCollected = true;
                return 0;
            }
        }
    }
}