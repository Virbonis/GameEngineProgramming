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
    private float timer = 0.2f;
    private bool spawningWaypoint = false;
    private float timerBoost;
    private bool speedBoost;
    private bool Boost;
    private float speedTemp;
    public static bool DeathScene;
    public GameObject DeathSceneActivator;
    public GameObject DeathFontActivator;

    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        change = Vector3.zero;
        if (KillerHit.hit == true)
        {
            speedBoost = true;
            timerBoost = 3f;
            Health.health -= 1;
            KillerHit.hit = false;
        }
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();
        SpawnWayPoint();

        if (Health.health < 1) {

            Destroy(this.gameObject);
            DeathSceneActivator.SetActive(true);
            DeathFontActivator.SetActive(true);
            DeathScene = true;
        }
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
                if (Killer.resetWaypoint == true)
                {
                    paths.Clear();
                }
                else
                {
                    paths.Add(transform.position);
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
                }
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
        if (speedBoost == true)
        {
            Boost = true;
            speed = speed + 4f;
            if (speed > 9f) {
                speed = 9f;
            }
            speedBoost = false;
        }
        if (Boost == true) {
            if (timerBoost >= 0)
            {
                timerBoost -= Time.deltaTime;
            }
            else
            {
                speed = speed - 4f;
                timerBoost = 3f;
                Boost = false;
            }
        }

        change.Normalize();
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime    
        );
    }

    public void LeftFootsteps() {
        Footsteps.PlaySound("Left Footstep");
    }

    public void RightFootsteps()
    {
        Footsteps.PlaySound("Right Footstep");
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

    public void TakeDamage() {
        Debug.Log("Test");
    }
}
