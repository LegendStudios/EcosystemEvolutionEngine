using UnityEngine;

public class CameraControler : MonoBehaviour
{

    private Transform _xform_camera;
    private Transform _xform_parent;

    private Vector3 _LocalRotation;
    private float _CameraDistance = 10.0f;

    public float MouseSensitivity = 4f;
    public float ScrollSensitivity = 2f;
    public float OrbitDampening = 10f;
    public float ZoomDampening = 6f;

    public bool CameraDisable = false;

    // Start is called before the first frame update
    void Start()
    {
        this._xform_camera = this.transform;
        this._xform_parent = this.transform.parent;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            CameraDisable = !CameraDisable;

        if(!CameraDisable)
        {
            //rotation of the camera based on the mouse cordinates
            if(Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                _LocalRotation.x += Input.GetAxis("Mouse X") * MouseSensitivity;
                _LocalRotation.y -= Input.GetAxis("Mouse Y") * MouseSensitivity;

                //Clamp the y Rotation to horizon and not flipping over the top
                _LocalRotation.y = Mathf.Clamp(_LocalRotation.y, 5f, 90f);
            }

            //Zoom input from scroll wheel
            if(Input.GetAxis("Mouse ScrollWheel") != 0f)
            {
                float ScrollAmount = Input.GetAxis("Mouse ScrollWheel") * ScrollSensitivity;

                //Make the camera zoom faster the further you are   https://www.youtube.com/watch?v=bVo0YLLO43s
                ScrollAmount *= (this._CameraDistance * 0.3f);

                this._CameraDistance += ScrollAmount * -1f;
                this._CameraDistance = Mathf.Clamp(this._CameraDistance, 1.5f, 40f);
            }
        }

        //Actual Camera Rig Transformations
        Quaternion QT = Quaternion.Euler(_LocalRotation.y, _LocalRotation.x, 0);
        this._xform_parent.rotation = Quaternion.Lerp(this._xform_parent.rotation, QT, Time.deltaTime * OrbitDampening);

        if(this._xform_camera.localPosition.z != this._CameraDistance * -1)
        {
            this._xform_camera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(this._xform_camera.localPosition.z, this._CameraDistance * -1f, Time.deltaTime * ZoomDampening));
        }
    }
}
