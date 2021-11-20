using UnityEngine;
using UnityEngine.UI;

public class StarScript : MonoBehaviour
{
    public static int starPoints;
    Text starText;

    // Start is called before the first frame update
    void Start()
    {
        starText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        starText.text = "X " + starPoints + "/ " + LevelController.Instance.StarQty();
        if (starPoints > LevelController.Instance.StarQty())
            starPoints = LevelController.Instance.StarQty();

        if (starPoints < 0)
            starPoints = 0;
    }
}
