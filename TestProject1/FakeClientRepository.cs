using LegacyApp;

namespace TestProject1;

public class FakeClientRepository:IClientRepository
{
    public Client GetById(int idClient)
    {
        return new Client();
    }
}