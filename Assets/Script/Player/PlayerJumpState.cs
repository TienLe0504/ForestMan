using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    // Start is called before the first frame update
    public override void Enter()
    {
        base.Enter();
        rb.velocity = new Vector2(rb.velocity.x, player.jumpForce);
        //AudioManager.instance.OneShortAudio(AudioManager.instance.jump);
        ManageState.instance.PlayOneShortAudio(ManageState.instance.audioSFXPlayer, ManageState.instance.jump);

    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
        player.SetVelocity(player.buttonControll.GetVelocity() * player.defaultSpeed, rb.velocity.y);
        if (rb.velocity.y < 0)
        {
            stateMachine.ChangeState(player.airState);
        }
    }
}
