using UnityEngine;

public class CameraZoomer : MonoBehaviour
{
    public float followSpeed = 5f; // Speed at which the camera moves toward the mouse position
    public float zoomSpeed = 2f;   // Speed at which the camera zooms
    public float targetFoV = 30f;  // Target Field of View for the zoom-in effect
    public float defaultFoV = 60f; // Default Field of View when not zoomed
    public float zoomLerpSpeed = 5f; // Speed of zoom transition
    public float movementScale = 0.1f; // Scale for camera movement relative to the mouse position

    private Camera cam;           // Reference to the Camera component
    private bool isZooming = false; // Whether the camera is currently zooming in
    private Vector3 initialPosition; // Initial position of the camera

    void Start()
    {
        cam = Camera.main;
        

        // Set the initial Field of View
        cam.fieldOfView = defaultFoV;
    }

    void Update(){
        initialPosition = transform.position;
        // Adjust Field of View for zooming
        float targetFoVValue = isZooming ? targetFoV : defaultFoV;
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, targetFoVValue, zoomLerpSpeed * Time.deltaTime);
        if (Input.GetMouseButton(1)) // Right mouse button
        {
            isZooming = true;
        }
        else
        {
            isZooming = false;
        }
        if (isZooming == false){return ;}

        return;
        // Get the mouse position in screen space
        Vector3 mouseScreenPosition = Input.mousePosition;

        // Calculate normalized mouse position relative to the screen's center (-1 to 1 range)
        Vector3 normalizedMousePosition = new Vector3(
            (mouseScreenPosition.x / Screen.width) - 0.5f,
            (mouseScreenPosition.y / Screen.height) - 0.5f,
            0
        ) * 2f; // Scale to get -1 to 1 range for both axes

        // Calculate the target position for parallax effect
        Vector3 targetPosition = initialPosition + new Vector3(
            normalizedMousePosition.x * movementScale,
            normalizedMousePosition.y * movementScale,
            0
        );

        // Smoothly move the camera toward the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Zoom in when holding the right mouse button
        


    }
}
