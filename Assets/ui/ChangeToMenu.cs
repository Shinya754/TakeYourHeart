using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToMenu : MonoBehaviour {
    public string sceneName;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ChangeScene()
    {
        EventCenter.Broadcast(EventDefine.PlayAgain);
        SceneManager.LoadScene(sceneName);
        SceneManager.UnloadScene("GameScenes");
    }
}
