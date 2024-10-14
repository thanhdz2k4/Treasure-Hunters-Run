using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimationController : MonoBehaviour
{
    [Header("MAIN MENU SCREEN ANIMATOR")]
    [SerializeField] Animator[] MainMenuAnimator; // Reference to the Animator

    [Header("GAME OVER SCREEN ANIMATOR")]
    [SerializeField] Animator[] GameOverAnimator;

    [Header("SETTINGS SCREEN ANIMATOR")]
    [SerializeField] Animator[] SettingsAnimator;

    [Header("GUIDANCE SCREEN ANIMATOR")]
    [SerializeField] Animator[] GuidanceAnimator;

    [Header("SHOP SCREEN ANIMATOR")]
    [SerializeField] Animator[] ShopAnimator;

    private void Start()
    {
        PlayMainMenuAnimator();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.S)) // Example: Trigger with spacebar
        {
            PlayGuidanceAnimator();
        }


    }

    private void PlayGuidanceAnimator()
    {
        foreach (Animator animator in GuidanceAnimator)
        {
            PlayAnimation(animator);
        }
    }

    private void PlaySettingsAnimator()
    {
        foreach (Animator animator in SettingsAnimator)
        {
            PlayAnimation(animator);
        }
    }

    public void PlayMainMenuAnimator()
    {
        foreach(Animator animator in MainMenuAnimator)
        {
            PlayAnimation(animator);
        }
    }

    public void PlayGameOverAnimator()
    {
        foreach (Animator animator in GameOverAnimator)
        {
            PlayAnimation(animator);
        }
    }

    public void PlayShopAnimator()
    {
        foreach (Animator animator in ShopAnimator)
        {
            PlayAnimation(animator);
        }
    }


    private void PlayAnimation(Animator animator)
    {
        animator.Play(animator.GetCurrentAnimatorStateInfo(0).fullPathHash, 0, 0f);
    }
}
