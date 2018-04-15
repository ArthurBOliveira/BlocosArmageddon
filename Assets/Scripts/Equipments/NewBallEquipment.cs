using UnityEngine;

public class NewBallEquipment : Equipment
{
    private Ball ball;

    public override void SetupObjects()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();
    }

    public override void Act()
    {
        base.Act();

        ball.InitialKick();
    }
}