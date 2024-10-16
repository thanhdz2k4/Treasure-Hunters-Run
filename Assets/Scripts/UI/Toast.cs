using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Toast : MonoBehaviour
{
    [SerializeField] GameObject toastPanel;  // The UI element for the toast
    [SerializeField] TMP_Text toastText;         // Text element inside the toast panel (or use TextMeshPro if preferred)
    [SerializeField] float displayTime = 1f; // How long the toast should stay visible
    [SerializeField] Slider energySlider;    // Reference to the energy slider

    private float timer = 0f;

    private void Start()
    {
        toastPanel.SetActive(false); // Ensure the toast is hidden at the start
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && energySlider.value < 1)
        {
            ShowToast("Not enough energy to boost!");  // Display a toast message
        }

        // Hide the toast after the set display time
        if (toastPanel.activeSelf)
        {
            timer += Time.deltaTime;
            if (timer >= displayTime)
            {
                HideToast();
                timer = 0f;
            }
        }
    }

    // Method to display the toast
    public void ShowToast(string message)
    {
        toastText.text = message;        // Set the toast message
        toastPanel.SetActive(true);      // Show the toast panel
        timer = 0f;                      // Reset the timer
    }

    // Method to hide the toast
    private void HideToast()
    {
        toastPanel.SetActive(false);     // Hide the toast panel
    }
}
