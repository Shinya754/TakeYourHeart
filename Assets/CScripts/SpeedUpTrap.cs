using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpTrap : MonoBehaviour
{
    public Animator AN;
    public bool active = true;
    private void Awake()
    {
        AN.SetBool("Shoe", true);
        EventCenter.AddListener(EventDefine.PlayAgain, INIT);
    }

    private void INIT()
    {
        active = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player1"&active ==true)
        {
            active = false;
            EventCenter.Broadcast(EventDefine.SpeedUp1);
            EventCenter.Broadcast(EventDefine.Goal1plus5);
            AN.SetBool("Shoe", false);
            Invoke("DestoryShoe", 1f);
        }
        if (collision.gameObject.tag == "Player2" & active == true)
        {
            active = false;
            Debug.Log("23333333333333");
            EventCenter.Broadcast(EventDefine.SpeedUp2);
            EventCenter.Broadcast(EventDefine.Goal2plus5);
            AN.SetBool("Shoe", false);
            Invoke("DestoryShoe", 1f);
        }
         if (collision.gameObject.tag == "Player3" & active == true)
        {
            active = false;
            EventCenter.Broadcast(EventDefine.SpeedUp3);
            EventCenter.Broadcast(EventDefine.Goal3plus5);
            AN.SetBool("Shoe", false);
            Invoke("DestoryShoe", 1f);
        }
    }

    void DestoryShoe()
    {
        GameObject.Destroy(this.gameObject);
    }
}
