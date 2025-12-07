using System;
using System.Collections.Generic;
using UnityEngine;

public class DragLine : MonoBehaviour
{
    //public LineRenderer lineRenderer;
    private Vector3 lostpostion;
    private bool dragging = false;
    public PlyerController plyerController;
    public Material Player1Material, Player2Material;
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
    private List<LineRenderer> createdLines = new List<LineRenderer>();
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
    private void MoveTo(GameObject target, ref bool targetbool, string direction)
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));

        Vector3 targetPos = target.transform.position;

        if (Vector3.Distance(mouseWorldPos, targetPos) < 0.5f)
        {
            targetbool = true;

            // Create a permanent line
            CreatePermanentLine(startWorldPos, targetPos);

            // Update neighbor
            DragLine targetDL = target.GetComponent<DragLine>();

            switch (direction)
            {
                case "UP":
                    targetDL.LineDragProcess[0].DownSide = true;
                    break;

                case "Down":
                    targetDL.LineDragProcess[0].UpSide = true;
                    break;

                case "Right":
                    targetDL.LineDragProcess[0].LeftSide = true;
                    break;

                case "Left":
                    targetDL.LineDragProcess[0].RightSide = true;
                    break;
            }
        }
    }

    private void CreatePermanentLine(Vector3 start, Vector3 end)
    {
        GameObject newLine = new GameObject("ConnectionLine");
        LineRenderer lr = newLine.AddComponent<LineRenderer>();

        lr.startWidth = 0.5f;
        lr.endWidth = 0.5f;
        lr.sortingOrder = 5;
        // Assign material (use your own)
        if(!plyerController.Player1)
        {
            plyerController.Player1 = true;
            plyerController.Player2 = false;
            lr.material = Player1Material;
        }
        else if(!plyerController.Player2)
        {
            plyerController.Player1 = false;
            plyerController.Player2 = true;
            lr.material = Player2Material;
        }

        lr.positionCount = 2;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);

        createdLines.Add(lr);
        AddColliderToLine(lr, newLine);
    }
    private void AddColliderToLine(LineRenderer lr, GameObject lineObject)
    {
        EdgeCollider2D edge = lineObject.AddComponent<EdgeCollider2D>();

        int count = lr.positionCount;
        Vector2[] points = new Vector2[count];
        edge.isTrigger = true;
        for (int i = 0; i < count; i++)
        {
            Vector3 worldPos = lr.GetPosition(i);
            points[i] = new Vector2(worldPos.x, worldPos.y);
        }

        edge.points = points;
        edge.edgeRadius = 0.05f;  // Thickness of collision
    }

}
