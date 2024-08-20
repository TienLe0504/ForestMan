using UnityEngine;

public class DinosaurIdleState : DinosaurGroundedState
{
    private int randomNumber = 0;
    private float timeToFlip;

    public DinosaurIdleState(Dinosaur _enemyBase, EnemyStateMachine _stateMachine, string _boolName)
        : base(_enemyBase, _stateMachine, _boolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        timeTrigger = 1.5f;
        timeToFlip = 0.7f;
    }

    public override void Update()
    {
        base.Update();
        enemyBase.SetZeroVelocity();

        if (enemyBase.checkAttacked)
        {
            timeToFlip -= Time.deltaTime;
        }
        else
        {
            timeTrigger -= Time.deltaTime;
        }

        if (timeTrigger < 0)
        {
            if (!enemyBase.IsGroundDetected() || enemyBase.IsWallDetected() || enemyBase.IsWallDetectedBelow())
            {
                if (!enemyBase.PlayerInAttackSide())
                {
                    enemyBase.Flip();
                }
            }
            ChangeStateEnemy();
        }
        else if (timeToFlip < 0)
        {
            ChangeStateEnemy();
        }
    }

    private void ChangeStateEnemy()
    {
        enemyBase.stateMachine.ChangeState(enemyBase.walkState);
    }
}