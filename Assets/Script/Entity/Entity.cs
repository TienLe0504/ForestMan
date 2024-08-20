using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] public float health;
    public bool checkDie;
    public int facingDir { get; private set; } = 1;
    public bool facingRight = true;
    public Rigidbody2D rb;
    public Animator anim { get; private set; }

    public float raycastDistance = 1.0f;
    public LayerMask groundLayer;

    [Header("Raycast")]
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected LayerMask whatIsGround;
    [Header("Dame")]
    [SerializeField] public Transform damePosition;
    [SerializeField] public GameObject dame;
    [SerializeField] public float timeShowText;
    
    public SpriteRenderer sprite;

    protected virtual void Start()
    {

    }

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        checkDie = false;
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    public virtual void Update()
    {

    }

    public virtual void FlipController(float _x)
    {
        if (_x > 0 && !facingRight)
        {
            Flip();
        }
        else if (_x < 0 && facingRight)
        {
            Flip();
        }
    }

    public virtual void Flip()
    {
        facingDir *= -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    public void SetZeroVelocity()
    {
        rb.velocity = new Vector2(0, 0);
    }

    public virtual void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipController(_xVelocity);
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
    }

    public virtual bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);

    public void ChangeColorByAttack()
    {
        Color originColor = Color.white;
        Color color1 = new Color(1.0f, 0.62f, 0.62f); // FF9E9E
        Color color2 = new Color(0.99f, 0.39f, 0.39f); // FC6363
        StartCoroutine(ChangeColorCoroutine(sprite, originColor, color1, color2));
    }

    private IEnumerator ChangeColorCoroutine(SpriteRenderer sprite, Color originColor, Color color1, Color color2)
    {
        float elapsedTime = 0f;
        float changeInterval = 0.1f;

        while (elapsedTime < 1f)
        {
            sprite.color = (sprite.color == color1) ? color2 : color1;
            elapsedTime += changeInterval;
            yield return new WaitForSeconds(changeInterval);
        }

        sprite.color = originColor;
    }
    public void ShowPositionDamage(float damage)
    {
        GameObject damePrefab =  Instantiate(dame, damePosition.position, Quaternion.identity);
        damePrefab.SetActive(true);
        TextMesh textMesh = damePrefab.GetComponentInChildren<TextMesh>();
        MeshRenderer meshRenderer = textMesh.GetComponent<MeshRenderer>();
        meshRenderer.sortingLayerName = "Player";
        meshRenderer.sortingOrder = 10;
        textMesh.text = damage.ToString();
        StartCoroutine(WaitToDestroyDamage(timeShowText, damePrefab));
    }
    IEnumerator WaitToDestroyDamage(float time,GameObject damePrefab)
    {
        yield return new WaitForSeconds(time);
        Destroy(damePrefab);

    }
}
