using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public static List<KeyCode> controlsDirection = new List<KeyCode> { KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.RightArrow }; // up left down right
    public static List<KeyCode> controlsUtilities = new List<KeyCode> { KeyCode.Space, KeyCode.E }; // jump interact

    public float speed = 5.0f;
    public float jumpSpeed = 5.0f;
    private Vector3 moveDirection;
    public Transform cam;
    public bool grounded = false;

    void Update()
    {
        moveDirection = new Vector3(0, this.gameObject.GetComponent<Rigidbody>().velocity.y, 0);

        if (Input.GetKey(controlsDirection[0]))
        {
            moveDirection += (cam.forward.x * Vector3.right + cam.forward.z * Vector3.forward).normalized * speed;
        }
        if (Input.GetKey(controlsDirection[1]))
        {
            moveDirection += (-cam.right.x * Vector3.right + -cam.right.z * Vector3.forward).normalized * speed;
        }
        if (Input.GetKey(controlsDirection[2]))
        {
            moveDirection += (-cam.forward.x * Vector3.right + -cam.forward.z * Vector3.forward).normalized * speed;
        }
        if (Input.GetKey(controlsDirection[3]))
        {
            moveDirection += (cam.right.x * Vector3.right + cam.right.z * Vector3.forward).normalized * speed;
        }
        if (grounded && Input.GetKey(controlsUtilities[0]))
        {
            grounded = false;

            moveDirection.y = jumpSpeed;
        }

        this.gameObject.GetComponent<Rigidbody>().velocity = moveDirection;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
}
