using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionPromptUI : MonoBehaviour
{
    // Interface for camera and text
    private Camera mainCam;
    [SerializeField] private TextMeshProUGUI promptText;
    [SerializeField] private GameObject panel;

    private void Start()
    {
        mainCam = Camera.main;
        panel.SetActive(false);
    }

    private void LateUpdate()
    {
        var rotation = mainCam.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
    }

    public bool IsDisplayed = false;

    public void SetUp(string pText)
    {
        panel.SetActive(true);
        promptText.text = pText;
        IsDisplayed = true;
    }

    public void Close()
    {
        panel.SetActive(false);
        IsDisplayed = false;
    }
}
