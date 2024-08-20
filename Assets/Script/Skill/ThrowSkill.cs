using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSkill : MonoBehaviour
{
    [SerializeField] public int numberOfDots;
    [SerializeField] public float distanceBetweenDots;
    [SerializeField] private GameObject dotsPrefab;
    [SerializeField] private Transform dotsTranform;
    public GameObject[] dots;
    [SerializeField] public Vector2 launchForce;
    [SerializeField] public float swordGravity;
    private Player player;
    private void Awake()
    {
        
    }
    void Start()
    {
        CreateDots();
        player = PlayerManager.instance.player;
    }

    void Update()
    {
        if (PlayerManager.instance.player.joyStickThrow.canThrow && !PlayerManager.instance.player.checkDide )
        {
            if (player.IsGroundDetected() && Inventory.instance.itemStone.GetStack()>0)
                TurnOnDots();
        }
        else
        {
            TurnOffDots();
        }
    }

    public void CreateDots()
    {
        dots = new GameObject[numberOfDots];
        for (int i = 0; i < numberOfDots; i++)
        {
            dots[i] = Instantiate(dotsPrefab, PlayerManager.instance.player.transform.position, Quaternion.identity);
            dots[i].SetActive(false);
        }
    }

    public void TurnOnDots()
    {
        for (int i = 0; i < numberOfDots; i++)
        {
            dots[i].SetActive(true);
            dots[i].transform.position = DotsPosition(i * distanceBetweenDots);
        }
    }

    public void TurnOffDots()
    {
        for (int i = 0; i < numberOfDots; i++)
        {
            dots[i].SetActive(false);
        }
    }

    public Vector2 DotsPosition(float t)
    {
        Vector2 startPosition = PlayerManager.instance.player.transform.position;
        Vector2 direction = PlayerManager.instance.player.joyStickThrow.GetVelocityDirection().normalized; // Chỉ lấy hướng, không cần vận tốc
        Vector2 position = startPosition + direction * launchForce * t + 0.5f * Physics2D.gravity * swordGravity * (t * t);
        return position;
    }
}
