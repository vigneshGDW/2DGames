using System.Collections;
using UnityEngine;

namespace BucketMove.Level_2
{
    public class BallObjectFall2 : MonoBehaviour
    {
        public GameObject[] ColorBalls;
        public float delayBetweenBalls = 1f;
        public GameObject Parntobj;
        public GameObject[] ColorBallsresetpropes;
        public Wincheck2 ballwin;
        public GameObject Resetparent;
        public GameManager gameManager;

        void OnEnable()
        {
            Level2Resetfun();
        }

        private IEnumerator FalldownAllBalls(GameObject[] Balls)
        {
            for (int i = 0; i < Balls.Length; i++)
            {
                if(Resetparent.transform.childCount <= 3)
                {
                    gameManager.LevelFailure();
                }
                GameObject ball = Balls[i];

                if (ball == null)
                    continue;

                ball.SetActive(true);

                // Add Rigidbody2D if missing
                if (!ball.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb))
                {
                    rb = ball.AddComponent<Rigidbody2D>();
                }
                rb.gravityScale = 1f;

                // Add CircleCollider2D if missing
                if (!ball.GetComponent<CircleCollider2D>())
                {
                    ball.AddComponent<CircleCollider2D>();
                    ball.GetComponent<CircleCollider2D>().radius = 350f;
                }

                // Set parent
                if (Parntobj != null)
                {
                    ball.transform.SetParent(Parntobj.transform);
                }

                yield return new WaitForSeconds(delayBetweenBalls);
            }
        }

        private void Level2Resetfun()
        {
            ballwin.count = 0;

            if (ColorBalls != null)
            {
                foreach (var ball in ColorBalls)
                {
                    if (ball == null)
                        continue;

                    // Remove Rigidbody2D
                    if (ball.TryGetComponent<Rigidbody2D>(out var rb))
                        Destroy(rb);

                    // Remove CircleCollider2D
                    if (ball.TryGetComponent<CircleCollider2D>(out var col))
                        Destroy(col);

                    // Reparent and reset
                    if (Parntobj != null && Resetparent != null)
                    {
                        ball.transform.SetParent(Resetparent.transform);
                        ball.transform.localPosition = Vector3.zero;
                    }
                }
            }

            // Refresh the ColorBalls array
            ColorBalls = new GameObject[ColorBallsresetpropes.Length];
            for (int m = 0; m < ColorBallsresetpropes.Length; m++)
            {
                ColorBalls[m] = ColorBallsresetpropes[m];
            }

            // Reset UI/progress
            ballwin.progressBar.ResetProgress();

            // Restart ball logic
            StopAllCoroutines();
            StartCoroutine(FalldownAllBalls(ColorBalls));
        }
    }
}
