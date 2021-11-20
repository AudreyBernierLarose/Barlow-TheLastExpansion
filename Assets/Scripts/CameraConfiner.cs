using UnityEngine;
using Cinemachine;

public class CameraConfiner : MonoBehaviour
{
    [SerializeField] private Collider2D startContainer;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<CinemachineConfiner>().m_BoundingShape2D = startContainer;
    }
}
