using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierSpawn : MonoBehaviour
{
    public GameObject c1;
    public GameObject c2;
    public GameObject c3;

    public GameObject[] barriers;
    public GameObject[] items;

    private GameObject gameObject;

    private int x;
    private int y;

    private Vector3 cp1;
    private Vector3 cp2;
    private Vector3 cp3;
    
    private void Awake()
    {
        cp1 = c1.transform.position;
        cp2 = c2.transform.position;
        cp3 = c3.transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Creater", 0, 30);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Creater()
    {
        foreach (var x in barriers)
        {
            CreateTrap(x);
        }
        foreach (var x in items)
        {
            CreateItem(x);
        }
    }

    void CreateTrap(GameObject Object)
    {
        CreateObject(Object, 1, -14, -7, 0, 8);
        CreateObject(Object, 2, -6, 5, 0, 8);
        CreateObject(Object, 1, 6, 13, 0, 8);
        CreateObject(Object, 1, -14, -7, -9, -1);
        CreateObject(Object, 2, -6, 5, -9, -1);
        CreateObject(Object, 1, 6, 13, -9, -1);
    }

    void CreateItem(GameObject game)
    {
        CreateObject(game, 2, -14, 13, -9, 8);
    }

    void CreateObject(GameObject item, int num, int x1, int x2, int y1, int y2)
    {
        int inum = 0;
        while (inum != num)
        {
            Debug.Log(inum + "1212312");
            x = (int)Random.Range(x1, x2);
            y = (int)Random.Range(y1, y2);

            if (x == -13 || x == 12 || y == -7 || y == 6 || (x == (int)cp1.x && y == (int)cp1.y) || (x == (int)cp2.x && y == (int)cp2.y) || (x == (int)cp3.x && y == (int)cp3.y))
                continue;

            Debug.Log(inum);
            Instantiate(item, new Vector2((float)(x + 0.5f), (float)(y + 0.5f)), Quaternion.identity);
            inum++;
        }
    }

    //public void CreateObject(Items item)
    //{
    //    x = Random.Range(x_1, x_2);
    //    y = Random.Range(y_1, y_2);

    //    if (item == Items.Item_1_num)
    //        gameObject = items[0];
    //    else if (item == Items.Item_2_num)
    //        gameObject = items[1];
    //    else if (item == Items.Trap_1_num)
    //        gameObject = barriers[0];
    //    else if (item == Items.Trap_2_num)
    //        gameObject = barriers[1];

    //    Instantiate(gameObject, new Vector2((float)(x + 0.5f), (float)(y + 0.5f)), Quaternion.identity);
    //}
   
    public enum Items
    {
        Trap_1_num,
        Trap_2_num,
        Item_1_num,
        Item_2_num
    }
}
