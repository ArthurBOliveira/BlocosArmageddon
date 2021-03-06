﻿using UnityEngine;

public class Upgrade : MonoBehaviour
{
    protected GameController gc;

    private void Awake()
    {
        gc = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Ball"))
        {
            Upg();
        }
    }

    public virtual void Upg()
    {
        Destroy(gameObject);
    }
}