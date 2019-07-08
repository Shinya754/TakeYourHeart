using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickTrap : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.tag == "Player1")
            {
                EventCenter.Broadcast(EventDefine.Hit1);
                EventCenter.Broadcast(EventDefine.Goal1mlu5);
            }
            else if (collision.gameObject.tag == "Player2")
            {
            EventCenter.Broadcast(EventDefine.Hit2);
            EventCenter.Broadcast(EventDefine.Goal2mlu5);
            }
            else if (collision.gameObject.tag == "Player3")
            {
            EventCenter.Broadcast(EventDefine.Hit3);
            EventCenter.Broadcast(EventDefine.Goal3mlu5);
            }
        GameObject.Destroy(this.gameObject);
    }
}
