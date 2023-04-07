using UnityEngine;

public class eightKey : MonoBehaviour
{
    public float forwardSpeed = 50f; // 前进速度
    public float turnSpeed = 5f; // 转向速度
    public float rollSpeed = 5f; // 滚转速度
    public float pitchSpeed = 5f; // 俯仰速度

    private Rigidbody rb;

    void Start()
    {
        // 获取飞机对象的Rigidbody组件
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // 获取输入
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool up = Input.GetKey(KeyCode.Space);
        bool down = Input.GetKey(KeyCode.LeftShift);

        // 计算飞机的转向和滚转
        float yaw = horizontal * turnSpeed * Time.fixedDeltaTime;
        float roll = horizontal * rollSpeed * Time.fixedDeltaTime;

        // 计算飞机的俯仰
        float pitch = 0;
        if (vertical > 0)
        {
            pitch = vertical * pitchSpeed * Time.fixedDeltaTime;
        }
        else if (vertical < 0)
        {
            pitch = -vertical * pitchSpeed * Time.fixedDeltaTime;
        }

        // 应用俯仰、滚转和转向
        Quaternion turn = Quaternion.Euler(-pitch, yaw, -roll);
        rb.MoveRotation(rb.rotation * turn);

        // 计算飞机的速度
        float forward = forwardSpeed;
        if (down)
        {
            forward = -forwardSpeed;
        }
        else if (!up)
        {
            forward = 0f;
        }

        // 应用速度
        rb.velocity = transform.forward * forward;
    }
}
