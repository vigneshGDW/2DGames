using UnityEngine;

namespace BucketMove.Level_1
{
    public class BallCollect : MonoBehaviour
    {
        public int count = 0;
        public GameManager gameManager;
        public ProgressBar progressBar;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject != null)
            {
                gameManager.PlaySound(3);
                other.gameObject.SetActive(false);
                count += 1;
                progressBar.IncreaseProgress();
                if (count == 25)
                {
                    //Debug.Log("Level 1 - Completed");
                    gameManager.LevelCompleted();
                    gameManager.Level1Win = true;
                }
            }
        }
    }
}
