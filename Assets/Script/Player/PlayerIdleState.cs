using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }


    // Start is called before the first frame update
    public override void Enter()
    {
        base.Enter();
        
    }
    public override void Update()
    {
        player.SetZeroVelocity();
        base.Update();

        if (player.buttonControll.GetVelocity() != 0 && !player.buttonRun.canRun)
        {
            stateMachine.ChangeState(player.wallState);
        }
    }
    public override void Exit()
    {
        base.Exit();
  
    }
}
