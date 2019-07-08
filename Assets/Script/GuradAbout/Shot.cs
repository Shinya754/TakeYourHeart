using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    private bool _flag = true;
    public bool Flag
    {
        get { return _flag; }
        set { _flag = value; }
    }


    Transform t;
    GameObject target;
    public float Speed = 0.2f;

    public float AddSpeedTnterval = 10f;
    public float moveSpeed = 0.2f;
    


    private float time = 0;

    private Vector3 dir;

    private void Awake()
    {
        t = this.GetComponent<Transform>();
        EventCenter.AddListener(EventDefine.Hit, Hit);
        target = GameObject.FindWithTag("heart");
        this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }


    private void Start()
    {
            
        dir = (target.transform.position - t.position).normalized;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //try
        //{
        //    t.position = Vector3.MoveTowards(t.position, target.transform.position, Speed);
        //}
        //catch { }
        if (Flag)
        {
            time += Time.deltaTime;

            t.transform.Translate(dir * Speed);

            //if (Time.time - AddSpeedTnterval * TimeTimes >= 0)
            //{
            //    TimeTimes++;
            //    if (moveSpeed <= 2)
            //        moveSpeed += 0.5f;
            //}
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.StartsWith("heart"))
            Destroy(this.gameObject);
        if (collision.tag.Equals("wall"))
            Destroy(this.gameObject);
    }

    void Hit()
    {
        Debug.Log("hit player");
    }

    public void SetFlagFalse()
    {
        Flag = false;
    }

    public void SetFlagTrue()
    {
        Flag = true;
    }
}
