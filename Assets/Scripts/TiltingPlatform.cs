using UnityEngine;

public class TiltingPlatform : MonoBehaviour
{
    private HingeJoint2D hinge;
    private JointMotor2D motor;

    // Start is called before the first frame update
    void Start()
    {
        motor = gameObject.GetComponent<JointMotor2D>();
        hinge = gameObject.GetComponent<HingeJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hinge.jointAngle == -20)
        {
            motor.motorSpeed = 10f;
            hinge.motor = motor;
        }
        else
        {
            motor.motorSpeed = -10f;
            hinge.motor = motor;
        } 
    }
}
