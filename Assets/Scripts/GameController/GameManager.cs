using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject CompanyLogo,TittleLogo,UserNameGet,PlayeingArea,CongratsPanel;
    public Text Player1TextShow,Player2TextShow;
    public UserInformation Player1Info,Player2Info;
    public Text Player1ValueText,Player2ValueText;
    public PlyerController plyerController;
    private int player1box,player2box = 0;
    public PlaceWinChecker[] placeWinCheckers;
    public bool GameWinBool = false;
    public GameObject Player1Boy,Player2Girl;
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
    public void PlayerGameStartFun()
    {
        UserNameGet.SetActive(false);
        PlayeingArea.SetActive(true);
        if(Player1Info.NameEntered)
        {
            Player1TextShow.text = "";
            Player1TextShow.text = Player1Info.showNameText.text;
        }
        else
        {
            Player1TextShow.text = "";
            Player1TextShow.text = "Amy";
        }
        if(Player2Info.NameEntered)
        {
            Player2TextShow.text = "";
            Player2TextShow.text = Player2Info.showNameText.text;
        }
        else
        {
            Player2TextShow.text = "";
            Player2TextShow.text = "Yummy";
        }
        RestartButtonClickFun();
    }
    public void PlayerScoreUpdateFun()
    {
        GameWinBool = true;
        if(plyerController.Player1)
        {
            player1box ++;
            Player1ValueText.text = player1box.ToString();
        }
        if(plyerController.Player2)
        {
            player2box ++;
            Player2ValueText.text = player2box.ToString();
        }
        foreach(var placeWinChecker in placeWinCheckers)
        {
            if(!placeWinChecker.IsplaceWin)
            {
                GameWinBool = false;
                return;
            }
        }
        if(GameWinBool)
        {
            //Debug.Log("Game Win");
            if(player1box > player2box)
            {
                CongratsPanel.SetActive(true);
                PlayeingArea.SetActive(false);
                Player1Boy.SetActive(true);
                Player2Girl.SetActive(false);
            }
            else if(player2box > player1box)
            {
                CongratsPanel.SetActive(true);
                PlayeingArea.SetActive(false);
                Player2Girl.SetActive(true);
                Player1Boy.SetActive(false);
            }
        }
    }
    public void HomeButtonClickFun()
    {
        CompanyLogo.SetActive(false);
        TittleLogo.SetActive(false);
        UserNameGet.SetActive(true);
        PlayeingArea.SetActive(false);
        CongratsPanel.SetActive(false);
    }
    public void RestartButtonClickFun()
    {
        CompanyLogo.SetActive(false);
        TittleLogo.SetActive(false);
        UserNameGet.SetActive(false);
        PlayeingArea.SetActive(true);
        CongratsPanel.SetActive(false);
        player1box = 0;
        player2box = 0;
        Player1ValueText.text = player1box.ToString();
        Player2ValueText.text = player2box.ToString();
    }
}
