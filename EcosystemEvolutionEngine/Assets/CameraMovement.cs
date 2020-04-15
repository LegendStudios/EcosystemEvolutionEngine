using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{

    public float CameraSpeed= 18;

    private Rigidbody rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hAxis, 0, vAxis) * CameraSpeed * Time.deltaTime;

        rig.MovePosition(transform.position + movement);
    }
}
