using UnityEngine;

public class VelocityHandler : MonoBehaviour
{
    // Public static instance to allow global access
    public static VelocityHandler Instance { get; private set; }

    [SerializeField]
    Vector2 velocity;
    public Vector2 Velocity => velocity / speedSlow;

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

    [SerializeField]
    private float speedSlow;

    [SerializeField]
    float timer;

   

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
        UpdateLevel();
        float velocityRatio = velocity.x / maxXVelocity;
        acceleration = maxAcceleration * (1 - velocityRatio);

        velocity.x += acceleration * Time.fixedDeltaTime * speedMultiply;

        currentDistance += (velocity.x * Time.fixedDeltaTime) / 10;


        
            if (velocity.x > maxXVelocity * speedMultiply)
            {
                velocity.x = maxXVelocity * speedMultiply;
            } 
    }

    public void UpdateLevel()
    {
        timer += Time.deltaTime;
        if (timer >= 10) maxXVelocity = 300;
        else if (timer >= 20) maxXVelocity = 400;
            
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
        this.timer = 0;
    }

    public void SpeedMultiplier(float speedMultiplier)
    {
        this.speedSlow = speedMultiplier;

        Debug.Log("SpeedSlow: " + speedSlow);
        
    }
}
