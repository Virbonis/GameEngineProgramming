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
    public float chaseRadius;
    public float attackRadius;
    public float chaseSmallDistance;
    public EnemyState currentState;
    public Rigidbody2D myRigidBody;
    public Transform target;
    public Animator killerAnim;
    public Transform[] path;
    public int currPoint;
    public int wayPointIndexChase;
    public Transform currGoal;
    public float roundingDistance;
    public float distance;
    public float maxAngle;
    public static bool onSight;
    private bool drawChase;
    public LayerMask player;
    public LayerMask obstacle;
    private int position;
    private bool tierUp = false;
    public static bool reachWaypoint = false;
    private bool tierDown = false;
    private bool countDown;
    private float timer = 5f;
    public static bool resetWaypoint;
    private int tierUpTrigger = 0;


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

        Collider2D[] overlaps_closerChase = new Collider2D[20];
        int countChaseValid = Physics2D.OverlapCircleNonAlloc(transform.position, chaseSmallDistance, overlaps_closerChase);

        for (int x = 0; x < count; x++)
        {
            if (overlaps[x] != null)
            {
                if (overlaps[x].transform == target)
                {
                    Vector3 directionBetween = (target.position - transform.position).normalized;
                    directionBetween.z *= 0;

                    if (position == 4)
                    {
                        float angle = Vector3.Angle(directionBetween, -transform.up);
                        angle = angle - 90;
                        if (angle <= maxAngle)
                        {
                            Debug.Log("Not Caught");
                            float distanceToTarget = Vector3.Distance(target.position, transform.position);
                            if (!Physics2D.Raycast(transform.position, directionBetween, distanceToTarget, obstacle))
                            {
                                onSight = true;
                                timer = 5f;
                                countDown = false;
                            }
                        }
                    }
                    else if (position == 3)
                    {
                        float angle = Vector3.Angle(directionBetween, transform.up);
                        angle = angle - 90;
                        if (angle <= maxAngle)
                        {
                            Debug.Log("Not Caught");
                            float distanceToTarget = Vector3.Distance(target.position, transform.position);
                            if (!Physics2D.Raycast(transform.position, directionBetween, distanceToTarget, obstacle))
                            {
                                onSight = true;
                                timer = 5f;
                                countDown = false;
                            }
                        }
                    }
                    else if (position == 1) {
                        float angle = Vector3.Angle(directionBetween, transform.right);
                        angle = angle - 90;
                        if (angle <= maxAngle)
                        {
                            Debug.Log("Not Caught");
                            float distanceToTarget = Vector3.Distance(target.position, transform.position);
                            if (!Physics2D.Raycast(transform.position, directionBetween, distanceToTarget, obstacle))
                            {
                                onSight = true;
                                timer = 5f;
                                countDown = false;
                            }
                        }
                    }
                    else if (position == 2)
                    {
                        float angle = Vector3.Angle(directionBetween, -transform.right);
                        angle = angle - 90;
                        if (angle <= maxAngle)
                        {
                            Debug.Log("Not Caught");
                            float distanceToTarget = Vector3.Distance(target.position, transform.position);
                            if (!Physics2D.Raycast(transform.position, directionBetween, distanceToTarget, obstacle))
                            {
                                onSight = true;
                                timer = 5f;
                                countDown = false;
                            }
                        }
                    }
                }
            }
        }

        if (Vector3.Distance(transform.position, target.position) >= chaseRadius)
        {
            countDown = true;
        }
        else {
            countDown = false;
        }

        for (int x = 0; x < countChaseValid; x++) {
            if (overlaps_closerChase[x] != null) {
                if (overlaps_closerChase[x].transform == target) {
                    Vector3 directionBetween = (target.position - transform.position).normalized;
                    directionBetween.z *= 0;
                    if (Vector3.Distance(transform.position, target.position) <= chaseSmallDistance) {
                        float distanceToTarget = Vector3.Distance(target.position, transform.position);
                        if (!Physics2D.Raycast(transform.position, directionBetween, distanceToTarget, obstacle))
                        {
                            onSight = true;
                            timer = 5f;
                            countDown = false;
                        }
                    }
                }
            }
        }

        if (onSight == true)
        {
            if (tierUpTrigger == 0 && onSight == true)
            {
                tierUpTrigger++;
                SoundManager.PlaySound("Evil3");
            }
            drawChase = true;
            if (countDown == true) {
                if (timer >= 0) {
                    timer -= Time.deltaTime;
                    Debug.Log(timer);
                }
                else
                {
                    onSight = false;
                    tierDown = true;
                }
            }
            if (Vector3.Distance(target.position, transform.position) >= attackRadius)
            {
                for (int x = 0; x < countChaseValid; x++)
                {
                    if (overlaps_closerChase[x] != null)
                    {
                        if (overlaps_closerChase[x].transform == target)
                        {
                            Vector3 directionBetween = (target.position - transform.position).normalized;
                            directionBetween.z *= 0;
                            if (Vector3.Distance(transform.position, target.position) <= chaseSmallDistance)
                            {
                                float distanceToTarget = Vector3.Distance(target.position, transform.position);
                                if (!Physics2D.Raycast(transform.position, directionBetween, distanceToTarget, obstacle))
                                {
                                    Vector3 temp = Vector3.MoveTowards(transform.position, target.position,
                                    moveSpeed * Time.deltaTime);
                                    changeAnim(temp - transform.position);
                                    myRigidBody.MovePosition(temp);
                                    timer = 5f;
                                    countDown = false;
                                    resetWaypoint = true;
                                    wayPointIndexChase = 0;
                                }
                                else
                                {
                                    onSight = true;
                                    countDown = true;
                                    Vector3 temp = Vector3.MoveTowards(transform.position, Player.paths[wayPointIndexChase],
                                    moveSpeed * Time.deltaTime);
                                    changeAnim(temp - transform.position);
                                    myRigidBody.MovePosition(temp);
                                    if (transform.position == Player.paths[wayPointIndexChase])
                                    {
                                        wayPointIndexChase++;
                                    }
                                }
                            }
                        }
                    }
                }
                if (Vector3.Distance(target.position, transform.position) >= chaseSmallDistance)
                {
                    Debug.Log("Search");
                    resetWaypoint = false;
                    Vector3 temp = Vector3.MoveTowards(transform.position, Player.paths[wayPointIndexChase],
                                   moveSpeed * Time.deltaTime);
                    changeAnim(temp - transform.position);
                    myRigidBody.MovePosition(temp);
                    if (transform.position == Player.paths[wayPointIndexChase])
                    {
                        wayPointIndexChase++;
                    }
                }
            }
            else
            {
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
            tierUpTrigger = 0;
            if (timer <= 0 && tierDown == true)
            {
                SoundManager.PlaySound("Evil2");
                tierDown = false;
            }
            drawChase = false;
            wayPointIndexChase = 0;
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
                position = 1;
                
            }
            else
            {
                SetAnimFloat(Vector2.left);
                position = 2;
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
                position = 3;
            }
            else
            {
                SetAnimFloat(Vector2.down);
                position = 4;
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
        Gizmos.DrawWireSphere(transform.position, chaseSmallDistance);

        if (position == 4)
        {
            Vector3 fowLine1 = Quaternion.AngleAxis(maxAngle, transform.forward) * transform.right * chaseRadius;
            Vector3 fowLine2 = Quaternion.AngleAxis(-maxAngle, transform.forward) * -transform.right * chaseRadius;
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, fowLine1);
            Gizmos.DrawRay(transform.position, fowLine2);
        }
        else if (position == 3)
        {
            Vector3 fowLine1 = Quaternion.AngleAxis(-maxAngle, transform.forward) * transform.right * chaseRadius;
            Vector3 fowLine2 = Quaternion.AngleAxis(maxAngle, transform.forward) * -transform.right * chaseRadius;
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, fowLine1);
            Gizmos.DrawRay(transform.position, fowLine2);
        }
        else if (position == 1)
        {
            Vector3 fowLine1 = Quaternion.AngleAxis(maxAngle, -transform.forward) * transform.right * chaseRadius;
            Vector3 fowLine2 = Quaternion.AngleAxis(maxAngle, transform.forward) * transform.right * chaseRadius;
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, fowLine1);
            Gizmos.DrawRay(transform.position, fowLine2);
        }
        else if (position == 2) {
            Vector3 fowLine1 = Quaternion.AngleAxis(maxAngle, transform.forward) * -transform.right * chaseRadius;
            Vector3 fowLine2 = Quaternion.AngleAxis(maxAngle, -transform.forward) * -transform.right * chaseRadius;
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, fowLine1);
            Gizmos.DrawRay(transform.position, fowLine2);
        }

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
