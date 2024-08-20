using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance;
    [SerializeField] private GameObject comeBack;
    [SerializeField] private GameObject manageState;

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

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoadedOnButton;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoadedOnButton;
    }

    public void SetUpManageState()
    {
        CheckChangeState.ShowManageState = true;
    }

    public void DestroyManageState()
    {
        CheckChangeState.ShowManageState = false;
    }

    void Update()
    {
    }

    private void OnSceneLoadedOnButton(Scene scene, LoadSceneMode mode)
    {

        if (CheckChangeState.ShowManageState)
        {
            comeBack.SetActive(true);
            manageState.SetActive(true);
        }
        else
        {
            comeBack.SetActive(false);
            manageState.SetActive(false);
        }
    }
}
