using UnityEngine;

public class Level5 : GameController
{
    public override void SpawnObjects()
    {
        base.SpawnObjects();

        Instantiate(objects[6], new Vector3(0, 3.75f), Quaternion.identity);
        currObjects += 5;

        //Indestructible
        Instantiate(objects[0], new Vector3(-2, 1.5f), Quaternion.identity);
        Instantiate(objects[0], new Vector3(-2, 0.5f), Quaternion.identity);
        Instantiate(objects[0], new Vector3(-2, 1), Quaternion.identity);
        Instantiate(objects[0], new Vector3(-2, 2.5f), Quaternion.identity);
        Instantiate(objects[0], new Vector3(-2, 3.5f), Quaternion.identity);
        Instantiate(objects[0], new Vector3(-2, 3), Quaternion.identity);

        Instantiate(objects[0], new Vector3(2, 1.5f), Quaternion.identity);
        Instantiate(objects[0], new Vector3(2, 0.5f), Quaternion.identity);
        Instantiate(objects[0], new Vector3(2, 1), Quaternion.identity);
        Instantiate(objects[0], new Vector3(2, 2.5f), Quaternion.identity);
        Instantiate(objects[0], new Vector3(2, 3.5f), Quaternion.identity);
        Instantiate(objects[0], new Vector3(2, 3), Quaternion.identity);

        for (int y = 0; y < 4; y += 2)
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