using UnityEngine;

public class VelocityHandler : MonoBehaviour
{
    // Public static instance to allow global access
    public static VelocityHandler Instance { get; private set; }

    [SerializeField]
    Vector2 velocity;
    public Vector2 Velocity => velocity;

    [SerializeField]
    float maxAcceleration = 10f;
    public float MaxAcceleration => maxAcceleration;

    [SerializeField]
    float acceleration = 10;
    public float Acceleration => acceleration;

    [SerializeField]
    float maxXVelocity = 100;
    public float MaxXVelocity => maxXVelocity;


    [SerializeField]
    float maxVelocity;
    public float MaxVelocity => maxVelocity;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        CaculateNewVelocity();
    }

    private void CaculateNewVelocity()
    {
        float velocityRatio = velocity.x / maxXVelocity;
        acceleration = maxAcceleration * (1 - velocityRatio);

        velocity.x += acceleration * Time.fixedDeltaTime;

        if (velocity.x > maxXVelocity)
        {
            velocity.x = maxXVelocity;
        }
    }
}
