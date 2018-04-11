using UnityEngine;

public class Level5 : GameController
{
    public override void SpawnObjects()
    {
        base.SpawnObjects();

        Instantiate(objects[6], new Vector3(0, 3.7f), Quaternion.identity);
        currObjects += 5;

        //Hard
        Instantiate(objects[5], new Vector3(-1.75f, 0.5f), Quaternion.identity);
        Instantiate(objects[5], new Vector3(-1.75f, 1), Quaternion.identity);
        currObjects += 2;

        Instantiate(objects[5], new Vector3(1.75f, 0.5f), Quaternion.identity);
        Instantiate(objects[5], new Vector3(1.75f, 1), Quaternion.identity);
        currObjects += 2;

        for (int y = 0; y < 4; y += 20)
        {
            //Large
            Instantiate(objects[2], new Vector3(-1f, y), Quaternion.identity);
            Instantiate(objects[2], new Vector3(-1.5f, y), Quaternion.identity);
            Instantiate(objects[2], new Vector3(-2f, y), Quaternion.identity);
            Instantiate(objects[2], new Vector3(-2.5f, y), Quaternion.identity);

            Instantiate(objects[2], new Vector3(2.5f, y), Quaternion.identity);
            Instantiate(objects[2], new Vector3(2f, y), Quaternion.identity);
            Instantiate(objects[2], new Vector3(1.5f, y), Quaternion.identity);
            Instantiate(objects[2], new Vector3(1f, y), Quaternion.identity);
            currObjects += 8;

            //Hard
            Instantiate(objects[5], new Vector3(0, y), Quaternion.identity);
            Instantiate(objects[5], new Vector3(-0.5f, y), Quaternion.identity);
            Instantiate(objects[5], new Vector3(0.5f, y), Quaternion.identity);
            currObjects += 3;
        }
    }
}