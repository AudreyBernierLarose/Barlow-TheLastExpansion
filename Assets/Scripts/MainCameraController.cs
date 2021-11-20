using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MainCameraController : MonoBehaviour
{
    [SerializeField] private CinemachineBlenderSettings customBlend;
    [SerializeField] private Camera main;

    // Start is called before the first frame update
    void Start()
    {
        main.GetComponent<CinemachineBrain>().m_CustomBlends = customBlend;

    }
}
