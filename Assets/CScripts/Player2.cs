using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    Vector2 fv;
    public AudioClip ASD, ASF, ASS, AST;
    public AudioSource AS;
    public float t1;
    public float t2;
    public float t3;
    public string Color = "Blue";
    public Transform PlayerTransform;
    public float m_speed = 5f;
    public Animator AN;
    public bool Hold = false;
    public bool Freezen = false;
    public bool PlayerContact = false;
    public bool TimeSlowContact = false;
    public bool SpeedUpContact = false;
    float Speed = 1f;
    public static int ONorOFF = 0;
    // Update is called once per frame
    private void Start()
    {
        EventCenter.AddListener(EventDefine.Freeze2, Freeze);
        EventCenter.AddListener(EventDefine.SpeedUp2, SpeedUp);
        EventCenter.AddListener(EventDefine.TimeSlow, TimeSlow);
        EventCenter.AddListener(EventDefine.PlayerContact2, OnPlayerConnect);
        EventCenter.AddListener(EventDefine.St2, StickTrap);
    }
    void Update()
    {
        float LeftOrRight = 0;
        float UpOrDown = 0;
        if (Input.GetKey(KeyCode.LeftArrow) & Freezen == false)
        {
            LeftOrRight = -1;
        }
        if (Input.GetKey(KeyCode.DownArrow) & Freezen == false)
        {
            UpOrDown = -1;
        }
        if (Input.GetKey(KeyCode.RightArrow) & Freezen == false)
        {
            LeftOrRight = 1;
        }
        if (Input.GetKey(KeyCode.UpArrow) & Freezen == false)
        {
            UpOrDown = 1;
        }
        Vector3 movement = new Vector3(0, 0, 0);
        movement.x = LeftOrRight;
        movement.y = UpOrDown;
        AN.SetFloat("Magnitude", movement.magnitude);
        AN.SetFloat("LeftOrRight", movement.x);
        if (Freezen == false)
        {
            transform.position =  transform.position + m_speed *Speed * movement * Time.deltaTime;
        }




        if (Input.GetKey(KeyCode.Keypad0) & Hold == false)   //捡起物品
        {
            EventCenter.Broadcast(EventDefine.Hold2);
            Hold = true;
        }
        else if (Input.GetKey(KeyCode.Keypad0) & Hold == true)   //扔下物品
        {
            EventCenter.Broadcast(EventDefine.Throw2);
            Hold = false;
        }
        if (Freezen == true)
        {
            FreezenContacted(t1);
        }
        if (SpeedUpContact == true)
        {
            SpeedUpContacted(t2);
        }
        if (TimeSlowContact == true)
        {
            TimeSlowContacted(t3);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")      //撞击弹幕
        {
            AS.clip = ASD;
            AS.Play();
            EventCenter.Broadcast(EventDefine.Hit2);
        }
        else if (collision.gameObject.tag == "Reward")      //撞击奖励道具
        {
            EventCenter.Broadcast(EventDefine.Reward2);
        }
        else if (collision.gameObject.tag == "Freeze")     //撞击冰冻道具
        {
            EventCenter.Broadcast(EventDefine.Ob2);
        }
        else if (collision.gameObject.tag == "Stick")     //撞击尖刺陷阱
        {
            fv = new Vector2(this.transform.position.x - collision.transform.position.x, this.transform.position.y - collision.transform.position.y);
            EventCenter.Broadcast(EventDefine.St2);
        }
        else if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player3")     //检测撞击其他玩家
        {
            EventCenter.Broadcast(EventDefine.PlayerContact2);
        }
        if (collision.gameObject.tag == "Trap")
        {
            Debug.Log("触发陷阱");
        }
    }
    public void StickTrap()
    {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        rb.AddForce(fv);
    }
    public void Freeze()   //触发束缚陷阱
    {
        ONorOFF = 1;
        AS.clip = ASF;
        AS.Play();
        t1 = Time.time;
        Freezen = true;
    }
    public void SpeedUp()  //触发加速
    {
        AS.clip = ASS;
        AS.Play();        t2 = Time.time;
        SpeedUpContact = true;
    }
    public void OnPlayerConnect()           //检测到玩家碰撞
    {
        Freezen = false;
        ONorOFF = 0;
        m_speed = 5f;
        EventCenter.Broadcast(EventDefine.Freezeoff2);
    }
    public void TimeSlow()  //触发时间减缓
    {
        AS.clip = AST;
        AS.Play();
        t3 = Time.time;
        TimeSlowContact = true;
    }
    public void FreezenContacted(float time)  //触发冰冻陷阱
    {
        if (Time.time < time + 3f)
        {
            m_speed = 0f;                         //潜在问题
        }
        else
        {
            m_speed = 5f;
            Freezen = false;
            ONorOFF = 0;
            EventCenter.Broadcast(EventDefine.Freezeoff2);
        }
    }
    public void TimeSlowContacted(float time)  //触发时间减缓
    {
        if (Time.time < time + 3f)
        {
            Time.timeScale = 0.5f;
            //m_speed *= 2;                           //潜在问题
        }
        else
        {
            Time.timeScale = 1f;
            //m_speed /= 2;
            TimeSlowContact = false;
        }
    }
    public void SpeedUpContacted(float time)  //触发加速道具
    {
        if (Time.time < time + 3f)
        {
            Speed = 2;
        }
        else
        {
            Speed = 1;
            SpeedUpContact = false;
        }
    }
}
