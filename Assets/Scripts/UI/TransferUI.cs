using UnityEngine;
using TMPro;

public class TransferUI : MonoBehaviour
{
    [Header("입력 필드")]
    [SerializeField] private TMP_InputField targetIdInput;
    [SerializeField] private TMP_InputField amountInput;

    [Header("오류창")]
    [SerializeField] private GameObject insufficiencyPopup;
    [SerializeField] private GameObject invalidRecipientPopup;
    [SerializeField] private GameObject errorPopup;

    [Header("UI 참조")]
    [SerializeField] private StateUI stateUI;

    private string GetUserKey(string id)
    {
        return $"USER_{id}";
    }
    private enum ErrorType
    {
        InputError,
        InsufficientFunds,
        InvalidRecipient
    }
    private void HideAllPopups()
    {
        if (insufficiencyPopup != null)
        {
            insufficiencyPopup.SetActive(false);
        }
        if (invalidRecipientPopup != null)
        {
            invalidRecipientPopup.SetActive(false);
        }
        if (errorPopup != null)
        {
            errorPopup.SetActive(false);
        }
    }

    private void ShowError(ErrorType type)
    {
        HideAllPopups();

        switch (type)
        {
            case ErrorType.InsufficientFunds:
                if (insufficiencyPopup != null)
                {
                    insufficiencyPopup.SetActive(true);
                }
                Debug.LogWarning("잔액 부족");
                break;

            case ErrorType.InvalidRecipient:
                if (invalidRecipientPopup != null)
                {
                    invalidRecipientPopup.SetActive(true);
                }
                Debug.LogWarning("송금 대상 없음");
                break;

            case ErrorType.InputError:
            default:
                if (errorPopup != null)
                {
                    errorPopup.SetActive(true);
                }
                Debug.LogWarning("잘못된 입력");
                break;
        }
    }

    public void ClosePopup()
    {
        HideAllPopups();
    }

    public void OnClickTransfer()
    {
        string targetId = targetIdInput.text.Trim();
        string amountText = amountInput.text.Trim();

        if (string.IsNullOrEmpty(targetId) || string.IsNullOrEmpty(amountText))
        {
            ShowError(ErrorType.InputError);
            return;
        }

        if (!int.TryParse(amountText, out int amount) || amount <= 0)
        {
            ShowError(ErrorType.InputError);
            return;
        }

        UserData myData = GameManager.Instance.userData;
        if (myData == null)
        {
            ShowError(ErrorType.InputError);
            return;
        }

        if (myData.accountBalance < amount)
        {
            ShowError(ErrorType.InsufficientFunds);
            return;
        }

        string targetKey = GetUserKey(targetId);
        if (!PlayerPrefs.HasKey(targetKey))
        {
            ShowError(ErrorType.InvalidRecipient);
            return;
        }

        string targetJson = PlayerPrefs.GetString(targetKey);
        UserData targetData = JsonUtility.FromJson<UserData>(targetJson);

        myData.accountBalance -= amount;
        targetData.accountBalance += amount;

        string myKey = GetUserKey(myData.id);
        string myJson = JsonUtility.ToJson(myData);
        string newJson = JsonUtility.ToJson(targetData);

        PlayerPrefs.SetString(myKey, myJson);
        PlayerPrefs.SetString(targetKey, newJson);
        PlayerPrefs.Save();

        GameManager.Instance.userData = myData;
        GameManager.Instance.SaveUserData();

        if (stateUI != null)
            stateUI.Refresh();

        targetIdInput.text = string.Empty;
        amountInput.text = string.Empty;

        Debug.Log($"[TRANSFER] {targetId} 에게 {amount}원 송금 완료");
    }
}

