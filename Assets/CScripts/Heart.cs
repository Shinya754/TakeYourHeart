using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Heart : MonoBehaviour
{
    public Text text;
    public AudioClip ASD;
    public AudioSource AS;
    public int Health = 100;
    public int reduceHealth = 10;
    public int t;
    public string MainColor;
    public string[] ColorType = { "Red", "Blue", "Yellow" };
    public Animator AN;
    public Text HpText;
    //得到玩家位置
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public float time=10;
    private float gotime = 0;
    private bool falg = false;
    private bool hold = false;
    private int LastNumber;

    public int TxtNum = 2;
    // Start is called before the first frame update
    void Awake()
    {
        t = Random.Range(1, 4);
        LastNumber = t;
        AN.SetInteger("Range", t - 1);
        this.MainColor = ColorType[t - 1];
    }

    private void Start()
    {
        
        StartCoroutine("Wait");
    }

    // Update is called once per frame
    void Update()
    {
        if (TxtNum == 0)
        {
            text.enabled = false;
            StopCoroutine("Wait");
        }
        try

        {
            this.transform.position = this.transform.parent.transform.position;
        }
        catch { }

        gotime += Time.deltaTime;
        if (Health <= 0)
        {
            SceneManager.LoadScene("Account");
            //  Time.timeScale = 0;
            //EventCenter.Broadcast(EventDefine.GameOver);
        } 
        if (gotime >= time)
        {
            ColorChange();
            gotime = 0;
        }

        

        ///
        ///判断心脏是否移动
        ///
        //if (StaticContact()&Movement == false & Token!= 0)
        //{
        //    time1 =(int) Time.time;
        //    Movement = true;
        //}
        //else if(!StaticContact() & Movement == true & Token != 0 & time1 != 0)
        //{
        //    time2 = (int)Time.time - (int)time1;
        //    Movement = false;
        //    time1 = 0;
        //    if (time2 > TimeLimit)
        //        EventCenter.Broadcast(EventDefine.GetTime2);
        //}
    }

    IEnumerator Wait()
    {
        for(;TxtNum>=0;TxtNum--)
        {
            text.text = TxtNum.ToString();
            yield return new WaitForSeconds(1);
        }
               
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            AS.clip = ASD;
            AS.Play();
            this.Health -= reduceHealth;
        }
        if (collision.gameObject.tag.Equals("Player1"))
        {
            if (MainColor == "Red")
            {
                EventCenter.Broadcast(EventDefine.P1);
                falg = true;
                hold = true;
            }
        }
        else if (collision.gameObject.tag.Equals("Player2"))
        {
            if (MainColor == "Blue")
            {
                EventCenter.Broadcast(EventDefine.P2);
                falg = true;
                hold = true;
            }
        }
        else if (collision.gameObject.tag.Equals("Player3"))
        {
            if (MainColor == "Yellow")
            {
                EventCenter.Broadcast(EventDefine.P3);
                falg = true;
                hold = true;
            }
        }
        if (falg)
        {
            
            this.transform.parent = collision.gameObject.transform;
            this.transform.position = collision.gameObject.transform.position;
            falg = false;
        }

        HpText.text = this.Health.ToString();

    }
    public void ColorChange()                                   //每30秒变一次颜色
    {
        try
        {
            this.transform.parent.DetachChildren();
        }
        catch { }
        while(t==LastNumber)
        t = Random.Range(1, 4);
        AN.SetInteger("Range", t - 1);
        this.MainColor = ColorType[t - 1];
        LastNumber = t;
        hold = false;
    }


    //public bool StaticContact()
    //{
    //    Rigidbody2D rb=this.GetComponent<Rigidbody2D>();
    //    if (rb.velocity != Vector2.zero)
    //    {
    //        return false;
    //    }
    //    else
    //        return true;
    //}
}
