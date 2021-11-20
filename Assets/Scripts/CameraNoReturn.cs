using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNoReturn : MonoBehaviour
{
    //Serialized Fields
    [SerializeField] private GameObject cameraToActivate;
    [SerializeField] private GameObject cameraOut;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject otherTrigger;

    public VirtualCameraController vCamController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && player.gameObject.GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            otherTrigger.gameObject.GetComponent<CameraTrigger>().enabled = false;
            vCamController.TransitionTo(cameraToActivate);


        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && player.gameObject.GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            otherTrigger.gameObject.GetComponent<CameraTrigger>().enabled = true;
            vCamController.TransitionTo(cameraOut);
            
            
        }
    }
}
