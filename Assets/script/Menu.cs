using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject ImgLampe;
    public GameObject ImgGun;
    public GameObject ImgGenPart;
    public GameObject ImgKey1;
    public GameObject ImgKey2;
    public Text ClipsTxT;

    public Button RetourBtn;
    public Button QuiterBtn;
    // Start is called before the first frame update
    void Start()
    {
        RetourBtn.onClick.AddListener(btn_play_clik);
        QuiterBtn.onClick.AddListener(btn_quit_clik);
    }

    // Update is called once per frame
    void Update()
    {
        //affiche la lampe
        if(GameManager.instance.isLampActive)
        { ImgLampe.SetActive(true); }

        //affiche le gun
        if (GameManager.instance.isGunActive)
        { 
            ImgGun.SetActive(true);
            ClipsTxT.text = "Chargeurs : " + Gun.maxClips.ToString();
        }

        //affiche la piece
        if (GameManager.instance.GetGenPart)
        { ImgGenPart.SetActive(true); }

        //affiche la clé1
        if (GameManager.instance.GetKey1)
        { ImgKey1.SetActive(true); }

        //affiche la clé2
        if (GameManager.instance.GetKey2)
        { ImgKey2.SetActive(true); }

    }

    void btn_play_clik()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void btn_quit_clik()
    {
        SceneManager.LoadScene("accueil");
    }
}
