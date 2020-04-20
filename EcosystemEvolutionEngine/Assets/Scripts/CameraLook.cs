using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{

    public float MouseSensitivity = 1000f;

    public Transform CameraView;

    float xRotation = 0f;

    public bool CameraDisabled = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
         if (Input.GetKeyDown(KeyCode.LeftShift))
         {
            CameraDisabled = !CameraDisabled;
         }

        if (!CameraDisabled)
        {
            Cursor.lockState = CursorLockMode.Locked;

            float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            CameraView.Rotate(Vector3.up * mouseX);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
