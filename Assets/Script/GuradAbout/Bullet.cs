using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.StartsWith("heart"))
            Destroy(this.gameObject);
        if (collision.tag.Equals("wall"))
            Destroy(this.gameObject);
    }
}
