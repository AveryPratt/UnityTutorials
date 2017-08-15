using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;

    void FixedUpdate()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        float moveVertical = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        body.velocity = movement;

        body.position = new Vector3(
            Mathf.Clamp(body.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(body.position.z, boundary.zMin, boundary.zMax)
            );

        body.rotation = Quaternion.Euler(0.0f, 0.0f, body.velocity.x * -tilt);
    }
}
