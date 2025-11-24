using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public UserData userData;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        string defaultName = "장현우";
        int defaultBalance = 50000;
        int defaultCash = 100000;

        userData = new UserData(defaultName, defaultBalance, defaultCash);
    }
}