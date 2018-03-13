using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject ballObject;

    private Ball ball;

    private void Awake()
    {
        ball = ballObject.GetComponent<Ball>();
    }

    public void ResetBall()
    {
        ballObject.transform.position = new Vector3(0, -4);

        ball.InitialKick();
    }
}
