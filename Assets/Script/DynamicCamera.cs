using UnityEngine;

public class DynamicCamera : MonoBehaviour
{
    public Transform StartPoint;
    public Transform EndPoint;
    public Transform CameraTarget;
    public LineRenderer LineRenderer;


    // Speed of the camera movement
    public float speed = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Set the camera to view both points
        SetCameraPositionAndZoom();
    }

    // Update is called once per frame
    void Update()
    {
        // Optionally, you can update the camera position and zoom in real-time
        SetCameraPositionAndZoom();
    }

    private void SetCameraPositionAndZoom()
    {
        // Calculate the midpoint between StartPoint and EndPoint
        Vector3 midpoint = (StartPoint.position + EndPoint.position) / 2;

        // Calculate the distance between StartPoint and EndPoint
        float distance = Vector3.Distance(StartPoint.position, EndPoint.position);
        LineRenderer.textureScale = new Vector2(distance, 1); // Set the texture scale
        // Set the camera position to the midpoint, adjusting the height as needed
        CameraTarget.GetComponent<Camera>().transform.position = new Vector3(midpoint.x , (midpoint.y + distance / 2)+5, midpoint.z );

        // Adjust the camera's field of view based on the distance
        CameraTarget.GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, 60 + (distance * 10), Time.deltaTime); // Adjust the multiplier as needed
    }
}
