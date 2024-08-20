using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DinosaurDieState : DinosaurGroundedState
{
    private float timeToContinue = 2f;
    private float timeToDisappear =2f;
    private float disappearDuration = 2f;
    public DinosaurDieState(Dinosaur _enemyBase, EnemyStateMachine _stateMachine, string _boolName) : base(_enemyBase, _stateMachine, _boolName)
    {
    }

    public override void Update()
    {
        base.Update();
        timeToContinue -= Time.deltaTime;
        if (timeToContinue <= 0)
        {
           timeToDisappear -= Time.deltaTime;
           float alpha = Mathf.Clamp01(timeToDisappear / disappearDuration);
           Color color = enemyBase.sprite.color;
           color.a = alpha;
           enemyBase.sprite.color = color;

           if(timeToDisappear <= 0) 
           {
                enemyBase.gameObject.SetActive(false);
            }

        }
        
    }

    public override void Enter()
    {
        base.Enter();
        enemyBase.enemyBar.enabled = false;
        foreach (CapsuleCollider2D capsule in enemyBase.circle)
        {
            capsule.enabled = false;
        }
        rb.velocity = new Vector2(0, rb.velocity.y);
        enemyBase.box.enabled = true;
    }

    public override void Exit()
    {
        base.Exit();
    }
}
