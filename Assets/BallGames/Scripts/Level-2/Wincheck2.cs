using UnityEngine;

namespace BucketMove.Level_2
{
    public class Wincheck2 : MonoBehaviour
    {
        public int count = 0;
        public GameManager gameManager;
        public ProgressBar progressBar;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject != null)
            {
                other.gameObject.SetActive(false);
                count += 1;
                progressBar.IncreaseProgress();
                if (count == 100)
                {
                    gameManager.LevelCompleted();
                    gameManager.Level2Win = true;
                }
            }
        }
    }
}

