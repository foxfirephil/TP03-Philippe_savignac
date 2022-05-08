using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrabMov : MonoBehaviour
{
    NavMeshAgent agent;
    int hitpoints = 6;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetTarget();
    }

    // Update is called once per frame
    void Update()
    {
         
    }
       
        public void SetTarget()
        {
            // À toutes les secondes, le monstre ajustera la position de sa cible
            InvokeRepeating("UpdateDestination", 0.1f, 1f);

            // À toutes les 0.5s, le monstre vérifie si le joueur est a proximité
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
        
            // Récupère tous les colliders à proximité
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

        // le monstre s'est fait tiré
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
            Destroy(gameObject);
        }
}
