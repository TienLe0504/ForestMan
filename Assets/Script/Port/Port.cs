
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Port : MonoBehaviour
{
    // Start is called before the first frame update
    public static Port instance;
    Animator anim;
    [SerializeField] private float timeToWait;
    public bool checkFinish;
    public string nameLevel;
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
        SetUp();
    }
    private void SetUp()
    {
        anim = GetComponentInChildren<Animator>();
        checkFinish = false;
    }
    void Start()
    {
        nameLevel = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetBool("Finish", true);
        //WinEffect.instance.PlayOneShort();
        checkFinish = true;
        if (Inventory.instance.itemKey.GetStack() > 0)
        {
            int number = GetLevelNumber(nameLevel);
            if(!ManageState.instance.checkBool.ContainsKey("Level " + (number + 1).ToString()))
            {
                ManageState.instance.checkBool.Add("Level " + (number + 1).ToString(), false);
                ManageState.instance.valueState.Add("Level " + (number + 1).ToString(), 0);
            }
            if (Inventory.instance.itemKey.GetStack() > ManageState.instance.valueState[nameLevel])
            {
                ManageState.instance.valueState[nameLevel]=Inventory.instance.itemKey.GetStack();
                ManageState.instance.checkBool[nameLevel]=true;
                Debug.Log(nameLevel);
                //ManageState.instance.UpdateUIStar(nameLevel);
            }
            if (Inventory.instance.itemKey.GetStack() == 1)
            {
                ChangeState("Win 1");
                //ManageState.instance.valueState[StateGame.instance.targetSceneName] = 1;
            }
            if (Inventory.instance.itemKey.GetStack() == 2)
            {
                ChangeState("Win 2");

                //ManageState.instance.valueState[StateGame.instance.targetSceneName] = 2;
            }
            if (Inventory.instance.itemKey.GetStack() == 3)
            {
                ChangeState("Win 3");
                //StartCoroutine(WaitAndPrint());
                //SceneManager.LoadScene("Win 3");
                //ManageState.instance.valueState[StateGame.instance.targetSceneName] = 3;
            }

        }
        if (Inventory.instance.itemKey.GetStack() == 0)
        {
            ChangeState("Lose");

        }
    }

    public int GetLevelNumber(string levelName)
    {
        string[] parts = levelName.Split(' ');
        int number = int.Parse(parts[parts.Length - 1]);

        return number;
    }

    private void ChangeState(string name)
    {
        ManageState.instance.SaveGame();
        StartCoroutine(WaitAndPrint(name));
    }

    public void WaitForPlayerToStop(Rigidbody2D rb)
    {
        StartCoroutine(waitForPlayer(timeToWait, rb));
    }
    IEnumerator waitForPlayer(float _time, Rigidbody2D rb)
    {
        yield return new WaitForSeconds(_time);
        rb.velocity = Vector2.zero;
    }
    public IEnumerator WaitAndPrint(string name)
    {
        yield return new WaitForSeconds(2f);
        if (name != "Lose")
        {
            ManageState.instance.PlayOneShortAudio(ManageState.instance.audioSourceEffect, ManageState.instance.clipWin);

        }
        else
        {
            ManageState.instance.PlayOneShortAudio(ManageState.instance.audioSourceEffect, ManageState.instance.clipLose);

        }
        SceneManager.LoadScene(name);
    }

}
