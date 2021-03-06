﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeCount : MonoBehaviour
{
    public TextMeshProUGUI lifeCounter;
    public TextMeshProUGUI gameMessage;
    private int counter = 100;
    private float shadeOfRed = 0;
    // Start is called before the first frame update
    void Start()
    {
        updateText();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Decrement()
    {
        if (counter > 0)
        {
            counter--;
            updateText();
        }
    }

    void updateText()
    {
        if (counter == 0)
        {
            gameMessage.text = "GAME OVER";
        }
        lifeCounter.text = "Lives: " + counter;
        lifeCounter.color = new Color(shadeOfRed / 100,0,0,1);
        shadeOfRed++;
        

    }

}
