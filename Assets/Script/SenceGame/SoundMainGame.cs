using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMainGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //ManageState.instance.TurnOnBackground(ManageState.instance.musicMainmenu, ManageState.instance.musicMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PressButton()
    {
        ManageState.instance.PlayOneShortAudio(ManageState.instance.musicButton, ManageState.instance.pressButton);
    }
    public void PressVolumne()
    {
        ManageState.instance.PlayOneShortAudio(ManageState.instance.musicButton, ManageState.instance.pressVolumne);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
