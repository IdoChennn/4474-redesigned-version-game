using UnityEngine;

public class EnemyControllor : MonoBehaviour
{
    public Transform target; 
    public GameObject bulletPrefab; 
    public float bulletSpeed = 10f; 
    public float fireInterval = 2f; 
    public float flySpeed = 10f;
    public float turnSpeed = 5f;
    public float changeInterval = 5f; 
    public float changeDistance = 10f; 

    private Rigidbody rb;
    private Vector3 targetDirection; 
    private float fireTimer; 
    private float changeTimer; 

    void Start()
    {

        rb = GetComponent<Rigidbody>();

        
        fireTimer = fireInterval;
        changeTimer = changeInterval;
    }

    void FixedUpdate()
    {
        transform.LookAt(target);
       
        // 发射炮弹
        fireTimer -= Time.fixedDeltaTime;
        if (fireTimer <= 0)
        {
            fireTimer = fireInterval;
            Fire();
        }

        // 改变方向
        changeTimer -= Time.fixedDeltaTime;
        if (changeTimer <= 0)
        {
            changeTimer = changeInterval;
            targetDirection = Random.insideUnitSphere;
            targetDirection.y = 0;
            targetDirection = targetDirection.normalized;
        }

        // 转向目标方向
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.fixedDeltaTime));

        // 移动
        Vector3 direction = rb.rotation * Vector3.forward;
        rb.velocity = direction * flySpeed;
    }

    void Fire()
    {
        // 创建炮弹
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

        // 将炮弹向玩家发射
        Vector3 direction = (target.position - transform.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity = direction * bulletSpeed;
    }
}
