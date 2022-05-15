using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHandler : MonoBehaviour
{
    public static bool consoleTxT=false;
    public GameObject txtConsole;
    float timer = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //si le joueur se rend a la console
        if(consoleTxT)
        {
            if (timer > 0)
            {
                //affiche le texte pendant 5 sec
                timer -= Time.deltaTime;
                txtConsole.SetActive(true);
            }
            if (timer <= 0)
            {
                //a la fin du timer il efface le texte
                txtConsole.SetActive(false);
            }
        }
    }
}
