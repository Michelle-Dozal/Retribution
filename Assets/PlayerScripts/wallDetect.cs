
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallDetect : MonoBehaviour
{

    private Animator animator;
    private bool wallAnim = false;
    private move2D Player;
    // Start is called before the first frame update
    private void Awake()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        animator = gameObject.GetComponentInParent<Animator>();
        Player = gameObject.GetComponentInParent<move2D>();

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("wall", wallAnim);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        wallAnim = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        wallAnim = false;
    }
}