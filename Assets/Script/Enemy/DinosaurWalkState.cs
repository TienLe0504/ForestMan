using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinosaurWalkState : DinosaurGroundedState
{
    public float xVelocity;
    public float increaseSpeed;
    private float speedDinosaur;
    public DinosaurWalkState(Dinosaur _enemyBase, EnemyStateMachine _stateMachine, string _boolName, float _xVelocity, float _increaseSpeed) : base(_enemyBase, _stateMachine, _boolName)
    {
        this.xVelocity = _xVelocity;
        this.increaseSpeed = _increaseSpeed;
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();
        float distancePlayerToDinosaur = Vector2.Distance(rb.transform.position, PlayerManager.instance.player.transform.position);

        if (enemyBase.PlayerInAttackSide())
        {
            speedDinosaur = increaseSpeed;
        }
        else
        {
            speedDinosaur = 1;
        }

        if (!enemyBase.checkDie)
        {
            enemyBase.SetVelocity(xVelocity * enemyBase.facingDir * speedDinosaur, rb.velocity.y);
        }

        if (!enemyBase.IsGroundDetected() || enemyBase.IsWallDetected() || enemyBase.IsWallDetectedBelow())
        {
            enemyBase.stateMachine.ChangeState(enemyBase.idleState);
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
}
