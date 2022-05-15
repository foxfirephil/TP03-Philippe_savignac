using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipStation : MonoBehaviour
{
    bool isNearby = false;
    bool used = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isNearby && Input.GetKey(KeyCode.E) && !used)
        {
            //ajoute 2 clip au joueur
            Gun.maxClips+=2;
            //le joueur ne peux plus utiliser la station
            used = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //détection et activation
        if (other.name == "player")
        {
            isNearby = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "player")
        {
            isNearby = false;
        }
    }
}
