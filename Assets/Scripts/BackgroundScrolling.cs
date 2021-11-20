using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    public float scrollSpeed;
    private Renderer renderer;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        Vector2 offset = new Vector2(timer * scrollSpeed, 0);
        renderer.material.mainTextureOffset = offset;
    }
}
