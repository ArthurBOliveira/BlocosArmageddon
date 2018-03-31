using UnityEngine;

public class MissileUpg : Upgrade
{
    public int missiles;

    private Player p;

    private void Awake()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public override void Upg()
    {
        p.AddMissile(missiles);

        base.Upg();
    }
}
