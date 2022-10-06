using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joints : MonoBehaviour
{
    [SerializeField] Joints childJoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Joints GetJoint()
    {
        return childJoint;
    }

    public void Rotate(float angle)
    {
        transform.Rotate(Vector3.forward * angle);
    }
}
