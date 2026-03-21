using Unity.VisualScripting;
using UnityEngine;

public class BottleBlast : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Finish"))
        {
            //collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
