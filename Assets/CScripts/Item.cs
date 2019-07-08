using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //得到玩家位置
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public bool PH1 = false;
    public bool PH2 = false;
    public bool PH3 = false;
    public bool Able = false;
    public bool Ct1 = false;
    public bool Ct2 = false;
    public bool Ct3 = false;
    // Start is called before the first frame update
    void Awake()
    {
        Player1 = GameObject.Find("Player1");
        Player2 = GameObject.Find("Player2");
        Player3 = GameObject.Find("Player3");
        //增加监听
        EventCenter.AddListener(EventDefine.Hold1, Follow1);
        EventCenter.AddListener(EventDefine.Hold2, Follow2);
        EventCenter.AddListener(EventDefine.Hold3, Follow3);
        EventCenter.AddListener(EventDefine.Throw1, Throw1);
        EventCenter.AddListener(EventDefine.Throw2, Throw2);
        EventCenter.AddListener(EventDefine.Throw3, Throw3);
    }

    // Update is called once per frame
    void Update()
    {
        if (PH1 == true & Able != false)
        {
            this.transform.position = Player1.transform.position;
        }
        else if(PH2 == true & Able != false)
        {
            this.transform.position = Player2.transform.position;
        }
        else if(PH3 == true & Able != false)
        {
            this.transform.position = Player3.transform.position;
        }
        else if (PH1 == false & PH2 == false&PH3 == false&Able == false& Ct1 == true)          //p1要hold
        {
            Able = true;
            PH1 = true;
        }
        else if (PH1 == false & PH2 == false & PH3 == false & Able == false & Ct2 == true)          //p2要hold
        {
            Able = true;
            PH2 = true;
        }
        else if (PH1 == false & PH2 == false & PH3 == false & Able == false & Ct3 == true)          //p3要hold
        {
            Able = true;
            PH3 = true;
        }
        ////////////////////////////////////////////////////////////////////
        else if (Able == false)          //p1要throw
        {
            PH1 = false;
        }
        else if (Able == false)          //p2要throw
        {
            PH2 = false;
        }
        else if (Able == false)          //p3要throw
        {
            PH3 = false;
        }
        else {
            PH1 = false;
            PH2 = false;
            PH3 = false;
        }
    }
    //跟随玩家
    public void Follow1()
    {
        PH1 = true;
    }
    public void Follow2()
    {
        PH2 = true;
    }
    public void Follow3()
    {
        PH3 = true;
    }
    //被玩家扔出
    public void Throw1()
    {
        Able = false;
    }
    public void Throw2()
    {
        Able = false;
    }
    public void Throw3()
    {
        Able = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player1")
        {
            Ct1 = true;
            //EventCenter.Broadcast(EventDefine.Contact1);
        }
        else if(collision.gameObject.tag == "Play2")
        {
            Ct2 = true;
            //EventCenter.Broadcast(EventDefine.Contact2);
        }
        else if (collision.gameObject.tag == "Play3")
        {
            Ct3 = true;
            //EventCenter.Broadcast(EventDefine.Contact3);
        }
        else
        {
            Ct1 = false;
            Ct2 = false;
            Ct3 = false;
        }
    }
}
