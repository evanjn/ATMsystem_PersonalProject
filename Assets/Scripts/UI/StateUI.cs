using UnityEngine;
using TMPro;

public class StateUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI userNameText;
    [SerializeField] private TextMeshProUGUI balanceText;
    [SerializeField] private TextMeshProUGUI cashText;

    void Start()
    {
        UpdateAccountUI();
    }

    private void UpdateAccountUI()
    {
        UserData data = GameManager.Instance.userData;

        userNameText.text = data.userName;
        cashText.text = data.accountCash.ToString("N0");
        balanceText.text = data.accountBalance.ToString("N0");
    }
}
