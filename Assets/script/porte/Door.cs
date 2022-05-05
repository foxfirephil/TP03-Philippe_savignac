using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
            
  
    }

    //detection de la proximité du joueur
    private void OnTriggerEnter(Collider other)
    {
        if(other.name=="player")
            //ouvre la porte
            anim.SetBool("character_nearby", true);
    }
    //aucune detection du joueur 
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "player")
            //ferme la porte
            anim.SetBool("character_nearby", false);
    }
}
