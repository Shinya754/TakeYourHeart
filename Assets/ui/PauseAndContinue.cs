using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAndContinue : MonoBehaviour {

    public Animator anim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Pause()
    {
        anim.SetBool("isPause", true);
        Debug.Log("1");
    }

    public void TimeFreeze()
    {
        Time.timeScale = 0;
        Debug.Log("2");
    }

    public void Continue()
    {
        Debug.Log("3");
        Time.timeScale = 1;
        anim.SetBool("isPause", false);
        Debug.Log("4");
    }

}
