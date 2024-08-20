using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonThrow : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public bool canThrow = false;
    public Vector2 direction;
    public Vector2 lastDirection;
    private RectTransform controllDirection;

    public void OnDrag(PointerEventData eventData)
    {
        CalculateDirection(eventData);
        CallThrow();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void CallThrow()
    {
        canThrow = true;
    }

    private void CalculateDirection(PointerEventData eventData)
    {
        Vector2 playerPosition = PlayerManager.instance.player.transform.position;
    }

    public Vector2 GetDirection()
    {
        return direction;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        canThrow = false;
        lastDirection = direction;
    }

    void Start()
    {
    }

    private void Awake()
    {
        controllDirection = GetComponent<RectTransform>();
    }

    void Update()
    {
    }
}
