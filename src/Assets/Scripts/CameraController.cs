using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Reference to the object to follow.
    public GameObject target;

    //Amount to smooth movement
    public float cameraMoveSpeed = 0.2f;

    //Offset from object to camera.
    public Vector3 offset;

    //Value used exclusively by smoothdamp.
    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        //Move the camera to the target, with smoothed movement. Offset added to keep the view.
        transform.position = Vector3.SmoothDamp(this.transform.position, target.transform.position + offset, ref velocity, cameraMoveSpeed * Time.deltaTime);
    }
}
