using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBox : MonoBehaviour
{
    public GameObject crabChase;
    public AudioSource MainClip;
    public AudioSource ChaseClip;
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
        //d?tection et activation
        if (other.name == "player" && GameManager.instance.GetKey2)
        {
            //si le joueur prend la cl? le crab le chasse
            crabChase.SetActive(true);
            MainClip.Stop();
            ChaseClip.Play();
        }
    }
}
