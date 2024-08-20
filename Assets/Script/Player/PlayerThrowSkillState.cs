using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowSkillState : PlayerGroundedState
{
    private Vector2 buttonPosition;
    public PlayerThrowSkillState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }
    public void SetButtonPosition(Vector2 position)
    {
        buttonPosition = position;
    }
    public override void Enter()
    {
        base.Enter();
        
    }
    public override void Exit()
    {
        base.Exit();
        player.StartCoroutine("BusyFor", 0.2f);
    }
    public override void Update()
    {
        base.Update();
        player.SetZeroVelocity();
        Vector2 playerDirection = buttonPosition;

        if (!player.joyStickThrow.canThrow)
        {
            stateMachine.ChangeState(player.idleState);
        }

        if (playerDirection.x < 0 && player.facingDir == 1)
        {
            player.Flip();
        }
        else if (playerDirection.x > 0 && player.facingDir == -1)
        {
            player.Flip();
        }
    }

}
