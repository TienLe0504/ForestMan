using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueGame : MonoBehaviour
{
    public  bool checkBool;
    // Start is called before the first frame update
    void Start()
    {
        checkBool = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PressButton()
    {
        checkBool = true;
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
}
