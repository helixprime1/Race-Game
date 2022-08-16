using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float HorizontalInput;
    private float VerticalInput;
    private float SteeringAngle;

    public WheelCollider FrontL, FrontR;
    public WheelCollider BackL, BackR;

    public Transform FrontLT, FrontRT;
    public Transform BackLT, BackRT;
    public float HorsePower = 100f;
    public float SteeringClampAngle = 35f;

    private void GetInput()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");

    }

    private void Steer()
    {
        SteeringAngle = SteeringClampAngle * HorizontalInput;
        FrontL.steerAngle = SteeringAngle;
        FrontR.steerAngle = SteeringAngle;
    }

    private void Accelerate()
    {
        BackL.motorTorque = HorsePower * VerticalInput;
        BackR.motorTorque = HorsePower * VerticalInput;
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(FrontL, FrontLT);
        UpdateWheelPose(FrontR, FrontRT);
        UpdateWheelPose(BackL, BackLT);
        UpdateWheelPose(BackR, BackRT);
    }

    private void UpdateWheelPose(WheelCollider collider, Transform transform)
    {
        Vector3 pos = transform.position;
        Quaternion Quat = transform.rotation;

        collider.GetWorldPose(out pos, out Quat);

        transform.position = pos;
        transform.rotation = Quat;
    }

    private void FixedUpdate()
    {

        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();

    }

}
