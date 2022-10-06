using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKManager : MonoBehaviour
{
    [SerializeField] Joints startJoint;
    [SerializeField] Joints endJoint;
    [SerializeField] GameObject target;
    [SerializeField] float rate = 5f;

    float threshold = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetDistance(endJoint.transform.position, target.transform.position) > threshold)
        {
            float slope = CalculateSlope(startJoint);
            startJoint.Rotate(-slope * rate);
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
