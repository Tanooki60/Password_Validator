while (true) 
{
    string? password = UserInput("Please enter a valid password (upper case, lower case, and one number): ");
    PasswordValidator passwordChecker = new PasswordValidator();
    passwordChecker.SetPassword(password);
    passwordChecker.ValdiatePassword();
}
string? UserInput(string text)
{
    Console.Write(text);
    return Console.ReadLine();
}
class PasswordValidator
{
    private string? Password { get;  set; }

    private bool CheckPasswordLength()
    {
        if (Password.Length < 6) Console.WriteLine("The password is less than 6 characters");
        if (Password.Length > 13) Console.WriteLine("The password is greater than 13 characters");
        if (Password.Length > 6 && Password.Length < 13) return true; return false;
    }

    private bool CheckPasswordCharacters()
    {
        bool upperCaseCheck = false;
        bool lowerCaseCheck = false;
        bool numberCheck = false;
        bool ampersandCheck = false;
        bool upperCaseTCheck = false;


        foreach (char c in Password)
        {
            if (char.IsUpper(c)) upperCaseCheck = true;
            if (char.IsLower(c)) lowerCaseCheck = true;
            if (char.IsDigit(c)) numberCheck = true;
            if (char.Equals(c, '&')) ampersandCheck = true;
            if (char.Equals(c, 'T')) upperCaseTCheck = true;
        }

        if (!upperCaseCheck) Console.WriteLine("No upper case was used");
        if (!lowerCaseCheck) Console.WriteLine("No lower case was used");
        if (!numberCheck) Console.WriteLine("No number was used");
        if (ampersandCheck == true) Console.WriteLine("An ampersand was used. Ingelmar is not pleased.");
        if (upperCaseTCheck == true) Console.WriteLine("An upper case T was used. Ingelmar is not pleased.");

        if (upperCaseCheck == true && lowerCaseCheck == true && numberCheck == true) return true;
        else return false;
    }

    public void ValdiatePassword()
    {
        if (CheckPasswordCharacters() == true && CheckPasswordLength() == true)
            Console.WriteLine("That is a valid password");
        else
            Console.WriteLine("That is an invalid password");
    }
    public string SetPassword(string password)
    {
        return Password = password;
    }
}