using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.XR;


public class CameraMovementPC : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public new Camera camera;
    public float smoothSpeed = 0.1f;
    public Vector3 offset;
    public Vector3 initialOffset;
    public float minZoomDist;
    public float maxZoomDist;
    public float zoomSpeed;
    public int zoomCount = 0;
    private bool isInGame = false;
    private void Awake()
    {
        camera.orthographic = !Settings.isPresoective;
    }

    private void Start()
    {
        isInGame = SceneManager.GetActiveScene().name.Equals("GameScene");
        
        transform.position = target.position + offset;
        this.initialOffset = offset;
        
#if UNITY_IOS || UNITY_ANDROID
        zoomSpeed = 0.01f;
#else
        zoomSpeed = 0.5f;
#endif

    }

    private float OrbitSpeed = 150f;
    void Update()
    {
        var desiredPosition = target.position + offset;
        var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        if (isInGame)
        {


            // var smoothedPosition = desiredPosition;

#if UNITY_IOS || UNITY_ANDROID
        HandleMobileZoom();
#else
            HandlePcZoom();
            if (Input.GetKeyDown(KeyCode.R))
                RotateCamera();



#endif

            transform.LookAt(target);
        }

        transform.position = smoothedPosition;
    }

    public void RotateCamera()
    {
        var x = offset.x;
        var z = offset.z;
        offset.x = -1 * z;
        offset.z = 1 * x;
    }

    private void HandleMobileZoom()
    {
        if (Input.touchCount == 2)
        {
            var touchZero = Input.GetTouch(0);
            var touchOne = Input.GetTouch(1);
            var touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            var touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
            var prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            var currentMagnitude = (touchZero.position - touchOne.position).magnitude;
            var difference = currentMagnitude - prevMagnitude;
            Zoom(difference * 0.06f);
        }
    }

    public void ResetZoom()
    {
        offset = initialOffset * 2f;
    }

    private void Zoom(float increment)
    {
        if (camera.orthographic)
        {
            camera.orthographicSize =
                Mathf.Clamp(camera.orthographicSize - increment, minZoomDist / 5f, maxZoomDist / 5f);
        }
        else
        {
            if (isZoomPossible(increment))
                this.offset -= increment * zoomSpeed * offset;
        }
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    private void HandlePcZoom()
    {
        
        var scrollInput = Input.GetAxis("Mouse ScrollWheel");
            Zoom(scrollInput * 3);
        
    }

    private bool isZoomPossible(float scrollInput)
    {
        float dist = Vector3.Distance(transform.position, target.position);

        // return false;
        if (dist < minZoomDist && scrollInput > 0.0f )
            return false;
        else if (dist > maxZoomDist && scrollInput < 0.0f)
            return false;
        return true;
    }

    void LateUpdate()
    {
    }
}