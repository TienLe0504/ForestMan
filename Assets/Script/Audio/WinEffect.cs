using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinEffect : MonoBehaviour
{
    public static WinEffect instance;
    [SerializeField] public AudioSource audioSource;
    [SerializeField] private AudioClip clip;
    [SerializeField] public float fadeTime = 1f;
    [SerializeField] public CanvasGroup canvasGroup;
    [SerializeField] public RectTransform rectTransform;
    public List<GameObject> items = new List<GameObject>();
    [SerializeField] private GameObject btnContinue;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance.gameObject);
        }
    }
    void Start()
    {
        ManageState.instance.TurnOffBackground(ManageState.instance.musicGame);
        ManageState.instance.PlayOneShortAudio(ManageState.instance.audioSourceEffect, clip);
        PanelFadeIn();
    }
    public void PlayOneShort()
    {
         audioSource.PlayOneShot(clip);
        PanelFadeIn();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PanelFadeIn()
    {
        canvasGroup.alpha = 0f;
        rectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutElastic);
        canvasGroup.DOFade(1, fadeTime);
        StartCoroutine(ItemAnimation());
        StartCoroutine(WaitToContinue());
        btnContinue.SetActive(true);
    }

    public void PressContinue(string nameScence)
    {
        StartCoroutine(WaitToContinue());
        SceneManager.LoadScene(nameScence);

    }
    IEnumerator WaitToContinue()
    {
        yield return new WaitForSeconds(1f);
    }
    IEnumerator ItemAnimation()
    {
        if (items.Count == 0)
        {
            
        }
        foreach(var item in items)
        {
            item.transform.localScale = Vector3.zero;
        }
        foreach (var item in items)
        {
            item.transform.DOScale(1f, fadeTime).SetEase(Ease.OutBounce);
            yield return new WaitForSeconds(0.25f);
        }
    }

    public void SetVolume(float volumne)
    {
        audioSource.volume = volumne;
    }
}
