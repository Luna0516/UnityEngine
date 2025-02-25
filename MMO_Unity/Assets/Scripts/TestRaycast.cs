using UnityEngine;

public class TestRaycast : MonoBehaviour
{
    [SerializeField]
    Vector3 origin = new Vector3(0.0f, 0.75f, 0.0f);

    [SerializeField]
    float raycastDistance = 100.0f;

    void Update()
    {
        //Vector3 look = transform.TransformDirection(Vector3.forward);

        //Debug.DrawRay(transform.position + origin, look * raycastDistance, Color.red);

        //RaycastHit[] hits;
        //hits = Physics.RaycastAll(transform.position + origin, look, raycastDistance);

        //foreach (RaycastHit hit in hits)
        //{
        //    Debug.Log($"Raycast {hit.collider.gameObject.name}!");
        //}

        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Vector3 cameraPos = Camera.main.transform.position;

            Debug.DrawRay(cameraPos, ray.direction * raycastDistance, Color.red, 1.0f);

            // int mask = (1 << 8) | (1 << 9) | (1 << 10);
            LayerMask mask = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall") | LayerMask.GetMask("Player");

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, raycastDistance, mask))
            {
                Debug.Log($"Raycast Camer @{hit.collider.gameObject.name}");
            }
        }
    }
}
