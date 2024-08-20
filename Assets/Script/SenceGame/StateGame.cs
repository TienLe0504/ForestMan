using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateGame : MonoBehaviour
{
    public static StateGame instance;
    private LoadState loadState;
    public string targetSceneName;
    void Start()
    {
        
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance.gameObject);
        }
       
    }
    public void LoadSence(int index)
    {
        string nameLevel = "Level " + (index - 1).ToString();
        string gameIndex = index.ToString();
        targetSceneName = "Level " + gameIndex;
        ManageState.instance.PlayOneShortAudio(ManageState.instance.musicButton, ManageState.instance.pressButton);
        if (index!=1)
        {
            if (!ManageState.instance.checkBool.ContainsKey(nameLevel))
            {
                ManageState.instance.checkBool.Add(nameLevel, false);
                ManageState.instance.valueState.Add(nameLevel, 0);
            }

            if (ManageState.instance.checkBool[nameLevel])
            {
                if (!ManageState.instance.valueState.ContainsKey(targetSceneName))
                {
                    ManageState.instance.checkBool.Add(targetSceneName, false);
                    ManageState.instance.valueState.Add(targetSceneName,0);

                }
                ManageState.instance.TurnOffBackground(ManageState.instance.musicMainmenu);
                SceneManager.LoadScene("LoadState");

            }

        }
        if (index == 1)
        {
            ManageState.instance.TurnOffBackground(ManageState.instance.musicMainmenu);
            SceneManager.LoadScene("LoadState");

        }

    }

}
