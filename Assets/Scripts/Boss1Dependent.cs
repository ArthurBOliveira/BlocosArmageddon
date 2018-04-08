using UnityEngine;

public class Boss1Dependent : MonoBehaviour
{
    public Boss1 father;

    private void OnDestroy()
    {
        father.DependentDestroyed();
    }
}
