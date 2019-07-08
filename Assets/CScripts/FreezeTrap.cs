using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTrap : MonoBehaviour
{
    public Animator AN;
    public GameObject Debuff1;
    public GameObject Debuff2;
    public GameObject Debuff3;
    public bool able=true;

    private void Awake()
    {
        Debuff1 = GameObject.Find("P1_Debuff");
        Debuff2 = GameObject.Find("P2_Debuff");
        Debuff3 = GameObject.Find("P3_Debuff");
        EventCenter.AddListener(EventDefine.PlayAgain,INIT);
        
    }

    void DestoryTrap()
    {
        GameObject.Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.tag == "Player1" & able == true)
        {
            //Debug.Log("2333333333");
            EventCenter.Broadcast(EventDefine.Freeze1);
            EventCenter.Broadcast(EventDefine.Goal1mlu5);
            
            AN.SetBool("IsFreezed", true);
            Debuff1.GetComponent<Animator>().SetBool("Freeze", true);
            Invoke("DestoryTrap", 1f);
            able = false;
        }
        if (collision.gameObject.tag == "Player2" & able == true)
        {
            EventCenter.Broadcast(EventDefine.Freeze2);
            EventCenter.Broadcast(EventDefine.Goal2mlu5);
            
            AN.SetBool("IsFreezed", true);
            Debuff2.GetComponent<Animator>().SetBool("Freeze", true);

            Invoke("DestoryTrap", 1f);
            able = false;
        }
        if (collision.gameObject.tag == "Player3" & able == true)
        {
            EventCenter.Broadcast(EventDefine.Freeze3);
            EventCenter.Broadcast(EventDefine.Goal3mlu5);
            
            AN.SetBool("IsFreezed", true);
            Debuff3.GetComponent<Animator>().SetBool("Freeze", true);

            Invoke("DestoryTrap", 1f);
            able = false;
        }
    }
    public void INIT()
    {
        able = true;
    }
}
