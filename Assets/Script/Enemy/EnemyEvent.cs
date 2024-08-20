using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEvent : MonoBehaviour
{
    public Dinosaur dinosaur;
    private void Awake()
    {
    }
    void Start()
    {
        dinosaur = GetComponentInParent<Dinosaur>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(dinosaur.injury.position, dinosaur.radiusAttack);
        foreach(Collider2D collider in colliders)
        {
            if(collider.GetComponent<Player>() != null)
            {
                HealthPlayer targets = collider.GetComponent<HealthPlayer>();
                Player player = collider.GetComponent<Player>();
                targets.Dodamage(GetComponentInParent<Dinosaur>().dameByEnemy);
                PlayerManager.instance.player.ShowPositionDamage(GetComponentInParent<Dinosaur>().dameByEnemy);
                ManageState.instance.PlayOneShortAudio(ManageState.instance.auidoInjuried, ManageState.instance.injuried);
                player.Attacked();
                
            }
        }
    }

    public void TurnOnAudioAttack()
    {
        //AudioManager.instance.OneShortAudioEnemy(AudioManager.instance.bite);
        ManageState.instance.PlayOneShortAudio(ManageState.instance.audioSFXEnemy, ManageState.instance.bite);
    }
    public void TurnOffAttack()
    {
        dinosaur.triggerAttack = false;
    }
    public void EnemyDied()
    {
        ManageState.instance.PlayOneShortAudio(ManageState.instance.audioSFXEnemy, ManageState.instance.dinosaurDead);

    }
}
