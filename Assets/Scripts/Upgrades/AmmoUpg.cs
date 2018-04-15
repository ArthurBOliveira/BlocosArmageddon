using UnityEngine;

public class AmmoUpg : Upgrade
{
    private Equipment equip;

    private void Awake()
    {
        equip = GameObject.FindGameObjectWithTag("Equipment").GetComponent<Equipment>();
    }

    public override void Upg()
    {
        equip.AddAmmo();

        base.Upg();
    }
}
