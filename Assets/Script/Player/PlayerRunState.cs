using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerGroundedState
{
    private float timeToDeplay=0.5f;
    public PlayerRunState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.defaultSpeed = player.runSpeed;
    }
    public override void Update()
    {
        base.Update();
        player.SetVelocity(player.buttonControll.GetVelocity() * player.defaultSpeed, rb.velocity.y);
        player.power -= player.timeDecreasePower * Time.deltaTime * timeToDeplay;
        HealthManager.instance.powerBar.DecreasePower(player.timeDecreasePower * Time.deltaTime*timeToDeplay);
        if (!player.buttonRun.canRun || player.power <= 0)
        {

            player.buttonRun.canRun = false;
            stateMachine.ChangeState(player.idleState);
        }
        if (player.buttonControll.GetVelocity() == 0 && player.power>0)
        {
            player.buttonRun.canRun = true;
            stateMachine.ChangeState(player.idleState);
        }
       

    }
    public override void Exit()
    {
        base.Exit();
        
    }
}
