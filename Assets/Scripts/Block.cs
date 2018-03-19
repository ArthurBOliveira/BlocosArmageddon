using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : Destructible
{
    public Sprite[] sprites;

    private SpriteRenderer rend;

    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    public override void CauseDamage(int dmg)
    {
        base.CauseDamage(dmg);
        
        if(life > 0)
            rend.sprite = sprites[life - 1];
    }
}
