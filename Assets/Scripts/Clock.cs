using UnityEngine;

public class Clock : Upgrade
{
    public float time;

    public override void Up()
    {
        gc.AddTime(time);

        base.Up();
    }
}
