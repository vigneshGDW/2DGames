using System.Collections;
using UnityEngine;

namespace BucketMove.Level_1
{
    public class BallFallScript : MonoBehaviour
    {
        public GameObject[] ColorBalls;
        public float delayBetweenBalls = 1f;
        void Start()
        {
            StartCoroutine(FalldownAllBalls(ColorBalls));
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
                yield return new WaitForSeconds(delayBetweenBalls);
            }
        }
    }
}
