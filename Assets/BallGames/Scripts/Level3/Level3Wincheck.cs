using UnityEngine;

namespace BucketMove.Level_3
{
    public class Level3Wincheck : MonoBehaviour
    {
        public string[] BallOrderToCollect;
        public GameObject[] ColorGlows;
        public int count = 0;
        public ProgressBar progressBar;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject != null)
            {
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
                        }
                    }
                    else
                    {
                        // Debug.Log("Wrong Ball Object");
                    }
                }
            }
        }
    }
}
