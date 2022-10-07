using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKManager : MonoBehaviour
{
    [SerializeField] Joints startJoint;
    [SerializeField] Joints endJoint;
    [SerializeField] GameObject target;
    int loopSpeed;
    float rate;
    [SerializeField] SawBreaker saw;
    [SerializeField] JoystickController joystickController;

    float threshold = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        loopSpeed = 15;
        rate = .25f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!joystickController.IsSawBladeSpin()) return;
        if (GameManager.Instance.IsWin()) return;
        if (saw.IsCrushing())
        {
            loopSpeed = 11;
            rate = .095f;
        }
        else
        {
            loopSpeed = 15;
            rate = .25f;
        }
        for (int i = 0; i < loopSpeed; i++)
        {
            if (GetDistance(endJoint.transform.position, target.transform.position) > threshold)
            {
                Joints currentJoint = startJoint;
                while (currentJoint != null)
                {
                    float slope = CalculateSlope(currentJoint);
                    currentJoint.Rotate(-slope * rate);
                    currentJoint = currentJoint.GetChildJoint();
                }
            }
        }
    }

    float GetDistance(Vector3 point1, Vector3 point2)
    {
        return Vector3.Distance(point1, point2);
    }
    
    float CalculateSlope(Joints joint)
    {
        float deltaTheta = 0.01f;
        float distance1 = GetDistance(endJoint.transform.position, target.transform.position);
        joint.Rotate(deltaTheta);

        float distance2 = GetDistance(endJoint.transform.position, target.transform.position);
        joint.Rotate(-deltaTheta);

        return (distance2 - distance1) / deltaTheta;
    }

}
