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

    [SerializeField]
    public float currentDistance { get; private set; }

    public float record { get; private set; }
    public float MaxVelocity => maxVelocity;

    private bool isPause;

    [SerializeField]
    private float speedMultiply = 1;


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

    private void Start()
    {
        
    }

    

    private void FixedUpdate()
    {
        if(!isPause)
        {
            CaculateNewVelocity();
        }
        
    }

    private void CaculateNewVelocity()
    {
        float velocityRatio = velocity.x / maxXVelocity;
        acceleration = maxAcceleration * (1 - velocityRatio);

        velocity.x += acceleration * Time.fixedDeltaTime * speedMultiply;

        currentDistance += (velocity.x * Time.fixedDeltaTime) / 10;


        
            if (velocity.x > maxXVelocity * speedMultiply)
            {
                velocity.x = maxXVelocity * speedMultiply;
            }
        
       
    }

    public void Pause()
    {
        isPause = true;
    }

    public void Continue()
    {
        isPause = false;
    }

    public void ResetData()
    {
        PlayerPrefs.SetFloat("yourDistance", currentDistance);
        this.acceleration = 0;
        this.maxVelocity = 0;
        this.currentDistance = 0;
    }

    public void SpeedMultiplier(float speedMultiplier)
    {
        this.speedMultiply = speedMultiplier;
        
    }
}
