using Unity.Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineCamera))]
public class CameraInput : MonoBehaviour
{
    public string playerPrefix = "P1"; // e.g., "P1" or "P2"

    private void OnEnable()
    {
        // Assign custom input handler
        CinemachineCore.GetInputAxis = GetVirtualCameraInput;
    }

    private void OnDisable()
    {
        // Reset to default when disabled
        CinemachineCore.GetInputAxis = null;
    }

    public float GetVirtualCameraInput(string axisName)
    {
        // Modify axis name: "Horizontal" → "Horizontal_P1"
        string axis = axisName + "_" + playerPrefix;

        // Return input for this player
        return Input.GetAxis(axis);
    }
}
