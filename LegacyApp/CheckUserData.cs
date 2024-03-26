using System;

namespace LegacyApp;

public class CheckUserData
{
    private string firstName;
    private string lastName;
    private string email;
    private DateTime dateOfBirth;
    public CheckUserData(string firstName, string lastName, string email, DateTime dateOfBirth)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.dateOfBirth = dateOfBirth;
    }

    public bool CheckUserName()
    {
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
        {
            return false;
        }

        return true;
    }

    public bool CheckUserEmail()
    {
        if (!email.Contains("@") && !email.Contains("."))
        {
            return false;
        }

        return true;
    }

    public bool CheckUserDate()
    {
        var now = DateTime.Now;
        int age = now.Year - dateOfBirth.Year;
        if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

        if (age < 21)
        {
            return false;
        }

        return true;
    }
    
    
}