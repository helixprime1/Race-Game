using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float HorizontalInput;
    private float VerticalInput;
    private float SteeringAngle;
    private float friction;
    

    [Header("Wheel Colliders")]
    public WheelCollider FrontL, FrontR;
    public WheelCollider BackL, BackR;
    [Space(1)]
    [Header("Wheel Transforms")]
    public Transform FrontLT, FrontRT;
    public Transform BackLT, BackRT;
    [Space(1)]
    [Header("CarSettings")]
    public float HorsePower = 3000f;
    public float SteeringClampAngle = 35f;
    public float BrakeHorsePower = 2000;
    public Rigidbody rb;
    public float Speed;

    private void Awake()
    {
        friction = BackL.sidewaysFriction.stiffness;
    }
    private void GetInput()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");

    }

    private void Steer()
    {
        SteeringAngle = SteeringClampAngle * HorizontalInput;
        FrontL.steerAngle = SteeringAngle;
        FrontR.steerAngle = SteeringAngle;
    }

    private void Accelerate()
    {
        FrontL.motorTorque = HorsePower * VerticalInput;
        FrontR.motorTorque = HorsePower * VerticalInput;
        Speed = rb.velocity.magnitude;
        Debug.Log(Speed);

    }

    private void HandBreak()
    {
        WheelFrictionCurve wfcL = BackL.sidewaysFriction;
        WheelFrictionCurve wfcR = BackR.sidewaysFriction;
        if (Input.GetKey(KeyCode.Space))
        {
            wfcL.stiffness = 0.5f;
            wfcR.stiffness = 0.5f;
            BackL.sidewaysFriction = wfcL;
            BackR.sidewaysFriction = wfcR;
            BackL.brakeTorque = BrakeHorsePower;
            BackR.brakeTorque = BrakeHorsePower;
        }
        else
        {
            wfcL.stiffness = 1;
            wfcR.stiffness = 1;
            BackL.sidewaysFriction = wfcL;
            BackR.sidewaysFriction = wfcR;
            BackL.brakeTorque = 0f;
            BackR.brakeTorque = 0f;
        }
    }

    private void WheelFrictionSetup()
    {

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
        HandBreak();
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();

    }

}
