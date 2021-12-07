using UnityEngine;

public class LevelController : MonoBehaviour
{
    //Singleton
    private static LevelController _instance;
    public static LevelController Instance { get { return _instance; } }

    //Private variables
    private static int totalStarQty = 0, starCollected;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        totalStarQty = GameObject.FindGameObjectsWithTag("Star").Length;
    }

    public int StarQty()
    {
        return totalStarQty;
    }

    public int PickedUpStar()
    {
        return starCollected++;
    }
}
