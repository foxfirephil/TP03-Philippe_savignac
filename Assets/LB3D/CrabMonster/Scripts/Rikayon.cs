using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rikayon : MonoBehaviour {

    public Animator animator;
	bool die=false;

	// Use this for initialization
	void Start () 
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.G))
		{
			animator.SetTrigger("Die");
		}
		if (transform.position.x>0 && !die)
		{
			animator.SetTrigger("Walk_Cycle_1");
		}
		if(CrabMov.hitpoints<=0)
        {
			animator.SetTrigger("Die");
			die = true;
        }
	}

}
