using System.Collections;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;
    public ThrowSkill throwSkill;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        throwSkill = GetComponent<ThrowSkill>();
    }

    void Update()
    {

    }

    public void WaitTimeToContinue(float time, System.Action callback)
    {
        StartCoroutine(WaitAndExecute(time, callback));
    }

    private IEnumerator WaitAndExecute(float time, System.Action callback)
    {
        yield return new WaitForSeconds(time);
        callback?.Invoke();
    }
}
