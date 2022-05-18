using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //instance graphic interface
    public GameObject txtGameOver;
    public GameObject Menu;
    public RawImage SanityBar;
    public RawImage SanityImg1;
    public RawImage SanityImg2;
    public RawImage SanityImg3;

    //instance player et objects
    public GameObject player;
    public GameObject lampe;
    public GameObject gun;

    //instance key items bool
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
        switch(Sanity.sanity)
        { 
            case 3: SanityBar.texture = SanityBar.texture; break;
            case 2: SanityBar.texture = SanityImg1.texture; break;
            case 1: SanityBar.texture = SanityImg2.texture; break;
            case 0: SanityBar.texture = SanityImg3.texture; break;
        }
        //si le joueur n'a plus de "sanity", il perd la partie
        if(Sanity.sanity<=0)
        {
            GameOver();
        }
        if(Input.GetKey(KeyCode.P))
        {
            Cursor.lockState = CursorLockMode.None;
            Menu.SetActive(true);
            Time.timeScale = 0f;
            return;
        }
    }

    public void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        txtGameOver.SetActive(true);
        Time.timeScale = 0f;
        isGameOver = true;
    }
    void btn_quit_click()
    { SceneManager.LoadScene("Accueil"); }
}
