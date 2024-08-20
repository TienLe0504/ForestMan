using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallState : PlayerGroundedState
{
    public PlayerWallState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();
        Move();
    }
    public override void Exit()
    {
        base.Exit();
      
    }
    void Move()
    {
   
        player.SetVelocity(player.buttonControll.GetVelocity()*player.defaultSpeed, rb.velocity.y);
        
        if (player.buttonControll.GetVelocity() == 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
    private void MakeJump()
    {
       
       
    }
}
