using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunGet : MonoBehaviour
{
    bool isNearby = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isNearby && Input.GetKey(KeyCode.E))
        {
            //active le gun
            GameManager.instance.isGunActive = true;
            //detruit l'objet
            Destroy(gameObject);
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
