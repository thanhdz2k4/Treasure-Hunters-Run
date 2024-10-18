using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Boost : MonoBehaviour
{
    [SerializeField]
    GameObject Player;

    [SerializeField]
    Transform Ship;

    [SerializeField]
    Transform Ship_Position_After_Boost;

    [SerializeField]
    Slider energyBar;

    [SerializeField]
    Jump Jump;

    [SerializeField]
    Collider2D myFoot;

    private void Start()
    {
        Jump = GetComponent<Jump>();
    }
    // Update is called once per frame
    void Update()
    {
        if(IsGround())
        {
            Jump.DoJumping(IsGround());
            VelocityHandler.Instance.SpeedMultiplier(4);
            
        }
        if(this.myFoot.IsTouchingLayers(LayerMask.GetMask("Ground")) && energyBar.value == 0)
        {
            VelocityHandler.Instance.SpeedMultiplier(10);
            Ship.position = Ship_Position_After_Boost.position;
            gameObject.SetActive(false);
            Player.SetActive(true);
        }
    }

    public bool IsGround()
    {
        Debug.Log( this.myFoot.IsTouchingLayers(LayerMask.GetMask("Ground")) || this.myFoot.IsTouchingLayers(LayerMask.GetMask("Bound")));
        // Check if the player's foot collider is touching the ground layer
        return this.myFoot.IsTouchingLayers(LayerMask.GetMask("Ground")) || this.myFoot.IsTouchingLayers(LayerMask.GetMask("Bound"));
    }
}
