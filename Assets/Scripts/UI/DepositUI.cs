using UnityEngine;
using TMPro;

public class DepositUI : MonoBehaviour
{
    [Header("Deposit")]
    [SerializeField] private StateUI stateUI;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private GameObject insufficiencyPopup;
    public void Deposit(int amount)
    {
        UserData data = GameManager.Instance.userData;

        if (data.accountCash < amount)
        {
            if (insufficiencyPopup != null)
            {
                insufficiencyPopup.SetActive(true);
                return;
            }
        }
        data.accountCash -= amount;
        data.accountBalance += amount;

        stateUI.Refresh();

        GameManager.Instance.SaveUserData();
        Debug.Log("저장됨");
    }
    public void DepositFromInput()
    {
        string text = inputField.text;

        if (!int.TryParse(text, out int amount) || amount <= 0)
        {
            return;
        }
        Deposit(amount);
        inputField.text = "";
    }
    public void CloseDepositInsufficientPopup()
    {
        if (insufficiencyPopup != null)
            insufficiencyPopup.SetActive(false);
    }
}