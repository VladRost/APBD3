using LegacyApp;

namespace TestProject1;

public class UnitTest1
{
    [Fact]
    public void AddUser_Should_Return_False_When_Email_Without_At_And_Dot()
    {
        //Arrange
        string firstName = "John";
        string lastName = "Doe";
        DateTime birthDate = new DateTime(1980, 1, 1);
        int clientId = 1;
        string email = "doe";
        var service = new UserService();
        
        //Act
        bool result = service.AddUser(firstName, lastName, email, birthDate, clientId);
        
        //Assert
        Assert.Equal(false,result);
    }
    [Fact]
    public void AddUser_Should_Return_False_When_FirstName_And_LastName_Empty()
    {
        //Arrange
        string firstName = "";
        string lastName = "";
        DateTime birthDate = new DateTime(1980, 1, 1);
        int clientId = 1;
        string email = "doe@dsdaf.das";
        var service = new UserService();
        
        //Act
        bool result = service.AddUser(firstName, lastName, email, birthDate, clientId);
        
        //Assert
        Assert.Equal(false,result);
    }
    [Fact]
    public void AddUser_Should_Return_False_When_Age_Under_21()
    {
        //Arrange
        string firstName = "adf";
        string lastName = "asdf";
        DateTime birthDate = new DateTime(2009, 1, 1);
        int clientId = 1;
        string email = "doe@dsdaf.das";
        var service = new UserService();
        
        //Act
        bool result = service.AddUser(firstName, lastName, email, birthDate, clientId);
        
        //Assert
        Assert.Equal(false,result);
    }
    [Fact]
    public void AddUser_Should_Return_False_When_User_Has_Credit_Limit_And_Credit_Limit_Under_500()
    {
        //Arrange
        string firstName = "Malewski";
        string lastName = "asdf";
        DateTime birthDate = new DateTime(1980, 1, 1);
        int clientId = 2;
        string email = "malewski@gmail.pl";
        var service = new UserService(new FakeClientRepository(),new FakeUserCreditService());
        
        //Act
        bool result = service.AddUser(firstName, lastName, email, birthDate, clientId);
        
        //Assert
        Assert.Equal(false,result);
    }
    
}