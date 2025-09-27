using UnityEngine;
using Unity.Cinemachine;

public class CameraFocus : MonoBehaviour
{
    [SerializeField] private CinemachineBrain _brain;
    [SerializeField] private ICinemachineCamera _camA;
    [SerializeField] private ICinemachineCamera _camB;
    void Start()
    {
        _camA = GetComponent<CinemachineCamera>();
        _camB = GetComponent<CinemachineCamera>();

        //Override parameters
        int layer = 1;
        int priority = 1;
        float weight = 1f;
        float blendTime = 0f;
        _brain.SetCameraOverride(layer, priority, _camA, _camB, weight, blendTime);
    }
}
