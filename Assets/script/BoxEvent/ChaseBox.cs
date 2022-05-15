using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBox : MonoBehaviour
{
    public GameObject crabChase;
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
        if (other.name == "player" && GameManager.instance.GetKey2)
        {
            //si le joueur prend la clé le crab le chasse
            crabChase.SetActive(true);
        }
    }
}
