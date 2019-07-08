using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlowTrap : MonoBehaviour
{
    public Animator AN;

    private void Awake()
    {
        AN.SetBool("Time", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player1"| collision.gameObject.tag == "Player2"| collision.gameObject.tag == "Player3")
        {
            EventCenter.Broadcast(EventDefine.TimeSlow);
            if (collision.gameObject.tag == "Player1")
                EventCenter.Broadcast(EventDefine.Goal1plus5);
            else if (collision.gameObject.tag == "Player2")
                EventCenter.Broadcast(EventDefine.Goal2plus5);
            else if (collision.gameObject.tag == "Player3")
                EventCenter.Broadcast(EventDefine.Goal3plus5);
            AN.SetBool("Time", false);
            Invoke("DestoryTimeTrap", 1f);
        }
        
        
    }

    void DestoryTimeTrap()
    {
        GameObject.Destroy(this.gameObject);
    }
}
