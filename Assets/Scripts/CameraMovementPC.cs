using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class CameraMovementPC : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Camera camera;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public float minZoomDist;
    public float maxZoomDist;
    public float zoomSpeed;
    public int zoomCount = 0;
    Vector3 touchStart;

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
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * 0.01f);
        }

        handlePCZoom();
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }

    void zoom(float increment)
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

    private void handlePCZoom()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (!isZoomPossible(scrollInput)) return;
        if (camera.orthographic)
        {
            if (scrollInput < 0 && zoomCount > -4)
            {
                zoomCount--;
                camera.orthographicSize -= scrollInput * 8f;
            }
            else if (scrollInput > 0 && zoomCount < 6)
            {
                zoomCount++;
                camera.orthographicSize -= scrollInput * 8f;
            }
        }
        else
        {
            this.offset -= scrollInput  * 0.5f* offset;
        }
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