using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinosaurGroundedState : EnemyState
{
    private float timeToFlip;
    public DinosaurGroundedState(Dinosaur _enemyBase, EnemyStateMachine _stateMachine, string _boolName) : base(_enemyBase, _stateMachine, _boolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        timeToFlip = 2f;
    }
    public override void Update()
    {
        base.Update();
        timeToFlip -= Time.deltaTime;
        float distancePlayerToDinosaur = Vector2.Distance(rb.transform.position, PlayerManager.instance.player.transform.position);

        if (enemyBase.checkDie)
        {
            enemyBase.stateMachine.ChangeState(enemyBase.dieState);
        }

        else
        {
            if (Mathf.Abs(distancePlayerToDinosaur) < enemyBase.distanceToAttack && Mathf.Abs(distancePlayerToDinosaur) > 0)
            {

            }
            else {

                if (enemyBase.LimitAttack())
                {
                    enemyBase.stateMachine.ChangeState(enemyBase.attackState);
                }
                if (enemyBase.PlayerInAttackSideBehind() && !enemyBase.triggerAttack)
                {
                    if (rb.transform.position.x < PlayerManager.instance.player.transform.position.x && rb.velocity.x < 0)
                    {

                        enemyBase.Flip();

                    }
                    if (rb.transform.position.x > PlayerManager.instance.player.transform.position.x && rb.velocity.x > 0)
                    {
                        enemyBase.Flip();

                    }
                }
                if (enemyBase.checkAttacked)
                {
                    if (PlayerManager.instance.player.transform.position.x > rb.transform.position.x && rb.velocity.x < 0)
                    {
                        enemyBase.stateMachine.ChangeState(enemyBase.idleState);
                        enemyBase.Flip();
                    }
                    else if (PlayerManager.instance.player.transform.position.x < rb.transform.position.x && rb.velocity.x > 0)
                    {
                        enemyBase.stateMachine.ChangeState(enemyBase.idleState);
                        enemyBase.Flip();
                    }
                    enemyBase.checkAttacked = false;
                }
            }
            
        }

        

    }


    public override void Exit()
    {
        base.Exit();
    }
}
