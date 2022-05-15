using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleBox : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //détection et activation
        if (other.name == "player")
        {
            TextHandler.consoleTxT = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "player")
        {
            TextHandler.consoleTxT = false;
        }
    }
}
