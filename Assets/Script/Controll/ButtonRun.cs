using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonRun : MonoBehaviour
{
    public bool canRun;
    public Player player;
    
    private void Awake()
    {
        canRun = false;
    }

    public void CallRun()
    {
        if (player.power > 0)
        {
             canRun = !canRun;

        }
        if(player.power>0&& canRun)
        {
            //AudioManager.instance.PlayOneShortAudio(AudioManager.instance.audioSFXHealth, AudioManager.instance.increaseSpeed);
            ManageState.instance.PlayOneShortAudio(ManageState.instance.audioSFXHealth, ManageState.instance.increaseSpeed);

        }
    }
}
