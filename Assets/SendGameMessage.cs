using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SendGameMessage : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateText(string message)
    {
            gameObject.GetComponent<TextMeshProUGUI>().text = message;
    }
}
