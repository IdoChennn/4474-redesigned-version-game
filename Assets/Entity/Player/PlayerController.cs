using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject engineExhaustObject;
    public GameObject engineSoundObject;
    public GameObject landingGearSoundObject;
    public GameObject upgradeManagerObject;

    HealthManager playerHealth;
    UpgradeManager upgradeManager;
    Rigidbody planeBody;
    Animator gearAnimator;
    ParticleSystem engineExhaust;
    Light engineExhaustLight;
    AudioSource engineSound;
    AudioSource landingGearSound;

    float throttlePower;
    float thrust;
    float enginePower;
    float throttleSensitivity;
    float pitchForce;
    float pitchPower;
    float yawForce;
    float yawPower;
    float rollForce;
    float rollPower;
    float maxPitch;
    float maxYaw;
    float maxRoll;
    float basePitch;
    float baseYaw;
    float baseRoll;
    float liftForce;
    float liftFactor;
    float bankAngle;
    float controlSensitivity;
    float noseDropForce;
    float noseDropFactor;
    float stallSpeed;
    float aoaLiftForce;
    float aoaLiftFactor;
    float aoaSlipForce;
    float aoaSlipFactor;
    float engineExhaustFactor;
    float engineExhaustLightFactor;

    void Start()
    {
        planeBody = GetComponent<Rigidbody>();
        playerHealth = GetComponent<HealthManager>();
        gearAnimator = GetComponent<Animator>();
        engineExhaust = engineExhaustObject.GetComponent<ParticleSystem>();
        engineExhaustLight = engineExhaustObject.GetComponent<Light>();
        engineSound = engineSoundObject.GetComponent<AudioSource>();
        landingGearSound = landingGearSoundObject.GetComponent<AudioSource>();
        upgradeManager = upgradeManagerObject.GetComponent<UpgradeManager>();
        playerHealth.SetMaxHP(100);
        throttleSensitivity = 0.01f;
        throttlePower = 0;
        thrust = 0;
        pitchForce = 0;
        liftForce = 0;
        liftFactor = 0.5f;
        stallSpeed = 20;
        noseDropForce = 0;
        noseDropFactor = 0.2f;
        controlSensitivity = 3;
        aoaLiftForce = 0;
        aoaLiftFactor = 2;
        aoaSlipForce = 0;
        aoaSlipFactor = 1;
        basePitch = 5;
        baseYaw = 3;
        baseRoll = 5;
        engineExhaustFactor = 5;
        engineExhaustLightFactor = 1;
        planeBody.drag = 0.6f;
        Cursor.lockState = CursorLockMode.Confined;

        enginePower = 15;
        pitchPower = 0.15f;
        maxPitch = 4;
        yawPower = 0.045f;
        maxYaw = 3;
        rollPower = 0.15f;
        maxRoll = 4;

        upgradeManager.LoadData();
        enginePower = upgradeManager.GetEnginePower();
        pitchPower = upgradeManager.GetPitchPower();
        maxPitch = upgradeManager.GetMaxPitch();
        yawPower = upgradeManager.GetYawPower();
        maxYaw = upgradeManager.GetMaxYaw();
        rollPower = upgradeManager.GetRollPower();
        maxRoll = upgradeManager.GetMaxRoll();
        //Cursor.visible = false;
    }

    void Update()
    {
        LiftCalculation();
        BankAngleCalculation();
        AOACalculation();
        NoseDropCalculation();
        GearControl();
        FlightControl((Input.mousePosition.y - Screen.height / 2) / Screen.height * controlSensitivity, Input.GetAxis("Horizontal"), (Input.mousePosition.x - Screen.width / 2) / Screen.width * controlSensitivity);
    }

    private void FixedUpdate()
    {
        ChangeThrottle(Input.GetAxis("Vertical"));
        planeBody.AddForce(0, liftForce, 0, ForceMode.Acceleration);
        planeBody.AddRelativeForce(-aoaSlipForce, -aoaLiftForce, thrust, ForceMode.Force);
        planeBody.AddRelativeTorque(noseDropForce * Mathf.Cos(bankAngle * Mathf.Deg2Rad), -noseDropForce * Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.Deg2Rad), 0, ForceMode.Force);
        planeBody.AddRelativeTorque(pitchForce, yawForce, rollForce, ForceMode.Force);
    }

    void ChangeThrottle(float amount)
    {
        var main = engineExhaust.main;
        thrust = throttlePower * enginePower;
        throttlePower += amount * throttleSensitivity;
        throttlePower = Mathf.Clamp(throttlePower, 0, 1);
        main.startSpeed = throttlePower * engineExhaustFactor;
        engineExhaustLight.intensity = throttlePower * engineExhaustLightFactor;
        engineSound.volume = Mathf.Clamp(throttlePower * 2, 0, 1);
        engineSound.pitch = throttlePower + 0.5f;
    }

    void FlightControl(float pitch, float yaw, float roll)
    {
        pitch = Mathf.Clamp(pitch, -1, 1);
        yaw = Mathf.Clamp(yaw, -1, 1);
        roll = Mathf.Clamp(roll, -1, 1);
        yawForce = Mathf.Clamp(yaw * yawPower * (baseYaw + Vector3.Dot(planeBody.velocity, transform.forward)), -maxYaw, maxYaw);
        pitchForce = Mathf.Clamp(pitch * pitchPower * (basePitch + Vector3.Dot(planeBody.velocity, transform.forward)), -maxPitch, maxPitch);
        rollForce = -Mathf.Clamp(roll * rollPower * (baseRoll + Vector3.Dot(planeBody.velocity, transform.forward)), -maxRoll, maxRoll);
    }

    void GearControl()
    {
        if(Input.GetButtonDown("Gear Toggle"))
        {
            landingGearSound.Play();
            if (gearAnimator.GetBool("GearToggle"))
            {
                gearAnimator.SetBool("GearToggle", false);
                planeBody.drag = 0.5f;
            } else
            {
                gearAnimator.SetBool("GearToggle", true);
                planeBody.drag = 0.6f;
            }
        }
    }

    void LiftCalculation()
    {
        liftForce = planeBody.velocity.magnitude * liftFactor;
        liftForce = Mathf.Clamp(liftForce, 0, Physics.gravity.magnitude);
    }

    void BankAngleCalculation()
    {
        bankAngle = transform.rotation.eulerAngles.z;
        if (bankAngle > 180)
        {
            bankAngle = 360 - bankAngle;
        }
    }

    void AOACalculation()
    {
        aoaLiftForce = Vector3.Dot(transform.up, planeBody.velocity) * aoaLiftFactor;
        aoaSlipForce = Vector3.Dot(transform.right, planeBody.velocity) * aoaSlipFactor;
    }

    void NoseDropCalculation()
    {
        if (stallSpeed > Vector3.Dot(planeBody.velocity, transform.forward))
        {
            noseDropForce = (stallSpeed - Vector3.Dot(planeBody.velocity, transform.forward)) * Vector3.Cross(transform.forward, Vector3.down).magnitude * noseDropFactor;
        }
        else
        {
            noseDropForce = 0;
        }
    }

    public float GetThrottlePower()
    {
        return throttlePower;
    }

    public float GetHeight()
    {
        return transform.position.y;
    }

    public float GetSpeed()
    {
        return planeBody.velocity.magnitude;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.GetContact(0).thisCollider.gameObject.name == "Body_HitBox")
        {
            if (collision.gameObject.CompareTag("Terrain"))
            {
                playerHealth.ReduceHP(collision.relativeVelocity.magnitude * 10);
            }
        }
    }
}
