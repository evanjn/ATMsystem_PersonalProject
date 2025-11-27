[System.Serializable]
public class UserData
{
    public string id;
    public string password;

    public string userName;
    public int accountCash;
    public int accountBalance;

    public UserData(string id, string password , string name, int cash, int balance)
    {
        this.id = id;
        this.password = password;
        this.userName = name;
        this.accountCash = cash;
        this.accountBalance = balance;
    }
}
