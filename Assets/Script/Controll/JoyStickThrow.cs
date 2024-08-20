using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStickThrow : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public bool canThrow = false;
    public Vector2 lastDirection;
    public RectTransform handle;
    private RectTransform background;
    private float maxWidth; // Khoảng cách tối đa mà handle có thể di chuyển
    private Vector2 velocity; // Vận tốc hiện tại
    private float maxHeight; // Khoảng cách tối đa mà handle có thể di chuyển theo chiều dọc
    private Vector2 initialHandlePosition; // Vị trí ban đầu của handle
    private float radius;
    public Vector2 direction;
    public ThrowSkill throwSkill;
    [SerializeField] private GameObject axs;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private float time;
    void Start()
    {
        background = GetComponent<RectTransform>();
        radius = background.sizeDelta.x / 2f; // Sử dụng bán kính để tính toán tối đa khoảng cách

        initialHandlePosition = handle.anchoredPosition;
        throwSkill = SkillManager.instance.throwSkill;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(background, eventData.position, eventData.pressEventCamera, out pos))
        {
            // Đảm bảo handle nằm trong giới hạn của background
            Vector2 clampedPos = ClampToRadius(pos, radius);
            handle.anchoredPosition = clampedPos;
            velocity = new Vector2(clampedPos.x / radius, clampedPos.y / radius);
            CalculateDirection();
        }
        CallThrow();
    }

    public void CallThrow()
    {
        canThrow = true;
    }

    private void CalculateDirection()
    {
        Vector2 pointerHandlePosition = velocity;
        direction = pointerHandlePosition.normalized; // Chỉ lấy hướng của joystick, không trừ đi vị trí của người chơi
        PlayerManager.instance.player.throwSkillState.SetButtonPosition(pointerHandlePosition);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        handle.anchoredPosition = new Vector2(handle.anchoredPosition.x, 0);
        handle.anchoredPosition = new Vector2(0, handle.anchoredPosition.y); // Đặt lại vị trí khi thả chuột
        velocity = Vector2.zero; // Đặt lại vận tốc khi thả chuột
        canThrow = false;
        lastDirection = new Vector2(direction.normalized.x * throwSkill.launchForce.x, direction.normalized.y * throwSkill.launchForce.y);
        if (PlayerManager.instance.player.IsGroundDetected() && !PlayerManager.instance.player.checkDide && Inventory.instance.itemStone.GetStack()>0)
        {
            GameObject throwThing = Instantiate(axs, playerPosition.position, transform.rotation);
            throwThing.SetActive(true);
            ThrowSkillController newThrowThing = throwThing.GetComponent<ThrowSkillController>();

            if (newThrowThing == null)
            {
                Debug.LogError("ThrowSkillController component is missing on axs prefab");
                return;
            }
            Inventory.instance.itemStone.stack -= 1;
            ManagerUI.instance.amountStone.ShowAmount(Inventory.instance.itemStone.stack);
            //AudioManager.instance.OneShortAudio(AudioManager.instance.throwStone);
            //AudioManager.instance.PlayOneShortAudio(AudioManager.instance.audioSFXWeapon, AudioManager.instance.throwStone);
            ManageState.instance.PlayOneShortAudio(ManageState.instance.audioSFXWeapon, ManageState.instance.throwStone);

            newThrowThing.CreateThrowSkill(lastDirection, throwSkill.swordGravity, time);

        }
    }

    public Vector2 GetVelocityDirection()
    {
        return velocity;
    }

    private Vector2 ClampToRadius(Vector2 pos, float radius)
    {
        if (pos.magnitude > radius)
        {
            pos = pos.normalized * radius;
        }
        return pos;
    }

    private void Update()
    {

    }
}
