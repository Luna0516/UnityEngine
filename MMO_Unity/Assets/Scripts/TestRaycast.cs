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
            Vector3 cameraPos = Camera.main.transform.position;

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            Vector3 dir = mousePos - cameraPos;
            dir.Normalize();

            Debug.DrawRay(cameraPos, dir * raycastDistance, Color.red, 1.0f);

            RaycastHit hit;
            if (Physics.Raycast(cameraPos, dir, out hit, raycastDistance))
            {
                Debug.Log($"Raycast Camer @{hit.collider.gameObject.name}");
            }
        }
    }
}
