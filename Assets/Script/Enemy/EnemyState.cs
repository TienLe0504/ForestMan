using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState 
{
    public string boolName;
    public EnemyStateMachine stateMachine;
    public Dinosaur enemyBase;
    public float timeTrigger;

    public Rigidbody2D rb;
    
    public EnemyState(Dinosaur _enemyBase,  EnemyStateMachine _stateMachine,string _boolName)
    {
        this.enemyBase = _enemyBase;
        this.stateMachine = _stateMachine;
        this.boolName = _boolName;
    }

    // Start is called before the first frame update
    public virtual void Enter()
    {
        rb = enemyBase.rb;
        enemyBase.anim.SetBool(boolName, true);
    }
    public virtual void Exit() 
    {
        enemyBase.anim.SetBool(boolName, false);
    }
    public virtual void Update()
    {

    }

  

  

    public IEnumerator WaitAndPrint(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
