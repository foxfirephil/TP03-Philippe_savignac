using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteCle2 : MonoBehaviour
{
    public GameObject txtPorteCle2;
    private Animator anim;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer < 0)
        {
            txtPorteCle2.SetActive(false);
        }
    }
    //detection de la proximit? du joueur
    private void OnTriggerEnter(Collider other)
    {
        //verifie le joueur
        if (other.name == "player")
        {
            //v?rifie la lampe
            if (GameManager.instance.GetKey2)
            //ouvre la porte
            { anim.SetBool("character_nearby", true); }
            else
            {
                txtPorteCle2.SetActive(true);
                timer = 5f;
            }
        }
    }
    //aucune detection du joueur 
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "player")
            //ferme la porte
            anim.SetBool("character_nearby", false);
    }
}
