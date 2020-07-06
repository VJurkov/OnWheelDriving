using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    private float horizontalInput;
    private float verticalInput;
    private float steeringAngle;

    public WheelCollider frontDriverW, frontPassengerW;
    public WheelCollider rearDriverW, rearPassengerW;
    public Transform frontDriverT, frontPassengerT;
    public Transform rearDriverT, rearPassengerT;

    public GameObject leftLight;
    public GameObject rightLight;

    private bool lightsOn = false;
    // how fast can I turn
    public float maxSteerAngle = 30;
    //how fast can I go
    public float motorForce = 50;

    public void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    public void Steer()
    {
        steeringAngle = maxSteerAngle * horizontalInput;
        frontDriverW.steerAngle = steeringAngle;
        frontPassengerW.steerAngle = steeringAngle;
    }

    public void Accelerate()
    {
        frontDriverW.motorTorque = verticalInput * motorForce;
        frontPassengerW.motorTorque = verticalInput * motorForce;
    }

    //how the wheels will look, like they are moving (transform)
    //taking pose from the collider and applying to this form
    public void UpdateWheelPoses()
    {
        UpdateWheelPoses(frontDriverW, frontDriverT);
        UpdateWheelPoses(frontPassengerW, frontPassengerT);
        UpdateWheelPoses(rearDriverW, rearDriverT);
        UpdateWheelPoses(rearPassengerW, rearPassengerT);
    }

    public void UpdateWheelPoses(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        
        _transform.position = _pos;
        _transform.rotation = _quat;
    }

    private void CheckLight()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            lightsOn = !lightsOn;

            if (lightsOn)
            {
                leftLight.SetActive(true);
                rightLight.SetActive(true);
            }
            else
            {
                leftLight.SetActive(false);
                rightLight.SetActive(false);
            }
        }
    }

    public void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
        CheckLight();
    }
}
