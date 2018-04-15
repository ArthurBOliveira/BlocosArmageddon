using UnityEngine;

public class ClockUpg : Upgrade
{
    public float time;

    public override void Upg()
    {
        gc.AddTime(time);

        base.Upg();
    }
}
