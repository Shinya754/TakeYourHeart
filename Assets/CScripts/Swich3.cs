﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swich3 : MonoBehaviour
{
    bool awake = true;
    public Sprite SP1;
    public Sprite SP2;
    public static int ONorOFF = 0;
    private void Start()
    {
        EventCenter.AddListener(EventDefine.Button3ON, SwichON);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player1" & awake == true)
        {
            ONorOFF = 1;
            EventCenter.Broadcast(EventDefine.Button3Off);
            EventCenter.Broadcast(EventDefine.Goal1plus5);
            awake = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = SP1;
        }
        else if (collision.gameObject.tag == "Player2" & awake == true)
        {
            ONorOFF = 1;
            EventCenter.Broadcast(EventDefine.Button3Off);
            EventCenter.Broadcast(EventDefine.Goal2plus5);
            awake = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = SP1;
        }
        else if (collision.gameObject.tag == "Player3" & awake == true)
        {
            ONorOFF = 1;
            EventCenter.Broadcast(EventDefine.Button3Off);
            EventCenter.Broadcast(EventDefine.Goal3plus5);
            awake = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = SP1;
        }
    }
    public void SwichON()
    {
        ONorOFF = 0;
        gameObject.GetComponent<SpriteRenderer>().sprite = SP2;
        awake = true;
    }
}