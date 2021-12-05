using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    //Serialized Fields
    [SerializeField] private GameObject cameraToActivate;
    [SerializeField] private GameObject cameraOut;
    
    public VirtualCameraController vCamController;
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            vCamController.TransitionTo(cameraToActivate);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            vCamController.TransitionTo(cameraOut);
        }
    }
}
