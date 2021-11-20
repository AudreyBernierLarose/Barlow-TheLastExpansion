using UnityEngine;

public class MovingWall : MonoBehaviour
{
    [SerializeField] private GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < this.transform.position.x)
            HPScript.hpScore -= HPScript.hpScore;
    }
}
