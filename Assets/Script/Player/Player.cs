using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [Header("Move info")]
    public float timeDecreasePower = 1f;
    public float defaultSpeed=0;
    public float wallSpeed = 4f;
    public float runSpeed = 10f;
    public float jumpForce = 10f;
    public float power = 20f;
    [Header("Button")]
    public ButtonControll buttonControll;
    public ButtonJump jumpButton;
    public ButtonRun buttonRun;
    //public ButtonThrow buttonThrow;
    public JoyStickThrow joyStickThrow;
    public bool checkDide;
    public BoxCollider2D box;
    public CapsuleCollider2D capsule;

    [Header("Health")]
    [SerializeField] private GameObject blood;
    [SerializeField] private ParticleSystem bloodEffect;
    public float dameByPlayer = 7f;
    public HealthPlayer healthPlayer;
    [SerializeField] public ParticleSystem healEffect;
    [SerializeField] public ParticleSystem powerEffect;
    [Header("Trail")]
    public TrailRenderer trailBehind;
   
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerWallState wallState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerRunState runState { get; private set; }
    public PlayerDiedState diedState { get; private set; }

    public PlayerThrowSkillState throwSkillState { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this,stateMachine,"Idle");
        wallState = new PlayerWallState(this, stateMachine, "Wall");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine, "Jump");
        runState = new PlayerRunState(this, stateMachine, "Run");
        throwSkillState = new PlayerThrowSkillState(this, stateMachine, "Throw");
        diedState = new PlayerDiedState(this, stateMachine, "Died");
        box = GetComponent<BoxCollider2D>();
        capsule = GetComponent<CapsuleCollider2D>();
        trailBehind = GetComponentInChildren<TrailRenderer>();
        trailBehind.sortingLayerName = "Player";
        trailBehind.sortingOrder = -2;
        trailBehind.emitting = false;
        checkDide = false;
        box.enabled = false;
        health = 100;
        bloodEffect.Stop();
        healEffect.Stop();
        powerEffect.Stop();
        healthPlayer = GetComponent<HealthPlayer>();

        
    }

    protected override void Start()
    {
        base.Start();
            ManageState.instance.TurnOnBackground(ManageState.instance.musicGame, ManageState.instance.background);
        stateMachine.Initialize(idleState);
    }
    public override void Update()
    {
        base.Update();

        stateMachine.currentState.Update();


    }

    public IEnumerable BusyFor(float time)
    {
        yield return new WaitForSeconds(time);
    }
   
    public void Attacked()
    {
        //Instantiate(blood,rb.transform.position,Quaternion.identity);
        bloodEffect.Stop();
        bloodEffect.Play();
        ParticleSystemRenderer psRenderer = bloodEffect.GetComponent<ParticleSystemRenderer>();
        if (psRenderer != null)
        {
            psRenderer.sortingLayerName = "Player"; 
            psRenderer.sortingOrder = -2; 
        }
        ChangeColorByAttack();
        sprite.color = Color.white;
    }
    public void ImpoveEffect(ParticleSystem particleSystem)
    {

        particleSystem.Stop();
        particleSystem.Play();
        ParticleSystemRenderer psRenderer = particleSystem.GetComponent<ParticleSystemRenderer>();
        psRenderer.sortingLayerName = "Player";
        psRenderer.sortingOrder= -2;
    }


}
