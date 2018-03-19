using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public int life;

    public virtual void CauseDamage(int dmg)
    {
        life -= dmg;

        if (life <= 0)
            Destroy(gameObject);
    }
}