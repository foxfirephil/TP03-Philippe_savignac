using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text txtSanity;
    public Text txtBalle;

    public GameObject txtGameOver;
    public GameObject player;
    public GameObject lampe;
    public GameObject gun;
    public bool isGameOver = false;
    public bool isLampActive = false;
    public bool isGunActive = false;
    public bool GetKey1 = false;
    public bool GetKey2 = false;
    public bool GetGenPart = false;
    public bool GenPartActive = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //si la partie est fini
        if (isGameOver)
        {
            return;
        }
        //activer la lampe
        if(isLampActive)
        {
            lampe.SetActive(true);
        }
        //activer le gun
        if(isGunActive)
        {
            gun.SetActive(true);
        }
        txtSanity.text = Sanity.sanity.ToString();
        txtBalle.text = Gun.maxClips.ToString() + "/" + Gun.bullets.ToString();
        //si le joueur n'a plus de "sanity", il perd la partie
        if(Sanity.sanity<=0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        txtGameOver.SetActive(true);
        Time.timeScale = 0f;
        isGameOver = true;
    }

}
