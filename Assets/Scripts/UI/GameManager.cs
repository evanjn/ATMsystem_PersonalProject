using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public UserData userData;

    private const string USER_DATA_KEY = "USER_DATA_JSON";
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadUserData();
    }
    private void CreateDefaultUserData()
    {
        string defaultId = "CodingSlave";
        string defaultPW = "527527";
        string defaultName = "장현우";
        int defaultBalance = 50000;
        int defaultCash = 100000;

        userData = new UserData(defaultId, defaultPW, defaultName, defaultCash, defaultBalance);
    }

    public void SaveUserData()
    {
        if (userData == null)
            return;

        string json = JsonUtility.ToJson(userData);

        PlayerPrefs.SetString(USER_DATA_KEY, json);
        PlayerPrefs.Save();
        Debug.Log($"[SAVE] UserData 저장됨: {json}");
    }
    public void LoadUserData()
    {
        if (PlayerPrefs.HasKey(USER_DATA_KEY))
        {
            string json = PlayerPrefs.GetString(USER_DATA_KEY);
            userData = JsonUtility.FromJson<UserData>(json);
            Debug.Log($"[LOAD] UserData 불러옴: {json}");
        }
        else
        {
            CreateDefaultUserData();
            Debug.Log("[LOAD] 저장된 데이터 없음 → 기본값 생성");
        }
    }

    public void ResetUserData()
    {
        PlayerPrefs.DeleteKey(USER_DATA_KEY);
        PlayerPrefs.Save();
        CreateDefaultUserData();

        var stateUI = FindObjectOfType<StateUI>();
        if (stateUI != null)
        {
            stateUI.Refresh();
        }

        Debug.Log("저장 데이터 초기화 완료");
    }
}