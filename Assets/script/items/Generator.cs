using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    bool isNearby = false;
    public GameObject pieceGen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isNearby && Input.GetKey(KeyCode.E) && GameManager.instance.GetGenPart)
        {
            pieceGen.SetActive(true);
            GameManager.instance.GenPartActive=true;
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
