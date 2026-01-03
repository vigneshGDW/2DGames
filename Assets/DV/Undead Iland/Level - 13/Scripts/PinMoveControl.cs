using Unity.Mathematics;
using UnityEngine;

public class PinMoveControl : MonoBehaviour
{
    [Header("Restriction Points")]
    [SerializeField] private Transform TopRestrictionPoint;
    [SerializeField] private Transform BottomRestrictionPoint;
    [SerializeField] private Transform LeftRestrictionPoint;
    [SerializeField] private Transform RightRestrictionPoint;

    [Header("Rotation")]
    [SerializeField] private float TopsideGoRotationvalue = 35f;
    [SerializeField] private float DownsideGoRotationvalue = -35f;
    [SerializeField] private GameObject pinParent;

    [Header("References")]
    [SerializeField] private Camera PuzzleCamera;

    [Header("Drag Settings")]
    [SerializeField] private float dragSpeed = 6f;

    private Vector3 startWorldPos;
    private Vector3 mouseOffset;

    private float startRotationZ;
    private float snapDistance = 0.5f;
    [SerializeField] private GameObject DefenceCircle1,DefenceCircle2,DefenceCircle3;
    [SerializeField] private float defenceRotateSpeed = 30f;
    [SerializeField] private bool invertRotation = false;
    private float lastY;
    void OnMouseDown()
    {
        if(CommonTagsContainer.Instance.itsnotmoveplace) return;
        startWorldPos = transform.position;

        // store current rotation
        lastY = transform.position.y;
        startRotationZ = pinParent.transform.localEulerAngles.z;
        startRotationZ = NormalizeAngle(startRotationZ);

        Vector3 mouseWorld =
            PuzzleCamera.ScreenToWorldPoint(new Vector3(
                Input.mousePosition.x,
                Input.mousePosition.y,
                PuzzleCamera.WorldToScreenPoint(transform.position).z));

        mouseOffset = transform.position - mouseWorld;
    }

    void OnMouseDrag()
    {
        if(CommonTagsContainer.Instance.itsnotmoveplace) return;
        Vector3 mouseWorld =
            PuzzleCamera.ScreenToWorldPoint(new Vector3(
                Input.mousePosition.x,
                Input.mousePosition.y,
                PuzzleCamera.WorldToScreenPoint(transform.position).z));

        Vector3 targetPos = mouseWorld + mouseOffset;

        // Clamp movement
        targetPos.x = Mathf.Clamp(
            targetPos.x,
            LeftRestrictionPoint.position.x,
            RightRestrictionPoint.position.x);

        targetPos.y = Mathf.Clamp(
            targetPos.y,
            BottomRestrictionPoint.position.y,
            TopRestrictionPoint.position.y);

        transform.position = Vector3.Lerp(
            transform.position,
            targetPos,
            dragSpeed * Time.deltaTime);

        //ApplyRotation();
        RotateActiveDefenceCircles();
        transform.localRotation = Quaternion.identity;
    }

    void ApplyRotation()
    {
        float minY = BottomRestrictionPoint.position.y;
        float maxY = TopRestrictionPoint.position.y;

        // Calculate how far we are between bottom and top
        float percent = Mathf.InverseLerp(minY, maxY, transform.position.y);

        // Map percent to rotation range
        float finalRotation = Mathf.Lerp(
            DownsideGoRotationvalue,
            TopsideGoRotationvalue,
            percent);

        pinParent.transform.localRotation =
            Quaternion.Euler(0, 0, finalRotation);
    }


    void OnMouseUp()
    {
        if (Vector3.Distance(transform.position, TopRestrictionPoint.position) <= snapDistance)
        {
            transform.position = TopRestrictionPoint.position;
            pinParent.transform.localRotation =
                Quaternion.Euler(0, 0, TopsideGoRotationvalue);
        }
        else if (Vector3.Distance(transform.position, BottomRestrictionPoint.position) <= snapDistance)
        {
            transform.position = BottomRestrictionPoint.position;
            pinParent.transform.localRotation =
                Quaternion.Euler(0, 0, DownsideGoRotationvalue);
        }
        CommonTagsContainer.Instance.itsnotmoveplace = false;
    }

    float NormalizeAngle(float angle)
    {
        if (angle > 180f) angle -= 360f;
        return angle;
    }
    void RotateActiveDefenceCircles()
    {
        float currentY = transform.position.y;
        float deltaY = currentY - lastY;

        if (Mathf.Abs(deltaY) < 0.001f)
            return;

        float direction = Mathf.Sign(deltaY);

        if (invertRotation)
            direction *= -1f;

        // Rotate ALL active circles
        if (CommonTagsContainer.Instance.defence1bool)
            RotateCircle(DefenceCircle1, direction);

        if (CommonTagsContainer.Instance.defence2bool)
            RotateCircle(DefenceCircle2, direction);

        if (CommonTagsContainer.Instance.defence3bool)
            RotateCircle(DefenceCircle3, direction);

        lastY = currentY;
    }


    void RotateCircle(GameObject circle, float direction)
    {
        if (circle == null) return;

        circle.transform.Rotate(
            0f,
            0f,
            direction * defenceRotateSpeed * Time.deltaTime
        );
    }

}

