using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement2 : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;

    public bool CameraDisabled = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);
        }
    }
}
