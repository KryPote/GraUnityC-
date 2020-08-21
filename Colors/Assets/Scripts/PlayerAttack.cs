using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool attacking = false;
    private float attacktimer = 0.3f;
    private float attackCd = 0.3f;

    public Collider2D attackTrigger;
    public GameObject HUDRedPowerup;


    private Animator anim;
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
        HUDRedPowerup.SetActive(false);
    

    }
    // Update is called once per frame
    void Update()
    {
     
        if(Input.GetKeyDown("z") && !attacking && HUDRedPowerup.active)
        {
            SoundManager.PlaySound("atak");
            attacking = true;
            attacktimer = attackCd;
            
            attackTrigger.enabled = true;
        }
        if(attacking)
        {
            if (attacktimer > 0)
            {
                attacktimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }
        anim.SetBool("PressedZ", attacking);
    }
}
