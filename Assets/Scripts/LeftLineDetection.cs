using UnityEngine;

public class LeftLineDetection : MonoBehaviour
{
    public  PlaceWinChecker placeWinChecker;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            placeWinChecker.LeftSideCheck = true;
            placeWinChecker.PlaceWicnCheckFun();
        }
    }
}
