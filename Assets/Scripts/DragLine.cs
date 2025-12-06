using System;
using UnityEngine;

public class DragLine : MonoBehaviour
{
    public LineRenderer lineRenderer;
    private Vector3 lostpostion;
    private bool dragging = false;

    [SerializeField] private LineDragConnect[] LineDragProcess;

    [Serializable]
    private class LineDragConnect
    {
        public int RightID = -1;
        public int LeftID = -1;
        public int TopID = -1;
        public int BottomID = -1;
        public bool RightSide;
        public bool LeftSide;
        public bool UpSide;
        public bool DownSide;
        public GameObject LeftObject;
        public GameObject RightObject;
        public GameObject TopObject;
        public GameObject BottomObject;
        public String Right,Left,UP,Down;
    }

    private float angle;
    private Vector2 startPos;
    private Vector2 dragVector;
    private Vector3 startWorldPos;
    private void OnMouseDown()
    {
        if (dragging) return;
        dragging = true;
        startWorldPos = transform.position;
        startPos = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        if (!dragging) return;

        dragVector = (Vector2)Input.mousePosition - startPos;

        if (dragVector.magnitude < 20f) return; // ignore tiny drags

        angle = Vector2.SignedAngle(Vector2.up, dragVector);

        CheckDirection();
    }

    private void OnMouseUp()
    {
        dragging = false;
    }

    // -------------------
    // ONLY 4 DIRECTIONS
    // -------------------
    private void CheckDirection()
    {
        if (angle > -45f && angle <= 45f)
        {
            UpMove();          // ↑ UP
        }
        else if (angle > 45f && angle <= 135f)
        {
           // RightMove();       // → RIGHT
           LeftMove();
        }
        else if (angle > 135f || angle <= -135f)
        {
            DownMove();        // ↓ DOWN
        }
        else if (angle > -135f && angle <= -45f)
        {
            //LeftMove();        // ← LEFT
            RightMove();
        }
    }

    private void UpMove()
    {
        foreach (var item in LineDragProcess)
        {
            if (item.TopID == -1 || item.UpSide)
            {
                Debug.Log("No place Up");
                return;
            }
            MoveTo(item.TopObject,ref item.UpSide,item.UP);
        }
    }

    private void RightMove()
    {
        foreach (var item in LineDragProcess)
        {
            if (item.RightID == -1 || item.RightSide)
            {
                Debug.Log("No place Right");
                return;
            }
            MoveTo(item.RightObject,ref item.RightSide,item.Right);
        }
    }

    private void LeftMove()
    {
        foreach (var item in LineDragProcess)
        {
            if (item.LeftID == -1 || item.LeftSide)
            {
                Debug.Log("No place Left");
                return;
            }
            MoveTo(item.LeftObject,ref item.LeftSide,item.Left);
        }
    }

    private void DownMove()
    {
        foreach (var item in LineDragProcess)
        {
            if (item.BottomID == -1 || item.DownSide)
            {
                Debug.Log("No place Down");
                return;
            }
            MoveTo(item.BottomObject,ref item.DownSide,item.Down);
        }
    }

    // -----------------------------------------------------
    // Moves object + draws a line to the new target position
    // -----------------------------------------------------
    private void MoveTo(GameObject target, ref bool targetbool, string name )
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f)
        );

        Vector3 targetPos = target.transform.position;

        if (Vector3.Distance(mouseWorldPos, targetPos) < 0.5f)
        {
            targetbool = true;   // NOW IT UPDATES CORRECTLY

            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, startWorldPos);
            lineRenderer.SetPosition(1, targetPos);

            // Update opposite side of target object
            DragLine targetDL = target.GetComponent<DragLine>();
            Debug.Log(targetDL.name);
            if(name == "UP")
                targetDL.LineDragProcess[0].DownSide = true;
            if (name == "Down")
                targetDL.LineDragProcess[0].UpSide = true;
             if (name == "Right")
                targetDL.LineDragProcess[0].LeftSide = true;
             if (name == "Left")
                targetDL.LineDragProcess[0].RightSide = true;
        }
    }


}
