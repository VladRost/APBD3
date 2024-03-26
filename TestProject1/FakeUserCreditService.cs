using LegacyApp;

namespace TestProject1;

public class FakeUserCreditService:ICreditLimitService
{
    public int GetCreditLimit(string lastName, DateTime birthdate)
    {
        return 400;
    }
}