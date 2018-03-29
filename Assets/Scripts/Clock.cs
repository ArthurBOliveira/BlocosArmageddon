using UnityEngine;

public class Clock : Upgrades
{
    public float time;

    public override void Upgrade()
    {
        gc.AddTime(time);

        base.Upgrade();
    }
}
