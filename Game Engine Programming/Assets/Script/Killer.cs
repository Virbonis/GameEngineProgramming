using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState {
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

    void checkDistance() {
        if (Vector3.Distance(target.position,
            transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if (currentState == EnemyState.walk)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                changeAnim(temp - transform.position);
                myRigidBody.MovePosition(temp);
                ChangeState(EnemyState.walk);
                killerAnim.SetBool("walking", true);
            }
        }
        else if (Vector3.Distance(target.position,
            transform.position) > chaseRadius)
        {
            if (Vector3.Distance(transform.position, path[currPoint].position) > roundingDistance)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, path[currPoint].position, moveSpeed * Time.deltaTime);
                changeAnim(temp - transform.position);
                myRigidBody.MovePosition(temp);
                ChangeState(EnemyState.walk);
                killerAnim.SetBool("walking", true);
            }
            else {
                ChangeGoal();
            }
        }
        else if (Vector3.Distance(target.position,
                 transform.position) <= chaseRadius
                 && Vector3.Distance(target.position, transform.position) <= attackRadius)
        {
            if (currentState == EnemyState.walk)
            {
                StartCoroutine(attack());
            }
        }
    }

    private void SetAnimFloat(Vector2 setVector) {
        killerAnim.SetFloat("moveX", setVector.x);
        killerAnim.SetFloat("moveY", setVector.y);
    }

    private void changeAnim(Vector2 direction) {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                SetAnimFloat(Vector2.right);
            }
            else {
                SetAnimFloat(Vector2.left);
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y)) {
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

    private void ChangeState(EnemyState newState) {
        if (currentState != newState) {
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

    private void ChangeGoal() {
        if (currPoint == path.Length - 1)
        {
            currPoint = 0;
            currGoal = path[0];
        }
        else {
            currPoint++;
            currGoal = path[currPoint];
        }
    }
}
