using UnityEngine;
using TMPro;

public class WithdrawalUI : MonoBehaviour
{
    [Header("Withdrawal")]
    [SerializeField] private StateUI stateUI;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private GameObject insufficiencyPopup;
    public void Withdrawal(int amount)
    {
        UserData data = GameManager.Instance.userData;

        if (data.accountBalance < amount)
        {
            if (insufficiencyPopup != null)
            {
                insufficiencyPopup.SetActive(true);
                return;
            }
        }
        data.accountBalance -= amount;
        data.accountCash += amount;

        stateUI.Refresh();

        GameManager.Instance.SaveUserData();
        Debug.Log("저장됨");
    }
    public void WithdrawalFromInput()
    {
        string text = inputField.text;

        if (!int.TryParse(text, out int amount) || amount <= 0)
        {
            return;
        }
        Withdrawal(amount);
        inputField.text = "";
    }
    public void CloseWithdrawalInsufficientPopup()
    {
        if (insufficiencyPopup != null)
            insufficiencyPopup.SetActive(false);
    }

}