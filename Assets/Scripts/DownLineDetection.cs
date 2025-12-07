using UnityEngine;

public class DownLineDetection : MonoBehaviour
{
    public  PlaceWinChecker placeWinChecker;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            placeWinChecker.DownSideCheck = true;
            placeWinChecker.PlaceWicnCheckFun();
        }
    }
}
