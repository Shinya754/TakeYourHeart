using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCreator : MonoBehaviour
{
    public GameObject Bullet;
    Vector3 Pos;

    private void Awake()
    {
        Pos = transform.position;
        
    }
    private void Start()
    {
        //Invoke("CreateSector", 0.5f);
        InvokeRepeating("CreateOrNot", 2f, 0.5f);
        //StartCoroutine("RoundSector");
    }
    private void Update()
    {
        
    }

    void CreateOrNot()
    {
        if ((Swich1.ONorOFF + Swich2.ONorOFF + Swich3.ONorOFF + Swich4.ONorOFF >= 2)||(Player1.ONorOFF+Player2.ONorOFF+Player3.ONorOFF>0)) 
        {
            CreateSector();
        }
    }



    void CreateSector()
    {
        for(float i=0;i<=360;i+=30)
        {
            if (i == 0) 
            {
                GameObject temp = Instantiate(Bullet, new Vector3(Pos.x + Mathf.Cos(0), Pos.y + Mathf.Sin(0), 0),Quaternion.identity);
                temp.GetComponent<Rigidbody2D>().velocity = new Vector2(5*(temp.transform.position.x - Pos.x),5*( temp.transform.position.y - Pos.y));
            }
            else
            {
                GameObject temp1 = Instantiate(Bullet, new Vector3((Pos.x + Mathf.Cos(i / 360f * 3.1415f)),( Pos.y + Mathf.Sin(i / 360f * 3.1415f)), 0), Quaternion.identity);
                GameObject temp2 = Instantiate(Bullet, new Vector3((Pos.x + Mathf.Cos(i / 360f * 3.1415f)),( Pos.y - Mathf.Sin(i / 360f * 3.1415f)), 0), Quaternion.identity);
                temp1.GetComponent<Rigidbody2D>().velocity = new Vector2(5 * (temp1.transform.position.x - Pos.x), 5 * (temp1.transform.position.y - Pos.y));
                temp2.GetComponent<Rigidbody2D>().velocity = new Vector2(5 * (temp2.transform.position.x - Pos.x), 5 * (temp2.transform.position.y - Pos.y));
                //temp1.GetComponent<Rigidbody2D>().velocity = new Vector2(temp1.transform.position.x - Pos.x, temp1.transform.position.y - Pos.y);
                //temp2.GetComponent<Rigidbody2D>().velocity = new Vector2(temp2.transform.position.x - Pos.x, temp2.transform.position.y - Pos.y);
            }
        }
        Swich1.ONorOFF = 0;
        Swich2.ONorOFF = 0;
        Swich3.ONorOFF = 0;
        Swich4.ONorOFF = 0;
        Player1.ONorOFF = 0;
        Player2.ONorOFF = 0;
        Player3.ONorOFF = 0;
    }

    IEnumerator RoundSector()
    {
        float Angle = -90;
        for (float i = 0; i < 4; i += 1) 
        {
            if(i%2==0)
            {
                for(;Angle<90;Angle+=30)
                {
                    GameObject temp = Instantiate(Bullet, new Vector3(Pos.x + Mathf.Cos(Angle / 360f * 3.1415f), Pos.y + Mathf.Sin(Angle / 360f * 3.1415f), 0), Quaternion.identity);
                    temp.GetComponent<Rigidbody2D>().velocity = new Vector2(temp.transform.position.x - Pos.x, temp.transform.position.y - Pos.y);
                    yield return new WaitForSeconds(0.1f);
                }
            }
            else
            {
                for(;Angle>-90;Angle-=30)
                {
                    GameObject temp = Instantiate(Bullet, new Vector3(Pos.x + Mathf.Cos(Angle / 360f * 3.1415f), Pos.y + Mathf.Sin(Angle / 360f * 3.1415f), 0), Quaternion.identity);
                    temp.GetComponent<Rigidbody2D>().velocity = new Vector2(temp.transform.position.x - Pos.x, temp.transform.position.y - Pos.y);
                    yield return new WaitForSeconds(0.1f);
                }
            }















            //yield return new WaitForSeconds(0.5f);
            
            
        }
    }
}
