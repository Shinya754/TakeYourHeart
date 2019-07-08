using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public float TimeEnd = 2000f;
    public float TimeLimit = 5f;
    public float timeline=0f;
    // Update is called once per frame
    public int[] Event;
    bool B1 = true;
    bool B2 = true;
    bool B3 = true;
    bool B4 = true;
    float B1t = 0;
    float B2t = 0;
    float B3t = 0;
    float B4t = 0;
    public GameObject GunTower1;
    public GameObject GunTower2;
    public GameObject GunTower3;
    public GameObject GunTower4;

    
    private void Start()
    {
        /*GunTower1 = GameObject.Find("Guard1");
        GunTower2 = GameObject.Find("Guard2");
        GunTower3 = GameObject.Find("Guard3");
        GunTower4 = GameObject.Find("Guard4");*/
        EventCenter.AddListener(EventDefine.Button1Off,Button1ON);
        EventCenter.AddListener(EventDefine.Button2Off,Button2ON);
        EventCenter.AddListener(EventDefine.Button3Off,Button3ON);
        EventCenter.AddListener(EventDefine.Button4Off,Button4ON);
    }
    void Update()
    {
        timeline = Time.time;
        Debug.Log(timeline);
        if (Time.time > TimeEnd)
        {
            Over();
        }
        //开关1
        if (B1 == false & B1t==0)
        {
            GunTower1.GetComponent<BulletSpawn>().SetFlagFalse();
            B1t = timeline;
        }
        else if (B1 == false & timeline-B1t>=TimeLimit)
        {
            B1 = true;
            EventCenter.Broadcast(EventDefine.Button1ON);
            GunTower1.GetComponent<BulletSpawn>().SetFlagTrue();
            B1t = 0;
        }
        //开关2
        if (B2 == false & B2t == 0)
        {
            GunTower2.GetComponent<BulletSpawn2>().SetFlagFalse();
            B2t = timeline;
        }
        else if (B2 == false & timeline - B2t >= TimeLimit)
        {
            B2 = true;
            EventCenter.Broadcast(EventDefine.Button2ON);
            GunTower2.GetComponent<BulletSpawn2>().SetFlagTrue();
            B2t = 0;
        }
        //开关3
        if (B3 == false & B3t == 0)
        {
            GunTower3.GetComponent<BulletSpawn3>().SetFlagFalse();
            B3t = timeline;
        }
        else if (B3 == false & timeline - B3t >= TimeLimit)
        {
            B3 = true;
            EventCenter.Broadcast(EventDefine.Button3ON);
            GunTower3.GetComponent<BulletSpawn3>().SetFlagTrue();
            B3t = 0;
        }
        //开关4
        if (B4 == false & B4t == 0)
        {
            GunTower4.GetComponent<BulletSpawn4>().SetFlagFalse();
            B4t = timeline;
        }
        else if (B4 == false & timeline - B4t >= TimeLimit)
        {
            B4 = true;
            EventCenter.Broadcast(EventDefine.Button4ON);
            GunTower4.GetComponent<BulletSpawn4>().SetFlagTrue();
            B4t = 0;
        }
    }
    public void Button1ON() { 
        
        B1 = false;
    }
    public void Button2ON()
    {
        B2 = false;
    }
    public void Button3ON()
    {
        B3 = false;
    }
    public void Button4ON()
    {
        B4 = false;
    }
    public void Over()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("Account");
    }
}
