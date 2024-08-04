using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    WheelJoint2D[] wheelJoints;
    JointMotor2D frontWheel;
    JointMotor2D backWheel;
    [SerializeField]
    private float deceleration = 400f;
    private float gravity = 9.8f;
    public float angleCar = 0;
    public float acceleration = 500f;
    public float maxSpeed = 800f;
    public float maxBackSpeed = -600f;
    public float brakeForce = 1000f;
    public float wheelSize;
    public bool grounded = false;
    public LayerMask ground;
    public Transform bWheel;
    
    void Start()
    {
        wheelJoints = gameObject.GetComponents<WheelJoint2D>();

    }


    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(bWheel.transform.position, wheelSize, ground);

        angleCar = transform.localEulerAngles.z;

        if (angleCar > 180) angleCar = angleCar - 360;

        if (grounded)
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                backWheel.motorSpeed = Mathf.Clamp(backWheel.motorSpeed - (acceleration) * Time.deltaTime, maxBackSpeed, 0f);
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                backWheel.motorSpeed = Mathf.Clamp(backWheel.motorSpeed + (acceleration) * Time.deltaTime, 0f, maxSpeed);
            }
            else
            {
                backWheel.motorSpeed = Mathf.MoveTowards(backWheel.motorSpeed, 0, deceleration * Time.deltaTime);
            }
        }

       
        backWheel.maxMotorTorque = 10000f;

        wheelJoints[0].motor = backWheel;
        wheelJoints[1].motor =backWheel;

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(bWheel.transform.position, wheelSize);
    }
}
