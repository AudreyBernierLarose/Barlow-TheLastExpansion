using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPScript : MonoBehaviour
{
    public static int hpScore = 5;
    Text hpText;

    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        hpText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = "X " + hpScore;

        if (hpScore <= 0)
        {
            player.GetComponent<Animator>().SetBool("isDead", true);
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) 
                player.GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);
            hpScore = 0;
        }
    }
}
