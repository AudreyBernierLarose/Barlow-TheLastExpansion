using System.Collections;
using System.Collections.Generic;
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
    }
}
