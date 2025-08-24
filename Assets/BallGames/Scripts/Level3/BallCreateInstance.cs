using System.Collections;
using UnityEngine;

namespace BucketMove.Level_3
{
    public class BallCreateInstance : MonoBehaviour
    {
        public GameObject[] Balls;
        public float timeBetweenFalls = 1f; // Delay between ball drops
        public GameObject BallParent;
        private int currentBallIndex = 0;
        public GameObject Resetparent;
        public ProgressBar progressBar;
        public GameManager gameManager;
        public Level3Wincheck level3Wincheck;
        void OnEnable()
        {
            Resetfun();
        }
        private IEnumerator DropBalls()
        {
            while (currentBallIndex < Balls.Length)
            {
                if (Resetparent.transform.childCount <= 3)
                {
                    gameManager.LevelFailure();
                }
                GameObject ball = Balls[currentBallIndex].gameObject;
                ball.SetActive(true);
                ball.transform.SetParent(BallParent.transform);
                ball.gameObject.AddComponent<Rigidbody2D>();
                ball.gameObject.AddComponent<CircleCollider2D>();
                currentBallIndex++;
                yield return new WaitForSeconds(timeBetweenFalls);
            }
        }
        public void Resetfun()
        {
            level3Wincheck.Level3GlowReset();
            for (int m = 0; m < Balls.Length; m++)
            {
                if (Balls[m].GetComponent<Rigidbody2D>() != null)
                {
                    Rigidbody2D rb = Balls[m].GetComponent<Rigidbody2D>();
                    Collider2D col = Balls[m].GetComponent<Collider2D>();
                    DestroyImmediate(rb);
                    DestroyImmediate(col);
                    Balls[m].SetActive(false);
                    Balls[m].transform.SetParent(Resetparent.transform);
                    Balls[m].transform.localPosition = Vector3.zero;
                }
                else
                {
                    Balls[m].SetActive(false);
                    Balls[m].transform.SetParent(Resetparent.transform);
                    Balls[m].transform.localPosition = Vector3.zero;
                }
            }
            progressBar.ResetProgress();
            currentBallIndex = 0;
            StopAllCoroutines();
            StartCoroutine(DropBalls());
        }
    }
}
