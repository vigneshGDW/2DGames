using UnityEngine;

public class PlaceWinChecker : MonoBehaviour
{
    public bool IsplaceWin = false;
    public bool LeftSideCheck, RightSideCheck, UpSideCheck, DownSideCheck;
    public PlyerController plyerController;
    public GameObject LightBlueObj,LightGreenObj;
    public ChanceGiver chanceGiver;
    public void PlaceWicnCheckFun()
    {
        if(plyerController.Player1)
        {
            if(LeftSideCheck && RightSideCheck && UpSideCheck && DownSideCheck)
            {
                IsplaceWin = true;
                chanceGiver.itsnowtowork = true;
                LightGreenObj.SetActive(true);
                chanceGiver.NextChanceGiveFun();
                plyerController.Player1 = false;
                plyerController.Player2 = true;
            }
            else
            {
                chanceGiver.itsnowtowork = false;
                chanceGiver.NextChanceGiveFun();
            }
        }
        else if(plyerController.Player2)
        {
            if(LeftSideCheck && RightSideCheck && UpSideCheck && DownSideCheck)
            {
                IsplaceWin = true;
                chanceGiver.itsnowtowork = true;
                LightBlueObj.SetActive(true);
                chanceGiver.NextChanceGiveFun();
                plyerController.Player1 = true;
                plyerController.Player2 = false;
            }
            else
            {
                chanceGiver.itsnowtowork = false;
                chanceGiver.NextChanceGiveFun();
            }
        }
    
    }
}
