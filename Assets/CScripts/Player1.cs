using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public AudioClip ASD, ASF, ASS, AST;
    public AudioSource AS;
    Vector2 fv;
    public float t1;
    public float t2;
    public float t3;
    public string Color = "Red";
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
        //AS.clip = ASF;
        //AS.Play();
        EventCenter.AddListener(EventDefine.Freeze1, Freeze);
        EventCenter.AddListener(EventDefine.SpeedUp1, SpeedUp);
        EventCenter.AddListener(EventDefine.TimeSlow, TimeSlow);
        EventCenter.AddListener(EventDefine.PlayerContact1, OnPlayerConnect);
        EventCenter.AddListener(EventDefine.St1, StickTrap);
    }
    void Update()
    {
        float LeftOrRight = 0;
        float UpOrDown = 0;
        if (Input.GetKey(KeyCode.A) & Freezen == false)
        {
            LeftOrRight = -1;
        }
        if (Input.GetKey(KeyCode.S) & Freezen == false)
        {
            UpOrDown = -1;
        }
        if (Input.GetKey(KeyCode.D) & Freezen == false)
        {
            LeftOrRight = 1;
        }
        if (Input.GetKey(KeyCode.W) & Freezen == false)
        {
            UpOrDown = 1;
        }
        Vector3 movement = new Vector3(0, 0, 0);
        movement.x = LeftOrRight;
        movement.y = UpOrDown;
        AN.SetFloat("Magnitude", movement.magnitude);
        AN.SetFloat("LeftOrRight", movement.x);
        if(Freezen==false)
        {
            transform.position = transform.position + m_speed * Speed * movement * Time.deltaTime;
        }
        



        if (Input.GetKey(KeyCode.E) & Hold == false)   //捡起物品
        {
            EventCenter.Broadcast(EventDefine.Hold1);
            Hold = true;
        }
        else if (Input.GetKey(KeyCode.E) & Hold == true)   //扔下物品
        {
            EventCenter.Broadcast(EventDefine.Throw1);
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
            EventCenter.Broadcast(EventDefine.Hit1);
        }
        else if (collision.gameObject.tag == "Reward")      //撞击奖励道具
        {
            EventCenter.Broadcast(EventDefine.Reward1);
        }
        else if (collision.gameObject.tag == "Freeze")     //撞击冰冻道具
        {
            AS.clip = ASD;
            AS.Play();
            AS.clip = null;
            EventCenter.Broadcast(EventDefine.Ob1);
        }
        else if (collision.gameObject.tag == "Stick")     //撞击尖刺陷阱
        {
            fv = new Vector2(this.transform.position.x - collision.transform.position.x, this.transform.position.y - collision.transform.position.y);
            EventCenter.Broadcast(EventDefine.St1);
        }
        else if (collision.gameObject.tag == "Player2" || collision.gameObject.tag == "Player3")     //检测撞击其他玩家
        {
            EventCenter.Broadcast(EventDefine.PlayerContact1);
        }
        if (collision.gameObject.tag=="Trap")
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
        AS.Play();
        t2 = Time.time;
        SpeedUpContact = true;
    }
    public void OnPlayerConnect()           //检测到玩家碰撞
    {
        Freezen = false;
        ONorOFF = 0;
        m_speed = 5f;
        EventCenter.Broadcast(EventDefine.Freezeoff1);
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
            ONorOFF = 0;
            m_speed = 5f;
            Freezen = false;
            EventCenter.Broadcast(EventDefine.Freezeoff1);
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
            Speed = 2;                           //潜在问题
        }
        else
        {
            Speed = 1;
            SpeedUpContact = false;
        }
    }
}
