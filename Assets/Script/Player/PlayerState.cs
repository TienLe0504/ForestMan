using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Rigidbody2D rb;
    protected Player player;
    protected PlayerStateMachine stateMachine;


    private string animBoolName;
    protected bool triggerCalled;


    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(animBoolName, true);
        rb = player.rb;
        triggerCalled = false;
    }


    // Update is called once per frame
    public virtual void Update()
    {
        SetYVelocity();
    }
    private void SetYVelocity()
    {
        player.anim.SetFloat("Speed", rb.velocity.y);

    }
    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);
    }

    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}
