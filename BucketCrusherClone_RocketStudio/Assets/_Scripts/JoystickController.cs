using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] Image virtualJoystickBG;
    [SerializeField] Image virtualJoystick;

    Vector2 dragInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        dragInput = Vector2.zero;
        virtualJoystick.rectTransform.anchoredPosition = Vector2.zero;
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
