using UnityEngine;

public class Level3 : GameController
{
    public override void SpawnObjects()
    {
        base.SpawnObjects();

        //Bomber
        Instantiate(objects[4], new Vector3(-2f, 1.75f), Quaternion.identity);
        Instantiate(objects[4], new Vector3(2f, 1.75f), Quaternion.identity);
        currObjects += 2;

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
                else if (y == 0.55f || y == 2.75f && !(x >= -0.05f && x <= 0.05))
                {
                    Instantiate(objects[2], new Vector3(x, y), Quaternion.identity);
                    currObjects++;
                }
                else if(x >= -0.05f && x <= 0.05)
                    Instantiate(objects[0], new Vector3(x, y), Quaternion.identity);
            }
        }
    }
}