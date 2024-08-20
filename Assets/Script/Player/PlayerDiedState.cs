using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDiedState : PlayerGroundedState
{
    public PlayerDiedState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.capsule.enabled = false;
        player.box.enabled = true;
        rb.velocity = new Vector2(0, rb.velocity.y);
        player.sprite.color = Color.white;
        PlayerManager.instance.PlayerDied();
    }
    public override void Update()
    {
        base.Update();
    }
    public override void Exit()
    {
        base.Exit();
    }


}
