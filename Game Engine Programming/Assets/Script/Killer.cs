using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack
}

public class Killer : Enemy
{
    // Start is called before the first frame update
    public EnemyState currentState;
    public Rigidbody2D myRigidBody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Animator killerAnim;
    public Transform[] path;
    public int currPoint;
    public Transform currGoal;
    public float roundingDistance;
    public float distance;
    public float maxAngle;
    private bool onSight = false;
    private bool drawChase;
    public LayerMask player;
    public LayerMask obstacle;
    private bool move;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        killerAnim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        Debug.Log("Shit");
    }

    void Update()
    {
        checkDistance();
    }

    void checkDistance()
    {
        Collider2D[] overlaps = new Collider2D[20];
        int count = Physics2D.OverlapCircleNonAlloc(transform.position, chaseRadius, overlaps);

        for (int x = 0; x < count - 1; x++)
        {
            if (overlaps[x] != null)
            {
                if (overlaps[x].transform == target)
                {
                    Vector3 directionBetween = (target.position - transform.position).normalized;
                    directionBetween.z *= 0;

                    float angle = Vector3.Angle(transform.forward, directionBetween);
                    angle = angle - 135;
                    Debug.Log(angle);
                    Debug.Log(maxAngle);
                    if (angle <= maxAngle)
                    {
                        Debug.Log("Not Caught");
                        Vector3 dir = (target.position - transform.position).normalized;
                        if (!Physics2D.Raycast(transform.position, dir, chaseRadius, obstacle))
                        {
                            onSight = true;
                            Debug.Log(onSight);
                            Debug.Log("Caught");
                        }
                    }
                }
            }
        }
        if (onSight == true)
        {
            drawChase = true;
            if (Vector3.Distance(target.position, transform.position) >= attackRadius)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                changeAnim(temp - transform.position);
                myRigidBody.MovePosition(temp);
            }
            else {
                if (currentState == EnemyState.walk)
                {
                    StartCoroutine(attack());
                }
            }
            ChangeState(EnemyState.walk);
            killerAnim.SetBool("walking", true);
        }
        else
        {
            drawChase = false;
            if (Vector3.Distance(transform.position, path[currPoint].position) > roundingDistance)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, path[currPoint].position, moveSpeed * Time.deltaTime);
                changeAnim(temp - transform.position);
                myRigidBody.MovePosition(temp);
                ChangeState(EnemyState.walk);
                killerAnim.SetBool("walking", true);
            }
            else
            {
                ChangeGoal();
            }
        }
        onSight = false;
    }

    private void SetAnimFloat(Vector2 setVector)
    {
        killerAnim.SetFloat("moveX", setVector.x);
        killerAnim.SetFloat("moveY", setVector.y);
    }

    private void changeAnim(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                SetAnimFloat(Vector2.right);
            }
            else
            {
                SetAnimFloat(Vector2.left);
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }
            else
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }

    private void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }

    public IEnumerator attack()
    {
        currentState = EnemyState.attack;
        killerAnim.SetBool("Attacking", true);
        yield return new WaitForEndOfFrame();
        currentState = EnemyState.walk;
        killerAnim.SetBool("Attacking", false);
    }

    private void ChangeGoal()
    {
        if (currPoint == path.Length - 1)
        {
            currPoint = 0;
            currGoal = path[0];
        }
        else
        {
            currPoint++;
            currGoal = path[currPoint];
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
        Gizmos.DrawWireSphere(transform.position, attackRadius);

        Vector3 fowLine1 = Quaternion.AngleAxis(maxAngle, transform.forward) * transform.right * chaseRadius;
        Vector3 fowLine2 = Quaternion.AngleAxis(-maxAngle, transform.forward) * -transform.right * chaseRadius;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, fowLine1);
        Gizmos.DrawRay(transform.position, fowLine2);

        if (drawChase == false)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }
        Gizmos.DrawRay(transform.position, (target.position - transform.position).normalized * chaseRadius);

        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, -transform.up * chaseRadius);
    }
}
