using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// 이동 속도
    /// </summary>
    [SerializeField]
    float moveSpeed = 10.0f;

    /// <summary>
    /// 회전 속도
    /// </summary>
    [SerializeField]
    float rotSpeed = 180.0f;

    void Start()
    {
        Managers.Input.KeyAction -= OnKeyboard;
        Managers.Input.KeyAction += OnKeyboard;
    }

    void Update()
    {

    }

    /// <summary>
    /// InputManager를 이용한 KeyAction
    /// </summary>
    void OnKeyboard()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), Time.deltaTime * rotSpeed);
            transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), Time.deltaTime * rotSpeed);
            transform.position += Vector3.back * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), Time.deltaTime * rotSpeed);
            transform.position += Vector3.left * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), Time.deltaTime * rotSpeed);
            transform.position += Vector3.right * Time.deltaTime * moveSpeed;
        }
    }
}
 