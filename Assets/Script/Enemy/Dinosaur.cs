using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinosaur : Enemy
{
    public bool checkAttacked;
    [SerializeField] public float xVelocity = 1.2f;
    [SerializeField] public float xVelocitySpeed = 2.2f;
    public BoxCollider2D box;
    public CapsuleCollider2D[] circle;
    public bool diretionLeft = true;
    public bool checkSamePosition = true;
    public bool triggerAttack = false;
    public HealthDinosaur healthDinosaur;
    public Canvas enemyBar;
    public DinosaurIdleState idleState {  get; private set; }
    public DinosaurWalkState walkState { get; private set; }
    public DinosaurAttackState attackState { get; private set; }
    public DinosaurDieState dieState { get; private set; }
    [SerializeField] public float dameByEnemy;
    public bool attackInSide;
    [SerializeField] public float distanceToAttack;
    protected override void Awake()
    {
        base.Awake();
        xVelocity *= -1;
        diretionLeft = true;
        checkSamePosition = true;
        triggerAttack = false;
        checkAttacked = false;
        idleState = new DinosaurIdleState(this, stateMachine, "Idle");
        walkState = new DinosaurWalkState(this, stateMachine, "Walk",xVelocity,xVelocitySpeed);
        attackState = new DinosaurAttackState(this, stateMachine, "Attack");
        dieState = new DinosaurDieState(this, stateMachine, "Died");
        box = GetComponent<BoxCollider2D>();
        circle  = GetComponents<CapsuleCollider2D>();
        box.enabled = false;
        healthDinosaur = GetComponent<HealthDinosaur>();
        //health = 50;
        enemyBar = GetComponentInChildren<Canvas>();
        attackInSide = false;

    }
    protected override void Start()
    {
        base.Start();

        facingRight = false;
        stateMachine.Initialize(idleState);
    }
    public override void Update()
    {
        base.Update();
    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Sword"))
        {
            checkAttacked = true;
            healthDinosaur.Dodamage(PlayerManager.instance.player.dameByPlayer);
            ShowPositionDamage(PlayerManager.instance.player.dameByPlayer);
            if (PlayerManager.instance.player.rb.transform.position.x>rb.transform.position.x)
            {
                rb.transform.position = new Vector3(rb.transform.position.x-0.2f,rb.transform.position.y,rb.transform.position.z);
            }
            else
            {
                rb.transform.position = new Vector3(rb.transform.position.x + 0.2f, rb.transform.position.y, rb.transform.position.z);

            }
        }
    }

}
