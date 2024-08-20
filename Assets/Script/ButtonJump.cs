using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonJump : MonoBehaviour
{
    [SerializeField] public float jumpSpeed = 15f;
    public bool canJump = false;
    public void CallJump()
    {
        canJump = true;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
