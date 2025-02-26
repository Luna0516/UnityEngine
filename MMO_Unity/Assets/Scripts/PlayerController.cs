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

    [SerializeField]
    float raycastDistance = 100.0f;

    Vector3 destPos;

    bool moveToDest = false;

    void Start()
    {
        Managers.Input.KeyAction -= OnKeyboard;
        Managers.Input.KeyAction += OnKeyboard;
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;
    }

    void Update()
    {
        if (moveToDest == false)
            return;

        Vector3 dir = destPos - transform.position;
        if (dir.magnitude < 0.0001f)
        {
            moveToDest = false;
        }
        else
        {
            float moveDist = Mathf.Clamp(moveSpeed * Time.deltaTime, 0, dir.magnitude);
            transform.position += dir.normalized * moveDist;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotSpeed);
        }

        Animator anim = GetComponent<Animator>();
        if(moveToDest)
        {
            anim.Play("RUN");
        }
        else
        {
            anim.Play("WAIT");
        }
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

        moveToDest = false;
    }

    void OnMouseClicked(Define.MouseEvent evt)
    {
        if (evt != Define.MouseEvent.Click)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * raycastDistance, Color.red, 1.0f);

        if (Physics.Raycast(ray, out RaycastHit hit, raycastDistance, LayerMask.GetMask("Plane")))
        {
            destPos = hit.point;
            moveToDest = true;
        }
    }
}
 