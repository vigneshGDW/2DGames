using UnityEngine;

public class UpLineDetection : MonoBehaviour
{
    public  PlaceWinChecker placeWinChecker;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            placeWinChecker.UpSideCheck = true;
            placeWinChecker.PlaceWicnCheckFun();
        }
    }
}
    