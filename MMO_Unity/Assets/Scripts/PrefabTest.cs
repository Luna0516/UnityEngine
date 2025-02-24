using UnityEngine;

public class PrefabTest : MonoBehaviour
{
    void Start()
    {
        GameObject go = Managers.Resource.Instantiate("Player");

        Managers.Resource.Destroy(go, 3.0f);
    }
}
