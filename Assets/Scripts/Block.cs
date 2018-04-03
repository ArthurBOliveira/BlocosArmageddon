using UnityEngine;

public class Block : Destructible
{
    private TextMesh txtLife;

    public Sprite[] sprites;

    private void Start()
    {
        txtLife = GetComponentInChildren<TextMesh>();

        txtLife.text = life.ToString();
    }

    public override void CauseDamage(int dmg)
    {
        base.CauseDamage(dmg);

        txtLife.text = life == 0 ? "" : life.ToString();

        //if (life > 0)
        //    rend.sprite = sprites[life - 1];
    }
}
