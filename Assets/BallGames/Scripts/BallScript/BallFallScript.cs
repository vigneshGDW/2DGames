using System.Collections;
using System.Numerics;
using UnityEngine;

namespace BucketMove.Level_1
{
    public class BallFallScript : MonoBehaviour
    {
        public GameObject[] ColorBalls;
        public float delayBetweenBalls = 1f;
        public GameObject Parntobj;
        public GameObject[] ColorBallsresetpropes;
        public BallCollect ballCollect;
        public BallDeative ballDeative;
        public GameObject Resetparent;
        void OnEnable()
        {
            Level1Resetfun();
        }
        private IEnumerator FalldownAllBalls(GameObject[] Balls)
        {
            for (int i = 0; i < Balls.Length; i++)
            {
                GameObject ball = Balls[i];
                ball.SetActive(true);
                if (!ball.GetComponent<Rigidbody2D>())
                {
                    ball.AddComponent<Rigidbody2D>();
                    ball.GetComponent<Rigidbody2D>().gravityScale = 1f;
                }
                if (!ball.GetComponent<CircleCollider2D>())
                {
                    ball.AddComponent<CircleCollider2D>();
                }
                if (Parntobj != null)
                {
                    ball.transform.SetParent(Parntobj.transform);
                }
                yield return new WaitForSeconds(delayBetweenBalls);
            }
        }
        private void Level1Resetfun()
        {
            ballCollect.count = 0;
            ballDeative.count = 0;

            if (ColorBalls != null)
            {
                for (int i = 0; i < ColorBalls.Length; i++)
                {
                    GameObject ball = ColorBalls[i];

                    if (ball != null)
                    {
                        // Remove Rigidbody2D if exists
                        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
                        if (rb != null)
                            Destroy(rb);

                        // Remove CircleCollider2D if exists
                        CircleCollider2D col = ball.GetComponent<CircleCollider2D>();
                        if (col != null)
                            Destroy(col);

                        // Reparent and reset position
                        if (Parntobj != null && Resetparent != null)
                        {
                            ball.transform.SetParent(Resetparent.transform);
                            ball.transform.localPosition = UnityEngine.Vector3.zero;
                        }
                    }
                }
            }

            // Reset the ColorBalls array
            ColorBalls = new GameObject[ColorBallsresetpropes.Length];
            for (int m = 0; m < ColorBallsresetpropes.Length; m++)
            {
                ColorBalls[m] = ColorBallsresetpropes[m];
            }

            // Reset progress and restart logic
            ballCollect.progressBar.ResetProgress();
            StopAllCoroutines();
            StartCoroutine(FalldownAllBalls(ColorBalls));
        }


    }
}
