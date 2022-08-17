using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    [Header("Target")]
    public Transform Target;
    [Header("Cam Options")]
    public int CamAngle = 0;
    public Vector3 Ofset1 = new Vector3(0, 3, -4);
    public Vector3 Ofset2 = new Vector3(0, 3, -6);
    public Vector3 Ofset3 = new Vector3(0, 3, -6);
    public float folowSpeed = 10f; 
    public float LookAtSpeed = 10f;
    private Vector3 TargetPosition;

    private void LookAtTarget()
    {
        Vector3 lookDirection = Target.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, LookAtSpeed * Time.deltaTime);
    }

    private void MoveToTraget()
    {

        transform.position = Vector3.Lerp(transform.position, TargetPosition, folowSpeed * Time.deltaTime);
    }

    private void NexCamAngle()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
            CamAngle++;
        if(CamAngle > 2) 
            CamAngle = 0;

        switch (CamAngle)
        {
            case 0:
                TargetPosition = Target.position +
       Target.forward * Ofset1.z +
         Target.right * Ofset1.x +
             Target.up * Ofset1.y;
                break;

            case 1:
                TargetPosition = Target.position +
       Target.forward * Ofset2.z +
         Target.right * Ofset2.x +
             Target.up * Ofset2.y;
                break;

            case 2:
                TargetPosition = Target.position +
       Target.forward * Ofset3.z +
         Target.right * Ofset3.x +
             Target.up * Ofset3.y;
                break;

            default:
                TargetPosition = Target.position +
       Target.forward * Ofset1.z +
         Target.right * Ofset1.x +
             Target.up * Ofset1.y;
                break;

        }


    }


    private void FixedUpdate()
    {
        NexCamAngle();
        LookAtTarget();
        MoveToTraget();
    }

}
