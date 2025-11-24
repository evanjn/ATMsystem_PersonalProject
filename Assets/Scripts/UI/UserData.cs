[System.Serializable]
public class UserData
{
    public string userName;
    public int accountCash;
    public int accountBalance;

    public UserData(string name, int cash, int balance)
    {
        this.userName = name;
        this.accountCash = cash;
        this.accountBalance = balance;
    }
}
