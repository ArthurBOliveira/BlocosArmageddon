using UnityEngine;

public class Missile : Projectile
{
    public float range;
    public int damage;

    public GameObject explosion;

    public override void hit()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y + 0.25f);
        GameObject exp = Instantiate(explosion, pos, Quaternion.identity);

        Explosion expComp = exp.GetComponent<Explosion>();
        expComp.range = range;
        expComp.canHitTag = canHitTag;
        expComp.damage = damage;

        Destroy(exp, 0.1f);

        base.hit();
    }   
}
