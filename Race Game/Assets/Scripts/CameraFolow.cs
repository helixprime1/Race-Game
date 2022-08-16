using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{

    public Transform Target;
    public Vector3 Ofset = new Vector3(0,3,-4);
    public float folowSpeed = 10f;
    public float LookAtSpeed = 10f;

    private void LookAtTarget()
    {
        Vector3 lookDirection = Target.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, LookAtSpeed * Time.deltaTime);
    }

    private void MoveToTraget()
    {
        Vector3 TargetPosition = Target.position +
                        Target.forward * Ofset.z + 
                          Target.right * Ofset.x +
                              Target.up * Ofset.y;
        transform.position = Vector3.Lerp(transform.position, TargetPosition, folowSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        LookAtTarget();
        MoveToTraget();
    }

}
