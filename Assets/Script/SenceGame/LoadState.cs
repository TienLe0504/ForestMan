using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class LoadState : MonoBehaviour
{
    public static LoadState instance;
    public Action onLoadComplete; 

    public float maxLoad = 100f;
    private float currentLoad;
    [SerializeField] private float loadTime = 6f;
    [SerializeField] Image image;

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
            float value = UnityEngine.Random.Range(0, 20);
            IncreaseLoad(value);
            yield return new WaitForSeconds(loadTime / maxLoad * value);
        }

        image.fillAmount = 1f;
        yield return new WaitForSeconds(6f);
        Debug.Log(StateGame.instance.targetSceneName);
        SceneManager.LoadScene(StateGame.instance.targetSceneName);
        //onLoadComplete.Invoke();
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
}
