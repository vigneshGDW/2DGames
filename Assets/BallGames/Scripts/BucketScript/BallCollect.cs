using UnityEngine;

namespace BucketMove.Level_1
{
    public class BallCollect : MonoBehaviour
    {
        public int count = 0;
        public GameManager gameManager;
        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject != null)
            {
                other.gameObject.SetActive(false);
                count += 1;
                if (count == 25)
                {
                    //Debug.Log("Level 1 - Completed");
                    gameManager.LevelCompleted();
                }
            }
        }
        void OnEnable()
        {
            count = 0;
        }
    }
}
