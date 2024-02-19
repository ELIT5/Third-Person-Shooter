using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float RotatiomSpeed;
    public Transform Transform;
    public float minAngle;
    public float maxAngle;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var newAngleX = Transform.localEulerAngles.x - Time.deltaTime * RotatiomSpeed * Input.GetAxis("Mouse Y");
        if (newAngleX > 180)
        {
            newAngleX -= 360;
        }
        newAngleX = Mathf.Clamp(newAngleX, minAngle, maxAngle);
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Time.deltaTime * RotatiomSpeed * Input.GetAxis("Mouse X"), 0);
        Transform.localEulerAngles = new Vector3(newAngleX, 0, 0);
    }
}
