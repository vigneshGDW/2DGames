using UnityEngine;
namespace BucketMove.Level_1
{
    public class BallDeative : MonoBehaviour
    {
        public GameManager gameManager;
        private int count = 0;
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject != null)
            {
                collision.gameObject.SetActive(false);
                count += 1;
                if (count >= 30)
                {
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
