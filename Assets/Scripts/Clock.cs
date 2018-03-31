using UnityEngine;

public class Clock : Upgrade
{
    public float time;

    public override void Upg()
    {
        gc.AddTime(time);

        base.Upg();
    }
}
