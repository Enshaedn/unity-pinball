using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    private HingeJoint hinge;
    private float restPosition = 0f;
    public float maxPosition;
    private float hitStrength = 10000f;
    private float damper = 200f;
    public string inputValue;
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
    }

    void Update()
    {
        JointSpring spring = new JointSpring();
        spring.spring = hitStrength;
        spring.damper = damper;

        if(Input.GetAxis(inputValue) == 1) {
            spring.targetPosition = maxPosition;
        } else {
            spring.targetPosition = restPosition;
        }

        hinge.spring = spring;
        hinge.useLimits = true;
    }
}
