using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float speed;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    Vector3 right;
    Vector3 forward;

    private void Start()
    {
        right = new Vector3(1, 0, 0);
        forward = new Vector3(0, 0, 1);
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Move();
        RotateCameraWithMouse();
    }

    private void Move()
    {
        transform.Translate(right * Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed);
        transform.Translate(forward * Input.GetAxisRaw("Vertical") * Time.deltaTime * speed);
    }

    void RotateCameraWithMouse()
    {
        yaw += speed * Input.GetAxis("Mouse X");
        pitch -= speed * Input.GetAxis("Mouse Y");

        transform.localEulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
