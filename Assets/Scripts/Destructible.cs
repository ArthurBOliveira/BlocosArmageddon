using System.Collections;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public int life;
    public int points;

    protected AudioSource audioS;
    protected SpriteRenderer rend;
    protected BoxCollider2D coll;

    private void Awake()
    {
        audioS = GetComponent<AudioSource>();
        rend = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();        
    }

    public virtual void CauseDamage(int dmg)
    {
        life -= dmg;

        if (life <= 0)
        {
            StartCoroutine(DelayedDestroy());
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameController>().ChangeCurrObjects(-1, points);
        }
    }

    public IEnumerator DelayedDestroy()
    {
        audioS.Play();
        coll.enabled = false;
        rend.sprite = new Sprite();
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}