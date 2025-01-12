using TMPro;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private TMP_Text batteryText;
    [SerializeField] private float batteryLevel = 40f;
    [SerializeField] private float batteryDrainInterval = 5f;

    private Light flashlight;
    private AudioSource audioSource;
    private float drainTimer;

    private void Awake()
    {
        flashlight = GetComponentInChildren<Light>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        flashlight.enabled = false;
        UpdateBatteryUI();
    }

    private void Update()
    {
        HandleFlashlightToggle();
        DrainBattery();
        AdjustLightFlicker();
    }

    private void HandleFlashlightToggle()
    {
        if (Input.GetKeyDown(KeyCode.F) && batteryLevel > 50f)
        {
            flashlight.enabled = !flashlight.enabled;
            audioSource.Play();
        }
    }

    private void DrainBattery()
    {
        if (flashlight.enabled)
        {
            drainTimer += Time.deltaTime;

            if (drainTimer >= batteryDrainInterval)
            {
                batteryLevel = Mathf.Max(0, batteryLevel - 1);
                UpdateBatteryUI();
                drainTimer = 0f;
            }

            if (batteryLevel <= 0)
            {
                flashlight.enabled = false;
            }
        }
    }

    private void AdjustLightFlicker()
    {
        if (batteryLevel <= 50f && flashlight.enabled)
        {
            flashlight.intensity = Random.Range(0.7f, 1f);
        }
    }

    private void UpdateBatteryUI()
    {
        batteryText.text = $"Battery: {batteryLevel:F0}";
    }

    internal void RechargeBattery(int v)
    {
        throw new System.NotImplementedException();
    }
}
