using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadGame : MonoBehaviour
{
    [Header("Load Game Info")]
    public float maxLoad = 100f;
    private float currentLoad;
    [SerializeField] private float loadTime = 5f;
    [SerializeField] Image image;
    [SerializeField] private string nextSceneName;
    int n = 10;

    [Header("Win effect")]
    [SerializeField] public AudioSource audioSourceEffect;
    [SerializeField] public AudioClip clipWin;
    [SerializeField] public AudioClip clipLose;

    [Header("AudioManager")]
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

    private void Awake()
    {
        //if (instance == null)
        //{
        //    Debug.Log("null awake");
        //    instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else if (instance != this)
        //{
        //    Debug.Log("not null awake");

        //    Destroy(gameObject);
        //}
    }

    void Start()
    {
        //music=GetComponentInChildren<AudioSource>();
        //if (music == null)
        //{
        //    Debug.Log("null roi");
        //}
        //else
        //{
        //    Debug.Log("ko null");
        //}
        //if (LoadGame.instance.background == null)
        //{
        //    Debug.Log("null backgroud load game");
        //}
        //else
        //{
        //    Debug.Log("no null back game");
        //}
        LoadScenceGame();
    }

    public void LoadScenceGame()
    {
        image.fillAmount = 0f;
        currentLoad = 0;
        StartCoroutine(LoadCoroutine());
    }

    IEnumerator LoadCoroutine()
    {
        while (currentLoad < maxLoad)
        {
            float value = Random.Range(0, 20);
            IncreaseLoad(value);
            yield return new WaitForSeconds(loadTime / maxLoad * value);
        }

        image.fillAmount = 1f;
        yield return new WaitForSeconds(6f);

        OnLoadComplete();
    }

    public void IncreaseLoad(float value)
    {
        currentLoad += value;
        currentLoad = Mathf.Clamp(currentLoad, 0f, maxLoad);
        UpdateLoad();
    }

    private void UpdateLoad()
    {
        float targetFill = currentLoad / maxLoad;
        image.DOFillAmount(targetFill, loadTime / maxLoad * currentLoad);
    }

    private void OnLoadComplete()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneCurrentName = currentScene.name;

        if (sceneCurrentName == "LoadGame")
        {
            SceneManager.LoadScene("Main menu");
        }
    }

    
}
