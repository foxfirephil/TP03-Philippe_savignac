using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrabMov : MonoBehaviour
{
    NavMeshAgent agent;
    public static int hitpoints;
    public ParticleSystem blood;
    public AudioClip Scream;
    public AudioSource ScreamMonster;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //le monstre a plus de hp en fonction de la "sanity"
        hitpoints = Random.Range(4, 8) - Sanity.sanity;
        SetTarget();
    }

    // Update is called once per frame
    void Update()
    {
         
    }
       
        public void SetTarget()
        {
            // ? toutes les secondes, le monstre ajustera la position de sa cible
            InvokeRepeating("UpdateDestination", 0.1f, 1f);

            // ? toutes les 0.5s, le monstre v?rifie si le joueur est a proximit?
            InvokeRepeating("PlayerProximityCheck", 0.1f, 0.5f);
        }

        void UpdateDestination()
        {
            // Si le jeu est finit, on ne fait rien
            if (GameManager.instance.isGameOver)
                return;

            // Ajuster la cible vers le joueur
            agent.SetDestination(GameManager.instance.player.transform.position);
        }

    void PlayerProximityCheck()
    {
            // Si le jeu est finit, on ne fait rien
            if (GameManager.instance.isGameOver)
                return;
        
            // R?cup?re tous les colliders ? proximit?
            Collider[] colliders = Physics.OverlapSphere(transform.position, 0.6f);

            foreach (var item in colliders)
            {
                // Si l'un des collider est celui du joueur, il pert de la "sanity"
                if (item.name == "player")
                {
                Sanity.sanity -= 1;
                Die();
                break;
                }
            }
    }

        // le monstre s'est fait tir?
        public void Shot()
        {
            hitpoints--;

            if (hitpoints < 1)
                Die();
        }

        // Le monstre disparais
        public void Die()
        {
            CancelInvoke("UpdateDestination");
            CancelInvoke("PlayerProximityCheck");
            blood.Play();
            ScreamMonster.PlayOneShot(Scream);
            Destroy(gameObject,2f);
        }
}
