using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ManageTime : MonoBehaviour
{
    public static ManageTime instance;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] float timeRemaining; 
    private bool isCountingDown = false;

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
        DecreaseTime();
    }

    public void DecreaseTime()
    {
        isCountingDown = true;
        StartCoroutine(CountdownCoroutine());
    }

    private IEnumerator CountdownCoroutine()
    {
        while (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);

            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            yield return null;
        }

        isCountingDown = false;
        Port.instance.checkFinish = false;
    }

    void Update()
    {
        if (Port.instance.checkFinish)
        {
            isCountingDown = true;
            return;
        }
        if (!isCountingDown)
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
