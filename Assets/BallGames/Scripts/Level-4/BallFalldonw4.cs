using System.Collections;
using UnityEngine;

namespace BucketMove.Level_4
{
    public class BallFalldonw4 : MonoBehaviour
    {
        public GameObject Ball;
        public float Duration = 1f;
        public GameObject ballparent;
        void Start()
        {
            StartCoroutine(Startballfall());
        }
        private IEnumerator Startballfall()
        {
            while (0 < Ball.transform.childCount)
            {
                for (int m = 0; m < Ball.transform.childCount; m++)
                {
                    if (Ball.transform.GetChild(m).gameObject != null)
                    {
                        //Instantiate(Ball.transform.GetChild(m).gameObject, Vector3.zero, Quaternion.identity);
                        Ball.transform.GetChild(m).gameObject.transform.SetParent(ballparent.transform);
                        Ball.transform.GetChild(m).gameObject.AddComponent<CircleCollider2D>();
                        Ball.transform.GetChild(m).gameObject.AddComponent<Rigidbody2D>();
                        yield return new WaitForSeconds(Duration);
                        if (m == Ball.transform.childCount)
                        {
                            StopAllCoroutines();
                        }
                    }
                }
            }
        }
    }
}
