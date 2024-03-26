using LegacyApp;

namespace TestProject1;

public class FakeClientRepository:IClientRepository
{
    public Client GetById(int idClient)
    {
        return new Client{ClientId = 2, Name = "Malewski", Address = "Warszawa, Koszykowa 86", Email = "malewski@gmail.pl", Type = "NormalClient"};
    }
}