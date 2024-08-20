using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinosaurAttackState : DinosaurGroundedState
{
    public DinosaurAttackState(Dinosaur _enemyBase, EnemyStateMachine _stateMachine, string _boolName) : base(_enemyBase, _stateMachine, _boolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        enemyBase.triggerAttack = true;
    }
    public override void Update()
    {
        base.Update();
        rb.velocity = new Vector2(0, 0);
        if(enemyBase.triggerAttack == false)
        {
            enemyBase.stateMachine.ChangeState(enemyBase.walkState);
        }

    }
    public override void Exit()
    {
        base.Exit();
    }
}
