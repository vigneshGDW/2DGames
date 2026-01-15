using UnityEngine;

public class ChanceGiver : MonoBehaviour
{
    public GameObject Player1GreenChance,Plyer1RedChance;
    public GameObject Player2GreenChance,Plyer2RedChance;
    public PlaceWinChecker[] placeWinCheckers;
    public PlyerController plyerController; 
    public bool itsnowtowork = false;
    public void NextChanceGiveFun()
    {
        if(plyerController.Player1)
        {
            for (int i = 0; i < placeWinCheckers.Length; i++)
            {
                if (placeWinCheckers[i].IsplaceWin)
                    continue;

                int trueCount = 0;

                if (placeWinCheckers[i].RightSideCheck) trueCount++;
                if (placeWinCheckers[i].LeftSideCheck)  trueCount++;
                if (placeWinCheckers[i].UpSideCheck)    trueCount++;
                if (placeWinCheckers[i].DownSideCheck)  trueCount++;

                if (trueCount >= 3 && itsnowtowork)
                {
                    itsnowtowork = false;
                    Player1GreenChance.SetActive(true);
                    Plyer1RedChance.SetActive(false);
                    Plyer2RedChance.SetActive(true);
                    Player2GreenChance.SetActive(false);
                    plyerController.Player1 = false;
                    plyerController.Player2 = true;
                    return;
                }
                else
                {
                    Player1GreenChance.SetActive(false);
                    Plyer1RedChance.SetActive(true);
                    Player2GreenChance.SetActive(true);
                    Plyer2RedChance.SetActive(false);
                }
            }
        }
        else if(plyerController.Player2)
        {
            for (int i = 0; i < placeWinCheckers.Length; i++)
            {
                if (placeWinCheckers[i].IsplaceWin)
                    continue;

                int trueCount = 0;

                if (placeWinCheckers[i].RightSideCheck) trueCount++;
                if (placeWinCheckers[i].LeftSideCheck)  trueCount++;
                if (placeWinCheckers[i].UpSideCheck)    trueCount++;
                if (placeWinCheckers[i].DownSideCheck)  trueCount++;

                if (trueCount >= 3 && itsnowtowork)
                {
                    itsnowtowork = false;
                    Player2GreenChance.SetActive(true);
                    Plyer2RedChance.SetActive(false);
                    Player1GreenChance.SetActive(false);
                    Plyer1RedChance.SetActive(true);
                     plyerController.Player1 = true;
                    plyerController.Player2 = false;
                    return;
                }
                else
                {
                    Player1GreenChance.SetActive(true);
                    Plyer1RedChance.SetActive(false);
                    Player2GreenChance.SetActive(false);
                    Plyer2RedChance.SetActive(true);
                }
            }
        }
    }
    void OnEnable()
    {
        Player1GreenChance.SetActive(true);
        Plyer1RedChance.SetActive(false);
        Player2GreenChance.SetActive(false);
        Plyer2RedChance.SetActive(true);
        itsnowtowork = false;
    }
}
