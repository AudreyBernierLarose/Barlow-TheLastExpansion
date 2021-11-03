using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    private CinemachineBasicMultiChannelPerlin cmPerlin;
    private float intensityStop = 0.0f;

    [SerializeField] private CinemachineVirtualCamera cmVCam;
    [SerializeField] private float intensity;

    private void Start()
    {
        cmPerlin = cmVCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cmPerlin.m_AmplitudeGain = intensityStop;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Player" || other.gameObject.tag == "Asteroid") && cmVCam.isActiveAndEnabled)
            cmPerlin.m_AmplitudeGain = intensity;
        else
            cmPerlin.m_AmplitudeGain = intensityStop;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            cmPerlin.m_AmplitudeGain = intensityStop;
    }
}
