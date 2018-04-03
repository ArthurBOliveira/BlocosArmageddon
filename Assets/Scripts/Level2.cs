using UnityEngine;

public class Level2 : GameController
{
    public override void SpawnObjects()
    {
        base.SpawnObjects();

        //Indestructibles
        Instantiate(objects[0], new Vector3(2.0f, -1), Quaternion.identity);
        Instantiate(objects[0], new Vector3(-2.0f, -1), Quaternion.identity);
        Instantiate(objects[0], new Vector3(0, -1), Quaternion.identity);

        //Walkers
        Instantiate(objects[3], new Vector3(2.0f, 2), Quaternion.identity);
        Instantiate(objects[3], new Vector3(-2.0f, 2), Quaternion.identity);
        Instantiate(objects[3], new Vector3(0, 2), Quaternion.identity);
        Instantiate(objects[3], new Vector3(-1f, 2), Quaternion.identity);
        Instantiate(objects[3], new Vector3(1, 2), Quaternion.identity);
        currObjects += 5;

        //Blocks
        for (float y = 0; y <= 3.5f; y += 0.55f)
        {
            for (float x = -2.75f; x <= 2.75f; x += 0.45f)
            {
                if (y == 0 || y == 3.3f)
                {
                    Instantiate(objects[2], new Vector3(x, y), Quaternion.identity);
                    currObjects++;
                }
                else if (x == -2.75f || x == 2.65f)
                {
                    Instantiate(objects[2], new Vector3(x, y), Quaternion.identity);
                    currObjects++;
                }
            }
        }
    }
}