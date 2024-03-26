using System;

namespace LegacyApp
{
    public interface ICreditLimitService
    {
        int GetCreditLimit(string lastName, DateTime birthdate);
    }
    public interface IClientRepository
    {
        Client GetById(int idClient);
    }
    public class UserService
    {
        private IClientRepository _clientRepository;
        private ICreditLimitService _creditLimitService;
        [Obsolete]
        public UserService()
        {
            _clientRepository = new ClientRepository();
            _creditLimitService = new UserCreditService();
        }

        public UserService(IClientRepository clientRepository,ICreditLimitService creditLimitService)
        {
            _clientRepository = clientRepository;
            _creditLimitService = creditLimitService;
        }
        
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            CheckUserData checkUserData = new CheckUserData(firstName, lastName, email, dateOfBirth);

            if (!checkUserData.CheckUserName() || !checkUserData.CheckUserDate()||!checkUserData.CheckUserEmail())
            {
                return false;
            }
           
            var client = _clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            if (client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            else if (client.Type == "ImportantClient")
            {
                    int creditLimit = _creditLimitService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    creditLimit = creditLimit * 2;
                    user.CreditLimit = creditLimit;
                
            }
            else
            {
                user.HasCreditLimit = true;
                    int creditLimit = _creditLimitService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    user.CreditLimit = creditLimit;
            }

            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}
