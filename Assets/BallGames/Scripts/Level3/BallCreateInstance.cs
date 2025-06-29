using System.Collections;
using UnityEngine;

namespace BucketMove.Level_3
{
    public class BallCreateInstance : MonoBehaviour
    {
        public GameObject[] Balls;
        public float timeBetweenFalls = 1f; // Delay between ball drops
        public float customGravityScale = 1f; // Adjust fall speed

        private Transform ballContainerInstance;
        private int currentBallIndex = 0;

        private void Start()
        {
            StartCoroutine(DropBalls());
        }

        private IEnumerator DropBalls()
        {
            while (currentBallIndex < Balls.Length)
            {
                GameObject ball = Balls[currentBallIndex].gameObject;
                ball.SetActive(true);
                ball.gameObject.AddComponent<Rigidbody2D>();
                ball.gameObject.AddComponent<CircleCollider2D>();
                currentBallIndex++;
                yield return new WaitForSeconds(timeBetweenFalls);
            }
        }
    }
}
