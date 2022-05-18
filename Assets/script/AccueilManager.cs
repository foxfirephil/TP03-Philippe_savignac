using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AccueilManager : MonoBehaviour
{
    public Animator crabAnim;

    //bouton
    public Button jouerBtn;
    public Button instBtn;
    public Button retourBtn;
    //interface
    public GameObject instuction;
    public GameObject MainInt;

    // Start is called before the first frame update
    void Start()
    {
        crabAnim.SetTrigger("Die");
        jouerBtn.onClick.AddListener(btn_jouer_click);
        instBtn.onClick.AddListener(btn_inst_click);
        retourBtn.onClick.AddListener(btn_retour_click);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void btn_jouer_click()
    { SceneManager.LoadScene("main"); }
    void btn_inst_click()
    {
        instuction.SetActive(true);
        MainInt.SetActive(false);
    }
    void btn_retour_click()
    {
        instuction.SetActive(false);
        MainInt.SetActive(true);
    }
}
