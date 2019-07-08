using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAccount : MonoBehaviour
{
    //int P1Score;
    //int P2Score;
    //int P3Score;

    //尝试
    public static int P1Score = 0;
    public static int P2Score = 0;
    public static int P3Score = 0;


    int[] Rank = { 0, 1, 2, 3 };

    public Text No1;
    public Text No2;
    public Text No3;

    public Text No1S;
    public Text No2S;
    public Text No3S;

  

    void Start()
    {
        
        int P1Score = Score.player1Score;
        int P2Score = Score.player2Score;
        int P3Score = Score.player3Score;
        
        

    }

    // Update is called once per frame
    void Update()
    {
        //No1.text =  
        No1S.text = P1Score.ToString();
        No2S.text = P2Score.ToString();
        No3S.text = P3Score.ToString();
        
    }

    
    }

