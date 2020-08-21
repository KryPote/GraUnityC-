using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        player.grounded = true;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        player.grounded = true;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        player.grounded = false;
    }
}
