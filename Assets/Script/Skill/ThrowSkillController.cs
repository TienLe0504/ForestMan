using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSkillController : MonoBehaviour
{
    private bool checkThrowSkill;
    private Rigidbody2D rb;
    private CircleCollider2D cd;
    private float time = 0.1f;
    private Animator anim;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<CircleCollider2D>();
        anim = GetComponentInChildren<Animator>();
    }

    public void CreateThrowSkill(Vector2 _Dir, float _swordGravity, float _time)
    {
        if(cd == null)
        {
            Debug.Log("null circle");
        }
        if (_Dir.x < 0)
        {

            Vector3 newScale = transform.localScale;
            newScale.y = -newScale.y;
            transform.localScale = newScale;
        }
        else
        {
            Vector3 newScale = transform.localScale;
            newScale.x = Mathf.Abs(newScale.x);
            transform.localScale = newScale;
        }
        time = _time;
        checkThrowSkill = true;
        rb.velocity = _Dir;
        rb.gravityScale = _swordGravity;
    }

    void Update()
    {
        if (checkThrowSkill)
        {
            
            transform.right = rb.velocity.normalized; // Đảm bảo hướng được điều chỉnh đúng
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground") || collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
           

            checkThrowSkill = false;
            cd.enabled = false;
            rb.isKinematic = true;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            transform.parent = collision.transform;
            //AudioManager.instance.OneShortAudio(AudioManager.instance.explode);
            ManageState.instance.PlayOneShortAudio(ManageState.instance.audioSFXWeapon, ManageState.instance.explode);
            WaitATime(time);


        }
    }
    public void WaitATime(float time)
    {
        StartCoroutine(WaitAndPrint(time));
        anim.SetBool("Explode", false);
    }
    IEnumerator WaitAndPrint(float time)
    {
        yield return new WaitForSeconds(time);
        anim.SetBool("Explode", true);
    }



}
