using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    public float scrollSpeed;

    private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        //Interesting Function
        //First parameter is the name of the function that we wanna call, second is the time at which we wanna repeat,
        //Third parameter is the repeat rate.
        //InvokeRepeating("MoveBG", 0.1f, scrollSpeed);
    }

    /*private void MoveBG()
    {
        renderer.material.mainTextureOffset = new Vector2(renderer.material.mainTextureOffset.x + 0.05f, 0);
    }*/


    // Update is called once per frame
    void Update()
    {
        renderer.material.mainTextureOffset = new Vector2(Time.time * scrollSpeed, 0);
    }
}
