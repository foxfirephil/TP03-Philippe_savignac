using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PorteEnn : MonoBehaviour
{
    private Animator anim;
    public GameObject crab;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.GetKey1==true)
        { 
            anim.SetBool("character_nearby", true);
            crab.SetActive(true);
            
        }
    }
}
