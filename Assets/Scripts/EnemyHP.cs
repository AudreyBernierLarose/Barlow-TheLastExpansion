using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private int enemyHP;

    private Animator anim;
    private GameObject fly;
    private Collider2D col;
    private GameObject damageCol;
    private Collider2D damCol;

    private int currentHP;

    // Start is called before the first frame update
    void Start()
    {
        damageCol = transform.parent.gameObject.transform.GetChild(1).gameObject;
        damCol = damageCol.GetComponent<Collider2D>();
        col = GetComponent<Collider2D>();
        anim = GetComponentInParent<Animator>();
        anim.SetBool("isDead", false);
        currentHP = enemyHP;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentHP <= 0)
        {
            damCol.enabled = false;
            col.enabled = false;
            anim.SetBool("isDead", true);
            StartCoroutine(WaitDestroy());
        }
        
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        Score.scoreValue++;
    }

    IEnumerator WaitDestroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(transform.parent.gameObject);
    }
}
