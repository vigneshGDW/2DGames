using UnityEngine;

namespace BucketMove.Level_2
{
    public class Wincheck2 : MonoBehaviour
    {
        public int count = 0;
        public GameManager gameManager;
        public ProgressBar progressBar;
        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject != null)
            {
                other.gameObject.SetActive(false);
                count += 1;
                progressBar.IncreaseProgress();
                if (count == 20)
                {
                    //Debug.Log("Level 1 - Completed");
                    //gameManager.LevelCompleted();
                }
            }
        }
        void OnEnable()
        {
            count = 0;
        }
    }
}

