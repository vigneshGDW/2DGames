using System;
using System.Collections;
using UnityEngine;

public class RightPinMovesControls : MonoBehaviour
{
    [SerializeField] private GameObject Pinobject;
     public int currentPointPlace;
    [SerializeField] private PointPostions[] pointPostions;
    [SerializeField] private GameObject[] AllMovePoints;

    [Serializable]
    private class PointPostions
    {
        public int UpPoint;    // index in AllMovePoints (-1 = no move)
        public int DownPoint;  // index in AllMovePoints (-1 = no move)
    }

   // private bool isMoving = false;
    private Vector2 startMousePos;
    [SerializeField] private GameObject PinParent;

    //Defence1 
    [SerializeField] private GameObject Defence1Circle;
    [SerializeField] private int MoveValueofRotation = 14;
    [SerializeField] private UnlockManager unlockManager;
    public bool isLeftPin,isRightpin;
    [SerializeField] private GameObject Defenc1acceassaea1,Defenc1acceassaea2,DefenceInsideare1,DefenceInsideare2;
   // private float defenceBaseZ = 90f;
    public PinMovesControls pinMovesControls;
    private bool iswheelfixed = false;
    private void OnMouseDown()
    {
        if (unlockManager.ismove) return;
        startMousePos = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        if (unlockManager.ismove) return;

        Vector2 dragDelta = (Vector2)Input.mousePosition - startMousePos;

        float absX = Mathf.Abs(dragDelta.x);
        float absY = Mathf.Abs(dragDelta.y);

        float threshold = 30f;

        // Decide whether the drag is horizontal or vertical
        if (absX > absY)
        {
            if (absX < threshold) return;

            if (dragDelta.x > 0)
                TryMoveRight();
            else
                TryMoveLeft();
        }
        else
        {
            if (absY < threshold) return;

            if (dragDelta.y > 0)
                TryMoveUp();
            else
                TryMoveDown();
        }
    }


    private void TryMoveUp()
    {
        if(unlockManager.Leftpin && (pinMovesControls.currentPointPlace  == 0 || pinMovesControls.currentPointPlace == 4) && iswheelfixed)
        {
            return;
        }

        if (unlockManager.Defence1NowRotate && iswheelfixed)
        {
            int nextIndex = pointPostions[currentPointPlace].UpPoint;
            if (nextIndex < 0 || nextIndex >= AllMovePoints.Length) return;
            StartCoroutine(
                RotateWheels(Defence1Circle, true, nextIndex) // ONLY +
            );
            return;
        }

        int moveIndex = pointPostions[currentPointPlace].UpPoint;
        if (moveIndex < 0 || moveIndex >= AllMovePoints.Length) return;

        StartCoroutine(MovePin(AllMovePoints[moveIndex], moveIndex));
    }

    private void TryMoveDown()
    {
        if(unlockManager.Leftpin && (pinMovesControls.currentPointPlace  == 0 || pinMovesControls.currentPointPlace == 4) && iswheelfixed)
        {
            return;
        }
        if (unlockManager.Defence1NowRotate && iswheelfixed)
        {
            int nextIndex = pointPostions[currentPointPlace].DownPoint;
            if (nextIndex < 0 || nextIndex >= AllMovePoints.Length) return;
            StartCoroutine(
                RotateWheels(Defence1Circle, false, nextIndex) // ONLY -
            );
            return;
        }

        int moveIndex = pointPostions[currentPointPlace].DownPoint;
        if (moveIndex < 0 || moveIndex >= AllMovePoints.Length) return;

        StartCoroutine(MovePin(AllMovePoints[moveIndex], moveIndex));
    }


    private IEnumerator MovePin(GameObject targetObj, int newIndex)
    {
        unlockManager.ismove = true;

        Vector3 startPos = PinParent.transform.position;
        Vector3 targetPos = targetObj.transform.position;

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 5f;
            PinParent.transform.position = Vector3.Lerp(startPos, targetPos, t);
            yield return null;
        }

        // Snap & parent
        PinParent.transform.SetParent(targetObj.transform);
        PinParent.transform.localPosition = Vector3.zero;
        PinParent.transform.localRotation = Quaternion.identity;

