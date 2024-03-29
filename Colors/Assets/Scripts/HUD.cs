﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Sprite[] HeartSprites;

    public Image HeartUI;

    private PlayerController player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Gracz").GetComponent<PlayerController>();

    }
    void Update()
    {
        HeartUI.sprite = HeartSprites[player.curHealth];
    }

}
