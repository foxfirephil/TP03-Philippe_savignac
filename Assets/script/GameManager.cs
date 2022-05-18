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
    public GameObject Loading;
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

    //instance timer
    private float timerLoad=10;

    //instance bouton
    public Button btnQuitMain;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        btnQuitMain.onClick.AddListener(btn_quit_click);
    }

    // Update is called once per frame
    void Update()
    {
        //si la partie est fini
        if (isGameOver)
        {
            return;
        }
        //un timer de 10 sec pour charger le jeu
        if (timerLoad > 0)
        { timerLoad -= Time.deltaTime; }
        if(timerLoad<=0)
        { Loading.SetActive(false); }
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
        //si le joueur met la pause, affiche le Menu
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
        //désactive le curseur
        Cursor.lockState = CursorLockMode.None;
        txtGameOver.SetActive(true);
        //arrete le jeu
        Time.timeScale = 0f;
        isGameOver = true;
    }
    void btn_quit_click()
    { SceneManager.LoadScene("accueil"); }
}
