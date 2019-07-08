using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public float Interval = 2f;
    public GameObject BulletPrefab;
    public GameObject[] Route;

    public bool flag = true;

    public Animator AN;

    public float AddSpeedTnterval = 10f;
    public float moveSpeed = 0.2f;

    private Transform t;

    private float timsGone = 0;

    private void Awake()
    {    
        AN.SetBool("Fire", true);
        t = this.transform;
        EventCenter.AddListener(EventDefine.Button1ON, SetFlagTrue);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveOnPath(Route, true));
    }

    // Update is called once per frame
    void Update()
    {
        timsGone += Time.deltaTime;
        if (timsGone >= Interval&flag)
        {
            Instantiate(BulletPrefab, t);
            gameObject.transform.DetachChildren();

            timsGone = 0;
        }

    }

    IEnumerator MoveOnPath(GameObject[] target, bool loop)
    {
        do
        {
            foreach (var x in target)
                yield return MoveToPosition(x.transform.position);
        }
        while (loop);
    }

    IEnumerator MoveToPosition(Vector3 target)
    {
        while (transform.position != target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
    public void SetFlagFalse()
    {
        AN.SetBool("Fire", false);
        flag = false;
    }

    public void SetFlagTrue()
    {
        AN.SetBool("Fire", true);
        flag = true;
    }
}
