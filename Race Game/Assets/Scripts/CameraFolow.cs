using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
     

    public Transform Target;
    public Vector3 CamPosition = new Vector3(0, 3, -4);
    public Vector3 CamRotation = new Vector3(12, 0, 0);

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        transform.position = Target.localPosition + CamPosition;
        transform.localRotation = Quaternion.Euler(CamRotation);

       

    }
}
