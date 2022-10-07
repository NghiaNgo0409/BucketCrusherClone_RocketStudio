using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    [SerializeField] JoystickController joystickController;

    [SerializeField] float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = transform.position;
        desiredPosition += new Vector3(joystickController.InputHorizontal(),
                                        joystickController.InputVertical(),
                                        0) * Time.deltaTime * movementSpeed;
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, -10, 10);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, -5, 6);
        transform.position = desiredPosition;
    }
}
