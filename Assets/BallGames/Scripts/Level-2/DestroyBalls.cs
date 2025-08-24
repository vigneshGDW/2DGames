using UnityEngine;

namespace BucketMove.Level_2
{
    public class DestroyBalls : MonoBehaviour
    {
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject != null)
            {
                collision.gameObject.SetActive(false);
            }
        }
    }
}
