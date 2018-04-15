using UnityEngine;

public class StrongBallEquipment : Equipment
{
    public int extraDamage;
    public int timeStrengthened;
    public Color color;

    private Ball ball;

    public override void SetupObjects()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();
    }

    public override void Act()
    {
        if (isOnCd || ammo <= 0) return;

        base.Act();

        StartCoroutine(ball.IncreaseStrength(extraDamage, timeStrengthened, color));
    }
}
