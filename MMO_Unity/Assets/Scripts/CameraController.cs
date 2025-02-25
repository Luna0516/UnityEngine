using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CameraMode mode = Define.CameraMode.QuarterView;

    [SerializeField]
    Vector3 delta = new Vector3(0.0f, 6.0f, -5.0f);

    [SerializeField]
    GameObject player;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        if (mode == Define.CameraMode.QuarterView)
        {
            if (Physics.Raycast(player.transform.position, delta, out RaycastHit hit, delta.magnitude, LayerMask.GetMask("Wall")))
            {
                float dist = (hit.point - player.transform.position).magnitude * 0.8f;
                transform.position = player.transform.position + delta.normalized * dist;
            }
            else
            {
                transform.position = player.transform.position + delta;
                transform.LookAt(player.transform);
            }
        }
    }

    public void SetQuaterView(Vector3 delta)
    {
        mode = Define.CameraMode.QuarterView;
        this.delta = delta;
    }
}