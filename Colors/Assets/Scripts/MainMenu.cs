﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Graj()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    public void Quit()
    {
        Application.Quit();
    }
}
