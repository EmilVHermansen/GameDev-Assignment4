using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeCount : MonoBehaviour
{
    public TextMeshProUGUI lifeCounter;
    public TextMeshProUGUI gameMessage;
    private int counter = 5;
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
    }

}
