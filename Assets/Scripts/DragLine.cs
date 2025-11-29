using UnityEngine;

public class DragLine : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform Startpoint;
    public Transform Endpoint;
    public GameObject[] NearestPlace;

    private void OnMouseDown()
    {
        Startpoint = transform;
    }
    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Assuming a 2D game, set z to 0
        Endpoint.position = mousePosition;

        lineRenderer.SetPosition(0, Startpoint.position);
        lineRenderer.SetPosition(1, Endpoint.position);
    }

}
