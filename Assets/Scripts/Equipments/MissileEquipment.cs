using UnityEngine;

public class MissileEquipment : Equipment
{
    public GameObject missilePrefab;
    public float projectileSpeed = 100;

    private GameObject player;

    public override void SetupObjects()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void Act()
    {
        if (isOnCd || ammo <= 0) return;

        base.Act();

        GameObject miss = Instantiate(missilePrefab, player.transform.position, Quaternion.identity);

        miss.GetComponent<Rigidbody2D>().AddForce(Vector2.up * projectileSpeed);

        Destroy(miss, 5f);
    }
}
