using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Transform cameraTransform;

    public float moveSpeed = 20f;
    public float turnSpeed = 135f;
    public float zoomSpeed = 15f;

    public float minZoomDistance = 5f;
    public float maxZoomDistance = 30f;
    public float minZoomAngle = 40f;
    public float maxZoomAngle = 90f;

    private float d = 10f;
    private float a = 30f;
    
    void Start() {}

    void Update() {
        float v = Input.GetAxis("Vertical") * moveSpeed;
        float h = Input.GetAxis("Horizontal") * moveSpeed;

        float r = 0f;
        if (Input.GetKey(KeyCode.Q)) r += turnSpeed;
        if (Input.GetKey(KeyCode.E)) r -= turnSpeed;

        float s = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

        d -= s;
        if (d < minZoomDistance) d = minZoomDistance;
        if (d > maxZoomDistance) d = maxZoomDistance;

        a = minZoomAngle + (d - minZoomDistance) / (maxZoomDistance - minZoomDistance) * (maxZoomAngle - minZoomAngle);

        cameraTransform.localPosition = new Vector3(0f, Mathf.Sin(Mathf.Deg2Rad*a)*d, -Mathf.Cos(Mathf.Deg2Rad*a)*d);
        cameraTransform.localEulerAngles = new Vector3(a, 0f, 0f);

        transform.Rotate(Vector3.up, r*Time.deltaTime);
        transform.position += transform.TransformVector(new Vector3(h, 0f, v)) * Time.deltaTime;
    }
}
