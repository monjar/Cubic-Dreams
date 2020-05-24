using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class CameraMovementPC : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public new Camera camera;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public float minZoomDist;
    public float maxZoomDist;
    public float zoomSpeed;
    public int zoomCount = 0;

    private void Awake()
    {
        camera.orthographic = !Settings.isPresoective;
    }

    private void Start()
    {
        print("asdsad");
        XRSettings.eyeTextureResolutionScale = 2.0f;
    }

    void Update()
    {
        
#if UNITY_IOS || UNITY_ANDROID
        HandleMobileZoom();
#else
        HandlePcZoom();
#endif
        var desiredPosition = target.position + offset;
        var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
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
            Zoom(difference * 0.01f);
        }
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
                this.offset -= increment * 0.5f * offset;
        }
    }

    private void HandlePcZoom()
    {
        var scrollInput = Input.GetAxis("Mouse ScrollWheel");
        Zoom(scrollInput * 3);
    }

    private bool isZoomPossible(float scrollInput)
    {
        float dist = Vector3.Distance(transform.position, target.position);

        if (dist < minZoomDist && scrollInput > 0.0f)
            return false;
        else if (dist > maxZoomDist && scrollInput < 0.0f)
            return false;
        return true;
    }

    void LateUpdate()
    {
    }
}