        currentPointPlace = newIndex; // ✅ FINAL update
        unlockManager.ismove = false;
    }
    private void TryMoveRight()
    {
        //Debug.Log("Right");
        if(unlockManager.Leftpin) return;
        if(isLeftPin)
        {
            float z = Mathf.DeltaAngle(0f, Defence1Circle.transform.eulerAngles.z);
           
        }
        else if(isRightpin)
        {
            float z = Mathf.DeltaAngle(0f, Defence1Circle.transform.eulerAngles.z);
             if(Mathf.Abs(z - 118) < 1f && currentPointPlace == 4)
            {
                StartCoroutine(
                    LeftandRightMovePin(AllMovePoints[4], 4)
                );
                unlockManager.Defence1NowRotate = false;
                unlockManager.Rightpin = false;
                iswheelfixed = false;
            }
            else if(Mathf.Abs(z - 132) < 1f && currentPointPlace == 3)
            {
                StartCoroutine(
                    LeftandRightMovePin(AllMovePoints[3], 3)
                );
                unlockManager.Defence1NowRotate = false;
                unlockManager.Rightpin = false;
                iswheelfixed = false;
            }
            else if(Mathf.Abs(z - 146) < 1f && currentPointPlace == 0)
            {
                StartCoroutine(
                    LeftandRightMovePin(AllMovePoints[0], 0)
                );
                unlockManager.Defence1NowRotate = false;
                unlockManager.Rightpin = false;
                iswheelfixed = false;
            }
            else if(Mathf.Abs(z - 160) < 1f && currentPointPlace == 1)
            {
                StartCoroutine(
                    LeftandRightMovePin(AllMovePoints[1], 1)
                );
                unlockManager.Defence1NowRotate = false;
                unlockManager.Rightpin = false;
                iswheelfixed = false;
            }
            else if(Mathf.Abs(z - 174) < 1f && currentPointPlace == 2)
            {
                StartCoroutine(
                    LeftandRightMovePin(AllMovePoints[2], 2)
                );
                unlockManager.Defence1NowRotate = false;
                unlockManager.Rightpin = false;
                iswheelfixed = false;
            }
        }
    }
    private void TryMoveLeft()
    {
        //Debug.Log("Left");
        if(unlockManager.Leftpin) return;
        if(isLeftPin)
        {
            
        }
        else if(isRightpin)
        {
            float z = Mathf.DeltaAngle(0f, Defence1Circle.transform.eulerAngles.z);
            if(Mathf.Abs(z - 118) < 1f && currentPointPlace == 4)
            {
                StartCoroutine(
                    LeftandRightMovePin(Defenc1acceassaea1, 4)
                );
                unlockManager.Defence1NowRotate = true;
                unlockManager.Rightpin = true;
                iswheelfixed = true;
            }
            else if(Mathf.Abs(z - 132) < 1f && currentPointPlace == 3)
            {
                StartCoroutine(
                    LeftandRightMovePin(Defenc1acceassaea1, 3)
                );
                unlockManager.Defence1NowRotate = true;
                unlockManager.Rightpin = true;
                iswheelfixed = true;
            }
            else if(Mathf.Abs(z - 146) < 1f && currentPointPlace == 0)
            {
                StartCoroutine(
                    LeftandRightMovePin(Defenc1acceassaea1, 0)
                );
                unlockManager.Defence1NowRotate = true;
                unlockManager.Rightpin = true;
                iswheelfixed = true;
            }
            else if(Mathf.Abs(z - 160) < 1f && currentPointPlace == 1)
            {
                StartCoroutine(
                    LeftandRightMovePin(Defenc1acceassaea1, 1)
                );
                unlockManager.Defence1NowRotate = true;
                unlockManager.Rightpin = true;
                iswheelfixed = true;
            }
            else if(Mathf.Abs(z - 174) < 1f && currentPointPlace == 2)
            {
                StartCoroutine(
                    LeftandRightMovePin(Defenc1acceassaea1, 2)
                );
                unlockManager.Defence1NowRotate = true;
                unlockManager.Rightpin = true;
                iswheelfixed = true;
            }
        }
    }
    private IEnumerator LeftandRightMovePin(GameObject targetObj, int newIndex)
    {
        unlockManager.ismove = true;

        Vector3 startPos = PinParent.transform.position;
        Vector3 targetPos = targetObj.transform.position;

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 5f;
            PinParent.transform.position = Vector3.Lerp(startPos, targetPos, t);
            yield return null;
        }

        // Snap & parent
        PinParent.transform.SetParent(targetObj.transform);
        PinParent.transform.localPosition = Vector3.zero;

       // currentPointPlace = newIndex; // ✅ FINAL update
        unlockManager.ismove = false;
    }
    private IEnumerator RotateWheels(GameObject DefenceCircle, bool rotateUp, int updateindex)
    {
        unlockManager.ismove = true;

        // current Z (normalized)
        float startZ = DefenceCircle.transform.eulerAngles.z;

        // decide direction strictly
        float targetZ = rotateUp
            ? startZ + MoveValueofRotation   // +13 ONLY
            : startZ - MoveValueofRotation;  // -13 ONLY

        float elapsed = 0f;
        float duration = 0.5f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            float z = Mathf.LerpAngle(startZ, targetZ, t);
            DefenceCircle.transform.rotation = Quaternion.Euler(0f, 0f, z);

            yield return null;
        }

        // snap
        DefenceCircle.transform.rotation = Quaternion.Euler(0f, 0f, targetZ);

        // ✅ UPDATE BASE ANGLE so next rotation continues
        //defenceBaseZ = targetZ;

        currentPointPlace = updateindex;
        unlockManager.ismove = false;
    }
}
