
using UnityEngine;

public class BottleBlast : MonoBehaviour
{
    public ParticleSystem blastEffectPrefab;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Finish"))
        {
            //collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
            Instantiate(blastEffectPrefab, transform.position, Quaternion.identity);
            blastEffectPrefab.Play();
        }
    }
}
