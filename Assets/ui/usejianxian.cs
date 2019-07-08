using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class usejianxian : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("fiction", 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void fiction()
    {
        jianxian.Instance.UIHide();
    }
}
