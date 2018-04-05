using System.Collections;
using UnityEngine;

public class Bomber : Destructible
{
    public GameObject bomb;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(3);

        while (true)
        {
            GameObject aux = Instantiate(bomb, transform.position, Quaternion.identity);

            Destroy(aux, 5);

            yield return new WaitForSeconds(5);
        }
    }
}
