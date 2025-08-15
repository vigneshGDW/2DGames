using System.Collections;
using UnityEngine;

namespace BucketMove.Level_4
{
    public class BallMove : MonoBehaviour
    {
        public GameObject Postion1;
        public GameObject Postion2;
        public float Duration = 1.0f;
        public float WaitTime = 0.2f; // small pause before changing direction
        public bool reach1 = false;
        public GameObject BallMoveparent;

        void OnEnable()
        {
            StartCoroutine(BallMoveLefttoRight());
        }

        private IEnumerator BallMoveLefttoRight()
        {
            while (true)
            {
                Vector2 startPos = BallMoveparent.transform.position;
                Vector2 endPos = reach1 ? Postion1.transform.position : Postion2.transform.position;

                float elapsedTime = 0f;
                while (elapsedTime < Duration)
                {
                    float t = elapsedTime / Duration;
                    BallMoveparent.transform.position = Vector2.Lerp(startPos, endPos, t);
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }

                BallMoveparent.transform.position = endPos;

                // Switch target
                reach1 = !reach1;

                // Optional small wait
                yield return new WaitForSeconds(WaitTime);
            }
        }
    }
}
