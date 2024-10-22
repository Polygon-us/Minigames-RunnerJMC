using UnityEngine;

public class DeviceChecker : MonoBehaviour
{
    public static DeviceType DeviceType { get; private set; }  // Reference to a UI Text to display the device type

    private void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        // Call the JavaScript function to check the device
        Application.ExternalCall("CheckDevice");
#endif
    }

    // This method will be called from JavaScript
    public void OnDeviceCheck(string type)
    {
        DeviceType = (DeviceType)System.Enum.Parse(typeof(DeviceType), type);
      
        Debug.Log("Device Type: " + DeviceType);
    }
}

public enum DeviceType
{
    PC,
    Mobile
}