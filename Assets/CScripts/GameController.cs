using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private string SceneName;
    // Start is called before the first frame update
    void Start()
    {
        //EventCenter.AddListener(EventDefine.GameOver,gameover);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void gameover()
    {
        SceneManager.LoadScene(SceneName);
    }
}
