using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Set in Inspector:")]
    public float moveSpeed;
    public float yawSpeed = 2f; // Rotation speed on Y-Axis.
    public float pitchSpeed = 2f; // Rotation speed on X-Axis.
    public float rollSpeed = 2f; // Rotation speed on Z-Axis.

    //float yaw = 0f;
    //float pitch = 0f;
    //float roll = 0f;


    Rigidbody rigid;


    void Start()
    {
        // Store references.
        rigid = GetComponent<Rigidbody>();

        // Lock cursor.
        SetCursorLock(true);
    }

    void Update()
    {
        // Toggle cursor lock.
        if (Input.GetKeyDown(KeyCode.Escape))
            SetCursorLock(!GetCursorLock());
    }

    void FixedUpdate()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        float yV = 0f;
        if (Input.GetKey(KeyCode.Space))
            yV += 1;
        if (Input.GetKey(KeyCode.LeftShift))
            yV -= 1;
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), yV, Input.GetAxis("Vertical"));
        rigid.velocity = transform.TransformDirection(movement) * moveSpeed;
    }

    void Rotate()
    {
        float yaw = 0f;
        float pitch = 0f;
        float roll = 0f;

        yaw = yawSpeed * Input.GetAxis("Mouse X");
        pitch = -pitchSpeed * Input.GetAxis("Mouse Y");
        roll = 0;
        if (Input.GetKey(KeyCode.E))
            roll -= rollSpeed;
        if (Input.GetKey(KeyCode.Q))
            roll += rollSpeed;

        transform.Rotate(new Vector3(pitch, yaw, roll), Space.Self);
    }

    bool GetCursorLock()
    {
        if (Cursor.lockState == CursorLockMode.None)
            return false;
        else
            return true;
    }

    void SetCursorLock(bool _lock)
    {
        if (_lock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
