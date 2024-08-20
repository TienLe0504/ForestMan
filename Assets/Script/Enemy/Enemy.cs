using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected float distanceToWall;
    [SerializeField] protected float distanceToWallBelow;
    [SerializeField] public float distanceToPlayer;
    [SerializeField] protected Transform wallCheckBelow;
    [SerializeField] protected Transform attackPosition;
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] protected Transform attakLimit;
    [SerializeField] private float distanceAttack;
    [SerializeField] protected Transform attackPositionBehind;
    [SerializeField] private float distanceAttackBehinhd;
    [SerializeField] public Transform injury;
    [SerializeField] public float radiusAttack;

    public EnemyStateMachine stateMachine { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new EnemyStateMachine();
    }

    protected override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + distanceToWall * facingDir, wallCheck.position.y, wallCheck.position.z));
        Gizmos.DrawLine(wallCheckBelow.position, new Vector3(wallCheckBelow.position.x + distanceToWallBelow * facingDir, wallCheckBelow.position.y, wallCheckBelow.position.z));
        Gizmos.DrawLine(attackPosition.position, new Vector3(attackPosition.position.x + distanceToPlayer * facingDir, attackPosition.position.y, attackPosition.position.z));
        Gizmos.DrawLine(attakLimit.position, new Vector3(attakLimit.position.x + distanceAttack * facingDir, attakLimit.position.y, attakLimit.position.z));
        Gizmos.DrawLine(attackPositionBehind.position, new Vector3(attackPositionBehind.position.x + distanceAttackBehinhd * facingDir, attackPositionBehind.position.y, attackPositionBehind.position.z));
        Gizmos.DrawWireSphere(injury.position, radiusAttack);
    }

    public virtual bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, new Vector2(facingDir, 0), distanceToWall, whatIsGround);
    public virtual bool IsWallDetectedBelow() => Physics2D.Raycast(wallCheckBelow.position, new Vector2(facingDir, 0), distanceToWallBelow, whatIsGround);
    public virtual bool PlayerInAttackSide() => Physics2D.Raycast(attackPosition.position, new Vector2(facingDir, 0), distanceToPlayer, whatIsPlayer);
    public virtual bool IsWallByAttackSide() => Physics2D.Raycast(attackPosition.position, new Vector2(facingDir, 0), distanceToPlayer, whatIsGround);
    public virtual bool LimitAttack() => Physics2D.Raycast(attakLimit.position, new Vector2(facingDir, 0), distanceAttack, whatIsPlayer);
    public virtual bool PlayerInAttackSideBehind() => Physics2D.Raycast(attackPositionBehind.position, new Vector2(facingDir, 0), distanceAttackBehinhd, whatIsPlayer);


}
