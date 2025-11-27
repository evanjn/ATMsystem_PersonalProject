using UnityEngine;

public class DepositUIManager : MonoBehaviour
{
    [SerializeField] private GameObject popupLogin;
    [SerializeField] private GameObject ATM;
    [SerializeField] private GameObject depositBtn;
    [SerializeField] private GameObject depositPanel;
    [SerializeField] private GameObject withdrawalBtn;
    [SerializeField] private GameObject withdrawalPanel;
    [SerializeField] private GameObject popupSignup;
    [SerializeField] private GameObject logoutBtn;
    [SerializeField] private GameObject transferPanel;
    [SerializeField] private GameObject transferBtn;

    private void Start()
    {
        ShowLogin();
    }
    private void ShowLogin()
    {
        popupLogin.SetActive(true);
        logoutBtn.SetActive(false);
        ATM.SetActive(false);
        depositPanel.SetActive(false);
        withdrawalPanel.SetActive(false);
        transferPanel.SetActive(false);
        popupSignup.SetActive(false);
    }
    public void OpenDepositUI()
    {
        withdrawalBtn.SetActive(false);
        depositBtn.SetActive(false);
        depositPanel.SetActive(true);
    }

    public void PopupSignup()
    {
        popupSignup.SetActive(true);
    }

    public void CloseDepositUI()
    {
        depositPanel.SetActive(false);
        depositBtn.SetActive(true);
        withdrawalBtn.SetActive(true);
    }
    public void OpenWithdrawalUI()
    {
        depositBtn.SetActive(false);
        withdrawalBtn.SetActive(false);
        withdrawalPanel.SetActive(true);
    }
    public void CloseWithdrawalUI()
    {
        withdrawalPanel.SetActive(false);
        withdrawalBtn.SetActive(true);
        depositBtn.SetActive(true);
    }
    public void OnLoginSuccess()
    {
        popupLogin.SetActive(false);
        popupSignup.SetActive(false);
        ATM.SetActive(true);
        depositBtn.SetActive(true);
        withdrawalBtn.SetActive(true);
        transferBtn.SetActive(true);
        logoutBtn.SetActive(true);
    }
    public void LogOut()
    {
        ShowLogin();
    }
    public void OpenTransferUI()
    {
        depositBtn.SetActive(false);
        withdrawalBtn.SetActive(false);
        transferBtn.SetActive(false);
        transferPanel.SetActive(true);
    }
    public void CloseTransferUI()
    {
        depositBtn.SetActive(true);
        withdrawalBtn.SetActive(true);
        transferBtn.SetActive(true);
        transferPanel.SetActive(false);
    }
}