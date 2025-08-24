using UnityEngine;

namespace BucketMove.Level_3
{
    public class Level3Wincheck : MonoBehaviour
    {
        public string[] BallOrderToCollect;
        public GameObject[] ColorGlows;
        public int count = 0;
        public ProgressBar progressBar;
        public GameManager gameManager;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject != null)
            {
                gameManager.PlaySound(3);
                if (count <= 10)
                {
                    if (other.gameObject.name == BallOrderToCollect[count])
                    {
                        other.gameObject.SetActive(false);
                        ColorGlows[count].SetActive(false);
                        count += 1;
                        if (count <= 10)
                        {
                            ColorGlows[count].SetActive(true);
                            progressBar.IncreaseProgress();
                            if (count == 10)
                            {
                                gameManager.LevelCompleted();
                                gameManager.Level3Win = true;
                            }
                        }
                    }
                    else
                    {
                        // Debug.Log("Wrong Ball Object");
                    }
                }
            }
        }
        public void Level3GlowReset()
        {
            count = 0;
            for (int m = 0; m < ColorGlows.Length; m++)
            {
                if (m == count)
                {
                    ColorGlows[m].SetActive(true);
                }
                else
                {
                    ColorGlows[m].SetActive(false);
                }
            }
        }
    }
}
