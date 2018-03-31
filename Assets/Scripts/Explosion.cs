using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public int damage;
    public float range;
    public string canHitTag;

    private CircleCollider2D coll;

    private void Awake()
    {
        coll = GetComponent<CircleCollider2D>();        
    }

    private void Start()
    {
        coll.enabled = false;
        coll.enabled = true;

        coll.radius = range;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Quebrou!!");
        if (collision.CompareTag(canHitTag))
        {
            collision.gameObject.GetComponent<Destructible>().CauseDamage(damage);
        }
    }
}
