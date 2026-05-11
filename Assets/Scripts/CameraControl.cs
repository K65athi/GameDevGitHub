using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements.Experimental;

public class CameraControl : MonoBehaviour
{
    [SerializeField] bool CanControll;
    [SerializeField] private Vector3 CenterPoint;
    [SerializeField] private float MaxDistanceFromCenter;
    [Header("Camera Movement")]
    [SerializeField] private float moveSpeed = 150;

    // optional Mouse movement
     /*
    [Header("Mouse Edge Movement")]
    [SerializeField] private float EdgeMovementSpeed = 15;
    [SerializeField] private float MouseEdgeMovement = 10;
    */
    private float ScreenWidth;
    private float ScreenHeight; 

    [Header("Camera Rotation")]
    [SerializeField] private Transform Crosshair;
    [SerializeField] private float maxCrosshairDistance = 15;
    [SerializeField] private float rotationSpeed = 300;
    private float pitch;
    private float minpitch = 5f;
    private float maxpitch = 85f;

    [Header("Camera Zoom")]
    [SerializeField] private float ZoomSpeed = 10;
    [SerializeField] private float MinZoom = 5;
    [SerializeField] private float MaxZoom = 20;


    private float smoothTime = 0.1f;
    private Vector3 velocity = Vector3.zero;
    private Vector3 ZoomVelocity = Vector3.zero;
    private Vector3 EdgeVelocity = Vector3.zero;

    void Start()
    {
        ScreenWidth = Screen.width;
        ScreenHeight = Screen.height;
    }

    void Update()
    {
        if (CanControll == false)
            return;
        HandleRotation();
        HandleZoom();
        HandleMovement();
        //HandleMouseEdgeMovement();

        Crosshair.position = transform.position + (transform.forward * GetCrosshairDistance());
    }

    public void EnableCameraControlls(bool enable) => CanControll = enable;
    public float AdjustPitch(float value) => pitch = value;

    private void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 ZoomDirection = transform.forward * scroll * ZoomSpeed;
        Vector3 targetpos = transform.position + ZoomDirection;

        /// Prevents zooming in or out beyond the set limits
        if(transform.position.y < MinZoom && scroll > 0) 
            return;

        if(transform.position.y > MaxZoom && scroll < 0)
            return;

        transform.position = Vector3.SmoothDamp(transform.position, targetpos, ref ZoomVelocity, smoothTime);
        
    }

    private float GetCrosshairDistance()
    {
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, maxCrosshairDistance))
            return hit.distance;

        return maxCrosshairDistance;
    }

    private void HandleRotation()
    {
        // Right mouse button for rotation
        if(Input.GetMouseButton(1))
        {
            float MouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            float MouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

             pitch = Mathf.Clamp(pitch - MouseY, minpitch, maxpitch);

            transform.RotateAround(Crosshair.position, Vector3.up, MouseX);
            transform.RotateAround(Crosshair.position, transform.right, pitch - transform.eulerAngles.x);
            transform.LookAt(Crosshair);
        }
    }

    private void HandleMovement()
    {
        Vector3 targetpos = transform.position;

        float VertInput = Input.GetAxisRaw("Vertical");
        float HorInput = Input.GetAxisRaw("Horizontal");

        Vector3 Forward = Vector3.ProjectOnPlane(transform.forward, Vector3.up);
        if(VertInput > 0)
            targetpos += Forward * moveSpeed * Time.deltaTime;
        if(VertInput < 0)
            targetpos -= Forward * moveSpeed * Time.deltaTime;

        if(HorInput > 0)
           targetpos += transform.right * moveSpeed * Time.deltaTime;
        if(HorInput < 0)
            targetpos -= transform.right * moveSpeed * Time.deltaTime;

        if(Vector3.Distance(CenterPoint, targetpos) > MaxDistanceFromCenter)
        {
            targetpos = CenterPoint + (targetpos - CenterPoint).normalized * MaxDistanceFromCenter;
        }

        transform.position = Vector3.SmoothDamp(transform.position, targetpos, ref velocity, smoothTime);
    }

    // Optional movement for mouse when it goes to the edge 
    /* private void HandleMouseEdgeMovement()
    {
        Vector3 targetPosition = transform.position;
        Vector3 mousePosition = Input.mousePosition;
        Vector3 Forward = Vector3.ProjectOnPlane(transform.forward, Vector3.up);

        if(mousePosition.x > ScreenWidth - MouseEdgeMovement)
            targetPosition += transform.right * EdgeMovementSpeed * Time.deltaTime;


        if(mousePosition.x < MouseEdgeMovement)
            targetPosition -= transform.right * EdgeMovementSpeed * Time.deltaTime;
        
        if(mousePosition.y > ScreenHeight - MouseEdgeMovement)
            targetPosition += Forward * EdgeMovementSpeed * Time.deltaTime;

        if(mousePosition.y < MouseEdgeMovement)
            targetPosition -= Forward * EdgeMovementSpeed * Time.deltaTime;
        
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref EdgeVelocity, smoothTime);
    }*/
}
