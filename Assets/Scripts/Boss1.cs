using System.Collections;
using UnityEngine;

public class Boss1 : Destructible
{
    public bool invunerable;
    public int dependents;

    public GameObject bomb;
    public GameObject[] dependentsObj;

    private void Start()
    {
        dependents = 0;
        TurnInvunerable(true);
        InstantiateDependents();
    }

    private IEnumerator StartingShoot()
    {
        yield return new WaitForSeconds(1);

        while (true)
        {
            Vector3 extra = new Vector3(0.5f, 0);

            GameObject aux = Instantiate(bomb, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            GameObject aux1 = Instantiate(bomb, transform.position - extra, Quaternion.identity);
            GameObject aux2 = Instantiate(bomb, transform.position + extra, Quaternion.identity);

            Destroy(aux, 3);
            Destroy(aux1, 3);
            Destroy(aux2, 3);

            yield return new WaitForSeconds(3.5f);
        }
    }

    private IEnumerator MoveAround()
    {
        Vector3 pointA = new Vector3(0, 3.75f);
        Vector3 pointB = new Vector3(2, 2.25f);
        Vector3 pointC = new Vector3(-2, 2.25f);

        while (true)
        {
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
            yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3.0f));
            yield return StartCoroutine(MoveObject(transform, pointA, pointC, 3.0f));
            yield return StartCoroutine(MoveObject(transform, pointC, pointA, 3.0f));
        }
    }

    private IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
    }

    private void InstantiateDependents()
    {
        Vector3 pos;

        pos = new Vector3(-2.5f, 0.75f);
        InstantiateDependent(pos);

        pos = new Vector3(2.5f, 0.75f);
        InstantiateDependent(pos);

        pos = new Vector3(-2.5f, 3.5f);
        InstantiateDependent(pos);

        pos = new Vector3(2.5f, 3.5f);
        InstantiateDependent(pos);
    }

    private void InstantiateDependent(Vector3 pos)
    {
        GameObject d = Instantiate(dependentsObj[0], pos, Quaternion.identity);
        LineRenderer lr = d.AddComponent<LineRenderer>();

        lr.SetPosition(0, gameObject.transform.position);
        lr.SetPosition(1, d.transform.position);
        lr.startWidth = 0.02f;
        lr.endWidth = 0.02f;

        d.GetComponent<Boss1Dependent>().father = this;

        dependents++;
    }

    public override void CauseDamage(int dmg)
    {
        if (invunerable) return;

        base.CauseDamage(dmg);
    }

    public void TurnInvunerable(bool inv)
    {
        invunerable = inv;

        if (invunerable)
            txtLife.text = "I";
        else
        {
            txtLife.text = life.ToString();
            StartCoroutine(StartingShoot());
            StartCoroutine(MoveAround());
        }
    }

    public void DependentDestroyed()
    {
        dependents--;

        if (dependents <= 0)
            TurnInvunerable(false);
    }
}
