using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBox : MonoBehaviour
{
    public GameObject crabSpawn;
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
        if (other.name == "player" && GameManager.instance.GetKey2)
        {
            multiplier = Random.Range(1, 7);
            //augmente les chances avec la "sanity"
            int call = multiplier - Sanity.sanity;
            //si c'est 1
            if (call >= 1)
            { 
                //active le crab
                crabSpawn.SetActive(true);
            }
        }
    }
}
