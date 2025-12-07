using UnityEngine;

public class RightLineDetection : MonoBehaviour
{
    public  PlaceWinChecker placeWinChecker;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            placeWinChecker.RightSideCheck = true;
            placeWinChecker.PlaceWicnCheckFun();
        }
    }
}
