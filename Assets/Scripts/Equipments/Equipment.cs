using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Equipment : MonoBehaviour
{
    public int ammo;
    public int ammoToAdd;
    public int cooldown;

    public bool isOnCd;

    private Button btn;
    private Image[] imgs;
    private Text[] txts;

    private void Awake()
    {
        btn = GetComponent<Button>();
        imgs = GetComponentsInChildren<Image>();
        txts = GetComponentsInChildren<Text>();
        SetupObjects();
    }

    private void Start()
    {        
        btn.onClick.AddListener(Act);
        txts[1].text = ammo.ToString();
    }

    private IEnumerator CountingCoolDown()
    {
        int currCD = cooldown;
        txts[0].enabled = true;
        imgs[1].enabled = false;
        btn.interactable = false;

        while (currCD > 0)
        {
            txts[0].text = currCD.ToString();
            yield return new WaitForSeconds(1);

            currCD--;
        }

        isOnCd = false;
        btn.interactable = true;
        txts[0].enabled = false;
        imgs[1].enabled = true;
    }

    public virtual void SetupObjects() { }

    public virtual void Act()
    {
        if (isOnCd || ammo <= 0) return;

        isOnCd = true;
        ammo--;
        txts[1].text = ammo.ToString();
        StartCoroutine(CountingCoolDown());
    }

    public void AddAmmo()
    {
        ammo += ammoToAdd;
        txts[1].text = ammo.ToString();
    }
}

public enum Equipments
{
    Missiles,
    Strength,
}