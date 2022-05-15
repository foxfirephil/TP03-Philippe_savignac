using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopChaseBox : MonoBehaviour
{
    public GameObject CrabChase1;
    public AudioSource MainClip;
    public AudioSource ChaseClip;
    private bool active = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //détection et activation
        if (other.name == "player" && GameManager.instance.GetKey1 && active)
        {
            CrabChase1.SetActive(false);
            ChaseClip.Stop();
            MainClip.Play();
            active = false;
        }
    }
}
