using UnityEngine;
using TMPro;
public class LoginUI : MonoBehaviour
{
    [Header("입력 필드")]
    [SerializeField] private TMP_InputField idInput;
    [SerializeField] private TMP_InputField pwInput;

    [Header("UI 연결")]
    [SerializeField] private DepositUIManager uiManager;
    [SerializeField] private GameObject errorPopup;

    private void ShowError()
    {
        if (errorPopup != null)
        {
            errorPopup.SetActive(true);
        }
    }

    public void OnClickLogin()
    {
        string id = idInput.text.Trim();
        string pw = pwInput.text.Trim();

        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(pw))
        {
            ShowError();
            return;
        }

        string userKey = $"USER_{id}";
        if (!PlayerPrefs.HasKey(userKey))
        {
            ShowError();
            return;
        }

        string json = PlayerPrefs.GetString(userKey);
        UserData savedUser = JsonUtility.FromJson<UserData>(json);

        if (savedUser.password != pw)
        {
            ShowError();
            return;
        }

        GameManager.Instance.userData = savedUser;
        GameManager.Instance.SaveUserData();

        StateUI stateUI = FindObjectOfType<StateUI>();
        if (stateUI != null)
            stateUI.Refresh();

        if (uiManager != null)
            uiManager.OnLoginSuccess();
    }
    public void CloseErrorPopup()
    {
        if (errorPopup != null)
            errorPopup.SetActive(false);
    }
}