using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoOni : MonoBehaviour
{
    public Transform player;
    public float moveSpeed;
    private GameObject Player;
    private Animator anim;
    Rigidbody2D rigidBody;
    public float Radius;
    public bool moving;
    public GameObject activateSound;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        Player = GameObject.Find("Player");
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= Radius)
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            rigidBody.MovePosition(temp);
            changeAnim(temp - transform.position);
            anim.SetBool("Walking", true);
            moving = true;
        }
    }

    private void SetFloat(Vector2 setVector) {
        anim.SetFloat("moveX", setVector.x);
        anim.SetFloat("moveY", setVector.y);
    }

    private void changeAnim(Vector2 Direction) {
        if (Mathf.Abs(Direction.x) > Mathf.Abs(Direction.y))
        {
            if (Direction.x > 0)
            {
                SetFloat(Vector2.right);
            }
            else {
                SetFloat(Vector2.left);
            }
        }
        else if (Mathf.Abs(Direction.x) < Mathf.Abs(Direction.y)) {

            if (Direction.y > 0)
            {
                SetFloat(Vector2.up);
            }
            else
            {
                SetFloat(Vector2.down);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            Player.SetActive(false);
            gameObject.SetActive(false);
            activateSound.SetActive(true);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
