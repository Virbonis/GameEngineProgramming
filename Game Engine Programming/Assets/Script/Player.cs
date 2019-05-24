using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    public GameObject Blood;
    public static List<Vector3> paths = new List<Vector3>();
    public Vector3 path;
    Transform[] theArray;
    private float timer = 0.2f;
    private bool spawningWaypoint = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        Debug.Log("Shit");
    }

    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();
        SpawnWayPoint();
    }

    void SpawnWayPoint() {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            if (Killer.onSight == true)
            {
                paths.Add(transform.position);
                Debug.Log(paths);
                if (paths != null)
                {
                    for (int x = paths.Count - 1; x > 0; x--)
                    {
                        if (paths[x] == paths[x - 1])
                        {
                            paths.Remove(paths[x]);
                            spawningWaypoint = false;
                        }
                        else
                        {
                            spawningWaypoint = true;
                        }
                    }
                }
                timer = 0.2f;
            }
            else {
                paths.Clear();
            }
        }
    }

    void UpdateAnimationAndMove() {
        if (change != Vector3.zero)
        {
            Movement();
            animator.SetFloat("MoveX", change.x);
            animator.SetFloat("MoveY", change.y);
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    void Movement() {
        change.Normalize();
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime    
        );
    }

    private void BloodEffect() {
        if (Blood != null) {
            GameObject effect = Instantiate(Blood, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (Killer.onSight == true)
        {
            if (spawningWaypoint == true)
            {
                for (int x = 0; x < paths.Count; x++)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawSphere(paths[x], 0.2f);
                }
            }
        }
    }
}
