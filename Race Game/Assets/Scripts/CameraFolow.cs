using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    
    public int CameraPosition;
    public Transform Target;
    [Header("Cam0")]
    public Vector3 Position0 = new Vector3(0, 3, -4);
    public Vector3 Rotation0 = new Vector3(12, 0, 0);
    [Space(1)]
    [Header("Cam1")]
    public Vector3 Position1 = new Vector3(0, 3, -6);
    public Vector3 Rotation1 = new Vector3(12, 0, 0);
    [Space(1)]
    [Header("Cam2")]
    public Vector3 Position2 = new Vector3(0, 0.8f, 1.5f);
    public Vector3 Rotation2 = new Vector3(5, 0, 0);

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            CameraPosition++;
        if (CameraPosition > 2)
            CameraPosition = 0;

        switch (CameraPosition)
        {
            case 0:
                transform.position = Target.position + Position0;
                transform.rotation = Quaternion.Euler(Rotation0);
                break;

            case 1:
                transform.position = Target.position + Position1;
                transform.rotation = Quaternion.Euler(Rotation1);
                break;

            case 2:
                transform.position = Target.position + Position2;
                transform.rotation = Quaternion.Euler(Rotation2);
                break;

            default:
                transform.position = Target.position + Position0;
                transform.rotation = Quaternion.Euler(Rotation0);
                break;


        }



    }
}
