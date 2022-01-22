using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

// TODO: Add movement/zoom clamping
public class OverheadCameraController : MonoBehaviour
{
    private CinemachineVirtualCamera _overheadCamera;

    public float cameraMoveSpeed;
    public float cameraMoveAcceleration;
    public float cameraZoomSpeed;
    public float cameraZoomAcceleration;


    private void Awake()
    {
        _overheadCamera = GetComponent<CinemachineVirtualCamera>();   
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        float zoomDirection = Input.GetAxis("Mouse ScrollWheel");

        PanCamera(moveX, moveY);
        ZoomCamera(zoomDirection);
    }

    private void PanCamera(float x, float y)
    {
         Vector3 movement = new Vector3(x, 0f, y);

        _overheadCamera.transform.position = Vector3.Lerp(_overheadCamera.transform.position,
                                                          _overheadCamera.transform.position + movement * cameraMoveSpeed * Time.deltaTime,
                                                             cameraMoveAcceleration);        
    }

    private void ZoomCamera(float zoom)
    {
        Vector3 zoomMovement = new Vector3(0f, zoom, 0f);

        _overheadCamera.transform.position = Vector3.Lerp(_overheadCamera.transform.position,
                                                          _overheadCamera.transform.position - zoomMovement * cameraZoomSpeed * Time.deltaTime,
                                                          cameraZoomAcceleration);
    }
}
