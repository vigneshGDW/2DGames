using UnityEngine;

public class PlaceWinChecker : MonoBehaviour
{
    public bool IsplaceWin = false;
    public bool LeftSideCheck, RightSideCheck, UpSideCheck, DownSideCheck;
    public PlyerController plyerController;
    public GameObject LightBlueObj,LightGreenObj;
    public void PlaceWicnCheckFun()
    {
        if(plyerController.Player1)
        {
            if(LeftSideCheck && RightSideCheck && UpSideCheck && DownSideCheck)
            {
                IsplaceWin = true;
                LightGreenObj.SetActive(true);
            }
        }
        else if(plyerController.Player2)
        {
            if(LeftSideCheck && RightSideCheck && UpSideCheck && DownSideCheck)
            {
                IsplaceWin = true;
                LightBlueObj.SetActive(true);
            }
        }
    
    }
}
