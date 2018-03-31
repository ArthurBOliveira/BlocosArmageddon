using System.Collections;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public int life;
    public int points;

    public int percentDrop;

    // 0 - Clock; 1 - Missile
    public GameObject[] upgrades;

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

        if (life == 0)
        {
            StartCoroutine(DelayedDestroy());
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameController>().ChangeCurrObjects(-1, points);
        }
    }

    public IEnumerator DelayedDestroy()
    {
        SpawnUpgrade();
        audioS.Play();
        coll.enabled = false;
        rend.sprite = new Sprite();
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    private void SpawnUpgrade()
    {
        int rng = Random.Range(0, 100);
        if (rng > percentDrop) return;

        int upg = Random.Range(0, upgrades.Length - 1);
        Debug.Log(upg);

        Instantiate(upgrades[upgrades.Length - 1], transform.position, Quaternion.identity);
    }
}