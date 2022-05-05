using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleGen : MonoBehaviour
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
        if (isNearby && Input.GetKey(KeyCode.E) && GameManager.instance.GenPartActive)
        {
            GameManager.instance.GameOver();
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
