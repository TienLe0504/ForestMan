using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject pauseMenu;
    public void Home()
    {
        ManageState.instance.SetupNewVolumne();
        ManageState.instance.TurnOffBackground(ManageState.instance.musicGame);
        SceneManager.LoadScene("Main menu");
        Time.timeScale = 1;
    }
    public void Pause()
    {
        ManageState.instance.SetupCurrentVolumne();
        ManageState.instance.SettingZeroVolumne(0);
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void ReStart()
    {
        ManageState.instance.SetupNewVolumne();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void Resume()
    {
        ManageState.instance.SetupNewVolumne();
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
