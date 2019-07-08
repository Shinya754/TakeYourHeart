using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="CreatManagerVarsContainer1")]
public class ManagerVars : ScriptableObject
{
    public static ManagerVars GetManagerVars()
    {
        return Resources.Load<ManagerVars>("ManagerVarsContainer");
    }
    public List<Sprite> bgThemeSpriteList = new List<Sprite>();
    public GameObject t1;
    public GameObject t2;
}
