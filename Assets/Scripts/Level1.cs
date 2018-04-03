using UnityEngine;

public class Level1 : GameController
{
    public override void SpawnObjects()
    {
        base.SpawnObjects();

        //Indestructibles
        Instantiate(objects[0], new Vector3(2.0f, -1), Quaternion.identity);
        Instantiate(objects[0], new Vector3(-2.0f, -1), Quaternion.identity);

        //Blocks
        for (float y = 0; y <= 3.5f; y += 0.55f)
            for (float x = -2.75f; x <= 2.75f; x += 0.45f)
            {
                Instantiate(objects[1], new Vector3(x, y), Quaternion.identity);
                currObjects++;
            }
    }
}