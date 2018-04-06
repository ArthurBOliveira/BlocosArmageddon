using UnityEngine;

public class Level5 : GameController
{
    public override void SpawnObjects()
    {
        base.SpawnObjects();

        //Bomber
        Instantiate(objects[4], new Vector3(0, 3.5f), Quaternion.identity);
        currObjects += 2;

        
    }
}