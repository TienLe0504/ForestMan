using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();
        if (Port.instance.checkFinish)
        {
            Port.instance.WaitForPlayerToStop(rb);
            stateMachine.ChangeState(player.idleState);
            return;
        }
        else
        {
            if (player.checkDide)
            {
                stateMachine.ChangeState(player.diedState);
            }
            else
            {
                if (Mathf.Abs(player.rb.velocity.x) >= 3)
                {
                    player.trailBehind.emitting = true;
                }
                else
                {

                    player.trailBehind.emitting = false;
                }

                if (player.jumpButton.canJump && player.IsGroundDetected())
                {
                    stateMachine.ChangeState(player.jumpState);
                }
                if (!player.IsGroundDetected())
                {
                    stateMachine.ChangeState(player.airState);
                }
                if (player.buttonRun.canRun && player.power > 0 && player.buttonControll.GetVelocity() != 0)
                {
                    stateMachine.ChangeState(player.runState);
                }
                else
                {
                    player.defaultSpeed = player.wallSpeed;
                }
                if (player.joyStickThrow.canThrow && player.IsGroundDetected())
                {
                    stateMachine.ChangeState(player.throwSkillState);
                }

            }
        }
        



    }
    public override void Exit()
    {
        base.Exit();
    }
}
