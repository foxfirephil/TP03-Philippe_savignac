using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //[Header("Audio")]
    //public AudioClip clipGunFire;
    //public AudioClip clipGunEmpty;

    //[Header("Particles")]
    //public ParticleSystem psFlare;

    public Camera cam;
    //AudioSource source;

    const int maxBullets = 6;
    int bullets = maxBullets;

    // Start is called before the first frame update
    void Start()
    {
        // Empêche le curseur de sortir de l'écran du jeu
        Cursor.lockState = CursorLockMode.Locked;
        cam = Camera.main;
        Debug.Log(cam);
        //source = GetComponent<AudioSource>();
    }

    void Update()
    {
        // R pour recharger
        if (Input.GetKeyDown(KeyCode.R) && !isRecharging)
            StartCoroutine(Recharge());

        // Tir principal
        if (Input.GetButtonDown("Fire1"))
        {
            // Si j'ai assez de balles ET que je ne suis pas en train de recharger
            if (bullets > 0 && !isRecharging)
            {
                // Créer le rayon du tir (caméra vers la souris)
                Ray gunRay = cam.ScreenPointToRay(Input.mousePosition);

                // Cast du rayon (ais-je toucher quelque chose?)
                if (Physics.Raycast(gunRay, out RaycastHit hit, 100f))
                {
                    Debug.Log(hit.GetType());
                    if (hit.transform.TryGetComponent(out CrabMov crab))
                    {
                        Debug.Log("chek si sa tire");
                        crab.Shot();
                    }
                }

                // Particule du tir
                //psFlare.Play();

                // Son du tir
                //source.PlayOneShot(clipGunFire);

                // Une balle en moins
                bullets--;

                // Si c'était ma dernière balle, je recharge automatiquement
                if (bullets == 0 && !isRecharging)
                    StartCoroutine(Recharge());
            }
            else
            {
                // Si j'essai de tirer sans balles, le son est différent
                //source.PlayOneShot(clipGunEmpty);
            }
        }
    }

    bool isRecharging;

    // Coroutine pour recharger le pistolet
    IEnumerator Recharge()
    {
        isRecharging = true;

        bullets = 0;

        // Attente de 3s avant d'autoriser le tir
        yield return new WaitForSeconds(3f);

        bullets = maxBullets;

        isRecharging = false;
    }

}
