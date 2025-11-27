using UnityEngine;
using TMPro;
public class SignUpUI : MonoBehaviour
{
    [Header("입력 필드")]
    [SerializeField] private TMP_InputField idInput;
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private TMP_InputField passWord;
    [SerializeField] private TMP_InputField passWordConfirm;

    [Header("연결할 패널들")]
    [SerializeField] private GameObject popupLogin;
    [SerializeField] private GameObject popupSignup;
    [SerializeField] private GameObject errorPopup;

    [SerializeField] private TextMeshProUGUI errorSignText;
    public void OnClickSignUp()
    {
        string id = idInput.text.Trim();
        string name = nameInput.text.Trim();
        string pw = passWord.text.Trim();
        string pwconfirm = passWordConfirm.text.Trim();

        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pw) || string.IsNullOrEmpty(pwconfirm))
        {
            ShowError("입력값이 비어 있습니다.");
            return;
        }

        if (pw != pwconfirm)
        {
            ShowError("비밀번호가 서로 다릅니다.");
            return;
        }

        string userKey = GetUserKey(id);
        if (PlayerPrefs.HasKey(userKey))
        {
            ShowError("이미 존재하는 ID입니다.");
            return;
        }

        int defaultBalance = 50000;
        int defaultCash = 100000;
        UserData newUser = new UserData(id, pw, name, defaultCash, defaultBalance);

        string json = JsonUtility.ToJson(newUser);
        PlayerPrefs.SetString(userKey, json);
        PlayerPrefs.Save();

        GameManager.Instance.userData = newUser;
        GameManager.Instance.SaveUserData();

        popupSignup.SetActive(false);
        if (popupLogin != null)
            popupLogin.SetActive(true);
    }
    public void CloseErrorPopup()
    {
        errorPopup.SetActive(false);
    }

    public void OnClickCancel()
    {
        popupSignup.SetActive(false);
        if (popupLogin != null)
            popupLogin.SetActive(true);
    }
    private string GetUserKey(string id)
    {
        return $"USER_{id}";
    }
    private void ShowError(string message)
    {
        Debug.LogWarning(message);

        if (errorSignText != null)
        {
            errorSignText.text = message;
        }

        if (errorPopup != null)
        {
            errorPopup.SetActive(true);
        }
    }
}