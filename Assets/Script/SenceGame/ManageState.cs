
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManageState : MonoBehaviour
{
    public static ManageState instance;
    public Dictionary<string, int> valueState;
    public Dictionary<string, bool> checkBool;
    public List<ManageStar> manageStars;
    private float volumne = 1f;
    public List<ManageBatery> manageBatery;
    [Header("Win effect")]
    [SerializeField] public AudioSource audioSourceEffect;
    [SerializeField] public AudioClip clipWin;
    [SerializeField] public AudioClip clipLose;

    [Header("AudioManager")]
    [SerializeField] public AudioSource musicButton;
    [SerializeField] public AudioSource musicMainmenu;
    [SerializeField] public AudioSource musicGame;
    [SerializeField] public AudioSource audioSFXPlayer;
    [SerializeField] public AudioSource audioSFXEnemy;
    [SerializeField] public AudioSource audioSFXHealth;
    [SerializeField] public AudioSource audioSFXWeapon;
    [SerializeField] public AudioSource auidoInjuried;
    [SerializeField] public AudioSource auidoSFXEntity;

    [SerializeField] public AudioClip background;
    [SerializeField] public AudioClip jump;
    [SerializeField] public AudioClip throwStone;
    [SerializeField] public AudioClip explode;

    [SerializeField] public AudioClip healing;
    [SerializeField] public AudioClip bite;
    [SerializeField] public AudioClip injuried;

    [SerializeField] public AudioClip entity;
    [SerializeField] public AudioClip dinosaurDead;
    [SerializeField] public AudioClip increaseSpeed;

    [Header("Music menu")]
    [SerializeField] public AudioClip musicMenu;
    [SerializeField] public AudioClip pressButton;
    [SerializeField] public AudioClip pressVolumne;


    public float currenVolumne;
    public bool continuePlayeGame;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        volumne = Mathf.Clamp(PlayerPrefs.GetFloat("Volume", 1f), 0f, 1f);
        
        valueState = new Dictionary<string, int>();
        checkBool = new Dictionary<string, bool>();
        LoadGame();
        manageStars = new List<ManageStar>();
        manageBatery = new List<ManageBatery>();
    
        FindAllManageStars();
        UpdateUIStar();
        FindAllManangeBatery();
        UpdateUIBaterySound();
        SetUpBoolLevel();
        //TurnOnBackground(musicMainmenu, musicMenu);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    private void SetUpBoolLevel()
    {
        if (!valueState.ContainsKey("Level 1"))
        {
            valueState.Add("Level 1", 0);
            checkBool.Add("Level 1", false);
        }
    }


    void Update()
    {
        Debug.Log("volumne " + volumne);
        Debug.Log("current volumne " + currenVolumne);
    }

    public void UpdateUIStar()
    {
        foreach (ManageStar manage in manageStars)
        {
            int number = GetLevelNumber(manage.levelName);
            string name = "Level " + (number - 1).ToString();

            if (checkBool.ContainsKey(manage.levelName))
            {
                if (manage.levelName != "Level 1" && checkBool[name])
                {
                    manage.off.SetActive(false);
                    manage.on.SetActive(true);
                }
                if (checkBool[manage.levelName])
                {
                    UpDateStarForState(manage);
                }
            }
        }
    }

    public int GetLevelNumber(string levelName)
    {
        string[] parts = levelName.Split(' ');
        int number = int.Parse(parts[parts.Length - 1]);

        return number;
    }

    private void UpDateStarForState(ManageStar manage)
    {
        if (valueState[manage.levelName] == 1)
        {
            manage.star1.SetActive(true);
            manage.star2.SetActive(false);
            manage.star3.SetActive(false);
        }
        else if (valueState[manage.levelName] == 2)
        {
            manage.star1.SetActive(false);
            manage.star2.SetActive(true);
            manage.star3.SetActive(false);
        }
        else if (valueState[manage.levelName] == 3)
        {
            manage.star1.SetActive(false);
            manage.star2.SetActive(false);
            manage.star3.SetActive(true);
        }
    }

    private void FindAllManageStars()
    {
        manageStars.Clear();
        ManageStar[] allStars = Resources.FindObjectsOfTypeAll<ManageStar>();
        foreach (ManageStar star in allStars)
        {
            manageStars.Add(star);
        }
    }
    private void FindAllManangeBatery()
    {
        manageBatery.Clear();
        ManageBatery[] allBatetry = Resources.FindObjectsOfTypeAll<ManageBatery>();
        foreach(ManageBatery batery in allBatetry)
        {
            manageBatery.Add(batery);
        }
        manageBatery.Sort((a, b) => a.bateryNumber.CompareTo(b.bateryNumber));
    }
    public void UpdateUIBaterySound()
    {
        volumne = Mathf.Clamp(PlayerPrefs.GetFloat("Volume", 1f), 0f, 1f);
        float n = volumne;

            int pinsToActivate = Mathf.RoundToInt(n * 10);

            for (int i = 0; i < manageBatery.Count; i++)
            {
                if (i < pinsToActivate)
                {
                    manageBatery[i].on.SetActive(true);
                    manageBatery[i].off.SetActive(true);
                }
                else
                {
                    manageBatery[i].on.SetActive(false);
                    manageBatery[i].off.SetActive(true);
                }
            }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        FindAllManageStars();
        UpdateUIStar();
        FindAllManangeBatery();
        UpdateUIBaterySound();
    }


    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void TurnOnBackground(AudioSource audioSource, AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void TurnOffBackground(AudioSource audioSource)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void PlayOneShortAudio(AudioSource audioSource, AudioClip audioClip)
    {
        if (audioSource != null && audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip is null");
        }
    }

    public void SetupVolume()
    {
        musicGame.volume = volumne;
        audioSFXPlayer.volume = volumne;
        audioSFXEnemy.volume = volumne;
        audioSFXHealth.volume = volumne;
        audioSFXWeapon.volume = volumne;
        auidoInjuried.volume = volumne;
        auidoSFXEntity.volume = volumne;
        audioSourceEffect.volume = volumne;
        musicButton.volume = volumne;
        musicMainmenu.volume = volumne;
        SaveVolume();
    }


    private void SaveVolume()
    {
        PlayerPrefs.SetFloat("Volume", volumne);
        PlayerPrefs.Save();
    }
    public void DecreaseSound()
    {
        volumne -= 0.1f;
        if(volumne < 0f)
        {
            volumne = 0f;
        }
        SetupVolume();
        UpdateUIBaterySound();
    }
    public void IncreaseSound()
    {
        volumne +=0.1f;
        if(volumne > 1f)
        {
            volumne = 1f;
        }
        SetupVolume();
        UpdateUIBaterySound();
    }
    public void SettingZeroVolumne(float _volumne)
    {
        volumne = _volumne;
        SetupVolume();
        UpdateUIBaterySound();
    }
    public void SetupCurrentVolumne()
    {
        currenVolumne = volumne;
    }
    public void SetupNewVolumne()
    {
        volumne = currenVolumne;
        SetupVolume();
        UpdateUIBaterySound();
    }
    public void SaveGame()
    {
        SaveSystem.SaveData(valueState, checkBool);
    }

    public void LoadGame()
    {
        DataGame data = SaveSystem.LoadData();
        if (data != null)
        {
            valueState = data.valueState;
            checkBool = data.checkBool;
        }
    }


}
