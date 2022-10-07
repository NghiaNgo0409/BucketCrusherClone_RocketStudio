using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] Image virtualJoystickBG;
    [SerializeField] Image virtualJoystick;
    [SerializeField] Transform sawBlade;

    [SerializeField] float rotateSpeed;

    Vector2 dragInput;
    bool isSawBladeSpin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isSawBladeSpin) 
            sawBlade.Rotate(0, Time.deltaTime * rotateSpeed, 0);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            virtualJoystickBG.rectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out dragInput))
        {
            dragInput.x /= virtualJoystickBG.rectTransform.sizeDelta.x;
            dragInput.y /= virtualJoystickBG.rectTransform.sizeDelta.y;
            Debug.Log(dragInput.x.ToString() + " / " + dragInput.y.ToString());

            //Normalize position
            if(dragInput.magnitude > 1f)
            {
                dragInput = dragInput.normalized;
            }

            //Image of Virtual Joystick Move
            virtualJoystick.rectTransform.anchoredPosition = new Vector2(
                dragInput.x * (virtualJoystickBG.rectTransform.sizeDelta.x / 2),
                dragInput.y * (virtualJoystickBG.rectTransform.sizeDelta.y / 2));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
        isSawBladeSpin = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        dragInput = Vector2.zero;
        virtualJoystick.rectTransform.anchoredPosition = Vector2.zero;
        isSawBladeSpin = true;
    }

    public float InputHorizontal()
    {
        return dragInput.x;
    }

    public float InputVertical()
    {
        return dragInput.y;
    }
}
