using UnityEngine;
using UnityEngine.UI;

public class StardustPoints : MonoBehaviour
{
    public static int dustValue = 0;
    Text stardustPoints;

    // Start is called before the first frame update
    void Start()
    {
        stardustPoints = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        stardustPoints.text = "X " + dustValue;

        if (dustValue < 0)
            dustValue = 0;
    }
}
