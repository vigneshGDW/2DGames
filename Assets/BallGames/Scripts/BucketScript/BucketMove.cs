using UnityEngine;

namespace BucketMove.Level_1
{
    public class BucketMove : MonoBehaviour
    {
        public Camera cam;
        public Transform leftLimit;   // Drag limit on the left
        public Transform rightLimit;  // Drag limit on the right

        private Vector3 startMousePos;
        private Vector3 startObjectPos;

        void OnMouseDown()
        {
            startMousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            startObjectPos = transform.position;
        }

        void OnMouseDrag()
        {
            Vector3 currentMousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            float deltaX = currentMousePos.x - startMousePos.x;

            float targetX = startObjectPos.x + deltaX;

            // Clamp X position between leftLimit.x and rightLimit.x
            targetX = Mathf.Clamp(targetX, leftLimit.position.x, rightLimit.position.x);

            transform.position = new Vector3(targetX, startObjectPos.y, startObjectPos.z);
        }
    }
}
