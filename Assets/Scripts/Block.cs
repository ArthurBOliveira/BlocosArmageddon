using UnityEngine;

public class Block : Destructible
{
    public Sprite[] sprites;

    public override void CauseDamage(int dmg)
    {
        base.CauseDamage(dmg);
        
        if(life > 0)
            rend.sprite = sprites[life - 1];
    }
}
