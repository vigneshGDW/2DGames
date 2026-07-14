using UnityEngine;

public class Slingshot : MonoBehaviour
{
    [Header("Anchors & Visuals")]
    public Transform leftAnchor;
    public Transform rightAnchor;
    public Transform centerPoint; // Center point between both anchors

    [Header("Projectile")]
    public Rigidbody2D stoneRb; // Assign your stone bullet here

    [Header("Settings")]
    public float maxDragDistance = 3.5f;
    public float launchForce = 12f;

    private LineRenderer lineRenderer;
    public Camera mainCamera;
    private bool isDragging;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        mainCamera = Camera.main;

        // Start with the band snapped to the center point
        UpdateLineRenderer(centerPoint.position);
        
        // Put the stone at the center point initially
        if (stoneRb != null)
        {
            stoneRb.transform.position = centerPoint.position;
            stoneRb.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    void Update()
    {
        if (isDragging)
        {
            // Get mouse position in world space
            Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0; 

            // Calculate the vector from the center point to the mouse
            Vector3 dragVector = mousePos - centerPoint.position;

            // Clamp the distance so the band doesn't stretch forever
            if (dragVector.magnitude > maxDragDistance)
            {
                dragVector = dragVector.normalized * maxDragDistance;
            }

            // Calculate where the center pouch should actually move to
            Vector3 finalPouchPosition = centerPoint.position + dragVector;

            // Update the band positions in real-time
            UpdateLineRenderer(finalPouchPosition);

            // Move the stone along with the pouch
            if (stoneRb != null)
            {
                stoneRb.transform.position = finalPouchPosition;
            }
        }
    }

    private void OnMouseDown()
    {
        isDragging = true;

        // Ensure the stone doesn't fall while dragging
        if (stoneRb != null)
        {
            stoneRb.bodyType = RigidbodyType2D.Kinematic;
            stoneRb.linearVelocity = Vector2.zero; 
        }
    }

    private void OnMouseUp()
    {
        if (!isDragging) return;
        isDragging = false;

        if (stoneRb != null)
        {
            // AIM DIRECTION MATH: Target Center minus Current Pouch Position
            Vector2 launchDirection = (Vector2)centerPoint.position - (Vector2)stoneRb.transform.position;
            CircleCollider2D stoneCollider = stoneRb.GetComponent<CircleCollider2D>();
            stoneCollider.enabled = true; // Enable the stone's collider so it can interact with other objects

            // Turn on normal physics so gravity and forces apply to the stone
            stoneRb.bodyType = RigidbodyType2D.Dynamic;

            // Throw the stone! (Using modern Unity linearVelocity)
            stoneRb.linearVelocity = launchDirection * launchForce;
        }

        // Snap the rubber band instantly back to the center
        UpdateLineRenderer(centerPoint.position);
    }

    void UpdateLineRenderer(Vector3 pouchPosition)
    {
        lineRenderer.SetPosition(0, leftAnchor.position);
        lineRenderer.SetPosition(1, pouchPosition);
        lineRenderer.SetPosition(2, rightAnchor.position);
    }
}