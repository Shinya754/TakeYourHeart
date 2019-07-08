using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public GameObject Scorecontroller;
    public static GameObject heart;
    public static Score instance;
    public Text Score1;
    public Text Score2;
    public Text Score3;
 

    static int  time;
    static int  playerNum;

    [SerializeField]
    public static int player1Score;
    [SerializeField]
    public static int player2Score;
    [SerializeField]
    public static int player3Score;



    CallBack _1add_20 = new CallBack(p1add20);
    CallBack _1add_5 = new CallBack(p1add5);
    CallBack _1mlu_5 = new CallBack(p1mlu5);
    CallBack _1mlu_20 = new CallBack(p1mlu20);

    CallBack _2add_20 = new CallBack(p2add20);
    CallBack _2add_5 = new CallBack(p2add5);
    CallBack _2mlu_5 = new CallBack(p2mlu5);
    CallBack _2mlu_20 = new CallBack(p2mlu20);

    CallBack _3add_20 = new CallBack(p3add20);
    CallBack _3add_5 = new CallBack(p3add5);
    CallBack _3mlu_5 = new CallBack(p3mlu5);
    CallBack _3mlu_20 = new CallBack(p3mlu20);

    CallBack time_hurt = new CallBack(timeHurt);


    private void OnEnable()
    {
        player1Score = 0;
        player2Score = 0;
        player3Score = 0;

        
    }


    void Awake()
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.AddListener(EventDefine.Goal1mlu20,_1mlu_20);
        EventCenter.AddListener(EventDefine.Goal1mlu5,_1mlu_5);
        EventCenter.AddListener(EventDefine.Goal1plus20,_1add_20);
        EventCenter.AddListener(EventDefine.Goal1plus5,_1add_5);

        EventCenter.AddListener(EventDefine.Goal2mlu20,_2mlu_20);
        EventCenter.AddListener(EventDefine.Goal2mlu5,_2mlu_5);
        EventCenter.AddListener(EventDefine.Goal2plus20,_2add_20);
        EventCenter.AddListener(EventDefine.Goal2plus5,_2add_5);

        EventCenter.AddListener(EventDefine.Goal3mlu20,_3mlu_20);
        EventCenter.AddListener(EventDefine.Goal3mlu5,_3mlu_5);
        EventCenter.AddListener(EventDefine.Goal3plus20,_3add_20);
        EventCenter.AddListener(EventDefine.Goal3plus5,_3add_5); ;

        EventCenter.AddListener(EventDefine.GetTime2,time_hurt);

        GameObject.DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update()
    {   
        Score1.text = player1Score.ToString();
        Score2.text = player2Score.ToString();
        Score3.text = player3Score.ToString();

        ScoreAccount.P1Score = player1Score;
        ScoreAccount.P2Score = player2Score;
        ScoreAccount.P3Score = player3Score;
    }


    private void OnDestroy()
    {
        
    }

    private static void timeHurt()
    {
        //time = heart.GetComponent<Heart>().time2;
        //playerNum = heart.GetComponent<Heart>().Token;
        switch (playerNum)
        {
            case 1:
                player1Score += time*(-5);
                break;
            case 2:
                player2Score += time * (-5);
                break;
            case 3:
                player3Score += time * (-5);
                break;
            default:
                Debug.LogWarning("传入的参数TOKEN有误");
                break;
        }
        

    }



    private static void p1add5()
    {
        player1Score += 5;
    }
    private static void p1add20()
    {
        player1Score += 20;
    }
    private static void p1mlu5()
    {
        player1Score += -5; 
    }
    static private void p1mlu20()
    {
        player1Score += -20;
    }

    static private void p2add5()
    {
       player2Score += 5; 
    }
    static private void p2add20()
    {
        player2Score += 20;
    }
    static private void p2mlu5()
    {
        player2Score += -5;
    }
    static private void p2mlu20()
    {
        player2Score += -20 ;
    }

    static private void p3add5()
    {
        player3Score += 5;
    }
    static private void p3add20()
    {
        player3Score += 20;
    }
    static private void p3mlu5()
    {
        player3Score += -5;
    }
    static private void p3mlu20()
    {
        player3Score += -20 ;
    }
}
