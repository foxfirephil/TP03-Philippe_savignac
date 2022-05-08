using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampeDoor : MonoBehaviour
{
    public GameObject txtPorteLampe;
    public Animator Crab1;
    private Animator anim;
    private float timer;
    private bool monsterOccur=true;
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
            txtPorteLampe.SetActive(false);
        }
    }
    //detection de la proximité du joueur
    private void OnTriggerEnter(Collider other)
    {
        //verifie le joueur
        if (other.name == "player")
        {
            //vérifie la lampe
            if (GameManager.instance.isLampActive)
            //ouvre la porte
            { 
                anim.SetBool("character_nearby", true);
                if(monsterOccur)
                {
                    Crab1.gameObject.SetActive(true);
                    Crab1.SetTrigger("Die");
                    monsterOccur = false;
                }
            }
            else
            {
                txtPorteLampe.SetActive(true);
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
