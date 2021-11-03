using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTrigger : MonoBehaviour
{
    //Serialized Fields
    [SerializeField] private GameObject cameraToActivate;
    [SerializeField] private GameObject cameraOut;
    [SerializeField] private Collider2D confinerIn;

    public VirtualCameraController vCamController;
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            vCamController.TransitionTo(cameraToActivate);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            vCamController.TransitionTo(cameraOut);
            cameraOut.GetComponent<CinemachineConfiner>().InvalidatePathCache();
            cameraOut.GetComponent<CinemachineConfiner>().m_BoundingShape2D = confinerIn;
        }       
    }
}
