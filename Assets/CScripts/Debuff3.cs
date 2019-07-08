using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuff3 : MonoBehaviour
{
    public Animator AN;
    public GameObject GB;
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.AddListener(EventDefine.Freezeoff3, Freezeoff);
    }
    public void Freezeoff()
    {
        if(AN!=null)
        AN.SetBool("Freeze", false);
    }
    private void Update()
    {
        transform.position = GB.transform.position;
    }
}
