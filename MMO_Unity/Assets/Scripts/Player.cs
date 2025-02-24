using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Managers mg = Managers.Inst;

        Debug.Log($"{mg.name}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
