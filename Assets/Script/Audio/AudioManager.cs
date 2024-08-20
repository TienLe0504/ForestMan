using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] public AudioSource music;
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

    private float volume = 1f;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        music = GetComponentInChildren<AudioSource>();
        audioSFXPlayer = GetComponentInChildren<AudioSource>();
        //TurnOnBackground();
        //LoadVolume();
    }

    public void TurnOnBackground()
    {
        music.clip = background;
        music.loop = true;
        music.Play();
    }
    public void TurnOffBackground()
    {
        if (music.isPlaying)
        {
            music.Stop();
        }
    }
    public void OneShortAudio(AudioClip audioClip)
    {
        audioSFXPlayer.PlayOneShot(audioClip);

    }

    public void OneShortAudioEnemy(AudioClip audio)
    {
        audioSFXEnemy.PlayOneShot(audio);
    }

    public void PlayOneShortAudio(AudioSource audioSource,AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SetVolume(float volume)
    {
        this.volume = volume;
        music.volume = volume;
        audioSFXPlayer.volume = volume;
        audioSFXEnemy.volume = volume;
        audioSFXHealth.volume = volume;
        audioSFXWeapon.volume = volume;
        auidoInjuried.volume = volume;
        auidoSFXEntity.volume = volume;
        SaveVolume();
    }
    public float GetVolume()
    {
        return volume;
    }
    private void SaveVolume()
    {
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }
    private void LoadVolume()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            volume = PlayerPrefs.GetFloat("Volume");
            SetVolume(volume);
        }
    }
}
