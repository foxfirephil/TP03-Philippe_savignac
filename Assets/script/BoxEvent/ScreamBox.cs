using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamBox : MonoBehaviour
{
    public AudioSource Walls;
    public AudioClip Scream;
    int multiplier;
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
            multiplier = Random.Range(1, 7);
            //augmente les chances avec la "sanity"
            int call = multiplier - Sanity.sanity;
            if(call>=1)
            { 
                //si c'est 1, un bruit joue
                Walls.PlayOneShot(Scream); 
            }
        }
    }
}
