using UnityEngine;
namespace BucketMove.Level_1
{
    public class BallDeative : MonoBehaviour
    {
        public GameManager gameManager;
        public int count = 0;
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject != null)
            {
                collision.gameObject.SetActive(false);
                count += 1;
                if (count >= 30)
                {
                   // Debug.Log("Enered---------------1");
                    gameManager.LevelFailure();
                }
            }
        }
        void OnEnable()
        {
            count = 0;
        }
    }
}
