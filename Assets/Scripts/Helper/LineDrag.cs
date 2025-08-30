using UnityEngine;

public class LineDrag : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3 startPos;
    private Camera cam;

    [SerializeField] private Transform[] connectableObjects; // Allowed objects
    private Transform nearestTarget;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        cam = Camera.main;
    }

    void OnMouseDown()
    {
        startPos = transform.position;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, startPos);

        nearestTarget = null;
    }

    void OnMouseDrag()
    {
        Vector3 mouseWorld = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0f;

        Vector3 direction = mouseWorld - startPos;

        // Decide axis lock
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            // Horizontal lock
            nearestTarget = GetNearestTarget(Vector2.right * Mathf.Sign(direction.x));
            if (nearestTarget != null)
            {
                float clampedX = Mathf.Clamp(mouseWorld.x,
                                             Mathf.Min(startPos.x, nearestTarget.position.x),
                                             Mathf.Max(startPos.x, nearestTarget.position.x));

                lineRenderer.SetPosition(1, new Vector3(clampedX, startPos.y, 0));
            }
        }
        else
        {
            // Vertical lock
            nearestTarget = GetNearestTarget(Vector2.up * Mathf.Sign(direction.y));
            if (nearestTarget != null)
            {
                float clampedY = Mathf.Clamp(mouseWorld.y,
                                             Mathf.Min(startPos.y, nearestTarget.position.y),
                                             Mathf.Max(startPos.y, nearestTarget.position.y));

                lineRenderer.SetPosition(1, new Vector3(startPos.x, clampedY, 0));
            }
        }
    }

    void OnMouseUp()
    {
        if (nearestTarget != null)
        {
            // Snap to object
            lineRenderer.SetPosition(1, nearestTarget.position);
            Debug.Log("Connected to: " + nearestTarget.name);
        }
        else
        {
            // Reset
            lineRenderer.SetPosition(1, startPos);
            Debug.Log("No valid connection");
        }
    }

    // Find the nearest connectable object in a given direction
    private Transform GetNearestTarget(Vector2 dir)
    {
        Transform nearest = null;
        float nearestDist = float.MaxValue;

        foreach (Transform obj in connectableObjects)
        {
            Vector2 diff = obj.position - startPos;

            // Must be in the same direction (dot > 0 means forward)
            if (Vector2.Dot(diff, dir) > 0.1f)
            {
                float dist = diff.magnitude;
                if (dist < nearestDist)
                {
                    nearest = obj;
                    nearestDist = dist;
                }
            }
        }

        return nearest;
    }
}
