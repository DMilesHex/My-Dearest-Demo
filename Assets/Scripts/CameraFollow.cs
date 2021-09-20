using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public Vector2 offset;

    private Rigidbody2D cameraRigidbody;

    // Start is called before the first frame update
    void Start()
    {

    }


    void FixedUpdate()
    {
        transform.position = new Vector3(
            target.transform.position.x + offset.x,
            target.transform.position.y + offset.y,
            transform.position.z
            );
    }
}
