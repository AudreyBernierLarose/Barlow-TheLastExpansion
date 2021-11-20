using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scoreValue = 0;
    Text score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "" + scoreValue;

        if (scoreValue > 100)
        {
            scoreValue = 0;
            HPScript.hpScore++;
        }

        if (scoreValue < 0)
            scoreValue = 0;
    }
}
