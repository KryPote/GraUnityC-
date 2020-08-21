using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameMaster : MonoBehaviour
{

    public int points;
    public Text pointsText;
    public Text pointsText2;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        pointsText.text = ("" + points);
        pointsText2.text = ("" + points);
    }
}
