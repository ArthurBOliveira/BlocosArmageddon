using UnityEngine;

public class Level4 : GameController
{
    public override void SpawnObjects()
    {
        base.SpawnObjects();

        //Bomber
        Instantiate(objects[4], new Vector3(0, 3.5f), Quaternion.identity);
        currObjects ++;

        //Indestructibles
        Instantiate(objects[0], new Vector3(0.7f, 3.75f), Quaternion.identity);
        Instantiate(objects[0], new Vector3(0.7f, 3.25f), Quaternion.identity);
        Instantiate(objects[0], new Vector3(-0.7f, 3.75f), Quaternion.identity);
        Instantiate(objects[0], new Vector3(-0.7f, 3.25f), Quaternion.identity);

        //Walkers
        Instantiate(objects[3], new Vector3(2, 3.75f), Quaternion.identity);
        Instantiate(objects[3], new Vector3(-2, 3.75f), Quaternion.identity);

        //Blocks
        for (float y = 0; y <= 3.5f; y += 0.55f)
        {
            for (float x = -2.75f; x <= 2.75f; x += 0.45f)
            {
                if (y <= 0.55f)
                {
                    Instantiate(objects[1], new Vector3(x, y), Quaternion.identity);
                    currObjects++;
                }
                else if (y > 0.55f && y <= 1.75f)
                {
                    Instantiate(objects[2], new Vector3(x, y), Quaternion.identity);
                    currObjects++;
                }
                else if (y > 1.75f && y <= 2.75f)
                {
                    Instantiate(objects[5], new Vector3(x, y), Quaternion.identity);
                    currObjects++;
                }
            }
        }
    }
}