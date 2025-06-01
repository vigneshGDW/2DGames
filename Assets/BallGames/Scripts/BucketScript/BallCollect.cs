using UnityEngine;

namespace BucketMove.Level_1
{
    public class BallCollect : MonoBehaviour
    {
        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject != null)
            {
                other.gameObject.SetActive(false);
            }
        }
    }
}
