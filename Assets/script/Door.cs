using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator anim;
    private BoxCollider doorcol;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        doorcol = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
            
  
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name=="player")
            anim.SetBool("character_nearby", true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "player")
            anim.SetBool("character_nearby", false);
    }
}
