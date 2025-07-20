using System.Collections;
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
        void OnEnable()
        {
            Level1Resetfun();
        }
        private IEnumerator FalldownAllBalls(GameObject[] Balls)
        {
            for (int i = 0; i < Balls.Length; i++)
            {
                GameObject ball = Balls[i];
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
                    if (ColorBalls[i] != null)
                    {
                        Destroy(ColorBalls[i]);
                    }
                }
            }
            ColorBalls = new GameObject[ColorBallsresetpropes.Length];
            for (int m = 0; m < ColorBallsresetpropes.Length; m++)
            {
                ColorBalls[m] = ColorBallsresetpropes[m];
            }
            StartCoroutine(FalldownAllBalls(ColorBalls));
        }

    }
}
