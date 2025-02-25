using UnityEngine;

public class TestCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger !");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision ! : {collision.gameObject.name}");
    }
}
