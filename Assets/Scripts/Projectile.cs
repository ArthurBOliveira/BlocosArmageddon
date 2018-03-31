using UnityEngine;

public class Projectile : MonoBehaviour
{
    public string canHitTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(canHitTag))
        {
            hit();
        }
    }

    public virtual void hit()
    {
        Destroy(gameObject);
    }
}
