using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject CompanyLogo,TittleLogo,UserNameGet,PlayeingArea,CongratsPanel;

    void Start()
    {
        CompanyLogo.SetActive(true);
        UserNameGet.SetActive(false);
        PlayeingArea.SetActive(false);
        CongratsPanel.SetActive(false);
        TittleLogo.SetActive(false);
        Invoke(nameof(CompanyLogoOffFun),3f);
    }
    private void CompanyLogoOffFun()
    {
        CompanyLogo.SetActive(false);
        TittleLogo.SetActive(true);
        Invoke(nameof(TittleLogoOffFun),5f);
    }
    private void TittleLogoOffFun()
    {
        TittleLogo.SetActive(false);
        UserNameGet.SetActive(true);
    }
}
