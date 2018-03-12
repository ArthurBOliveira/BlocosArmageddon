using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : Destructible
{
    private SpriteRenderer rend;

    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        switch (life)
        {
            case 3:
                rend.color = Color.red;
                break;
            case 2:
                rend.color = Color.blue;
                break;
            default:
                rend.color = Color.green;
                break;
        }
    }
}
