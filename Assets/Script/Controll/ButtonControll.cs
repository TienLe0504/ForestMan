using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonControll : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private RectTransform leftControll;
    private RectTransform rightControll;

    public float controlValue = 0f;


    public void OnDrag(PointerEventData eventData)
    {
        if(RectTransformUtility.RectangleContainsScreenPoint(leftControll,eventData.position,eventData.pressEventCamera))
        {
            controlValue = -1;
        }
        else if(RectTransformUtility.RectangleContainsScreenPoint(rightControll, eventData.position, eventData.pressEventCamera)) { controlValue = 1; }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        controlValue = 0f;
    }
    private void Awake()
    {
        leftControll = transform.GetChild(0).GetComponent<RectTransform>();
        rightControll = transform.GetChild(1).GetComponent<RectTransform>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public float GetVelocity()
    {
        return controlValue;
    }
}
