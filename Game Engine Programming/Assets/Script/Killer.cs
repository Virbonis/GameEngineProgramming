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
    public float chaseRadius;
    public float attackRadius;
    public float chaseSmallDistance;
    public float TerrorRadius;
    public EnemyState currentState;
    public Rigidbody2D myRigidBody;
    public Transform target;
    public Animator killerAnim;
    public Transform[] path;
    public int currPoint;
    public int wayPointIndexChase;
    public Transform currGoal;
    public Transform currDest;
    public float roundingDistance;
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
    private float speedTemp;
    private float timerAnimKicking = 3.45f;
    private float timerAnimLaughing = 2.15f;
    private bool canAttack = true;
    private bool animTrigger;
    private bool animTriggerKicking;
    private float timerDelay = 2.15f;
    public bool kicking;
    public int counter = 0;
    public GameObject WayoutTriggerRooms;
    public GameObject Corridor;
    public int WayoutPointindex = 0;
    private int counterTrigger = 0;
    public static bool patrol;
    public GameObject[] ActivatesCorridor;
    private bool completed = true;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        killerAnim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;

        speedTemp = moveSpeed - 2f;
    }

    void Update()
    {
        if (kicking == true) {
            if (counter == 0) {
                KillerSound.PlaySoundEnemy("Wood Sound Effect");
                counter++;
            }
        }
        checkDelay();
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
            currPoint = 0;
            WayoutPointindex = 0;
            WayoutPoint.Active = false;
            WayoutPoint_2.Active2 = false;
            WayoutPoint_3.Active3 = false;
            WayoutPoint_3_1.Active3_1 = false;
            WayoutPoint_3_2.Active3_2 = false;
            WayoutPoint_4.Active4 = false;
            WayoutPoint_5.Active5 = false;
            WayoutPoint_6.Active6 = false;
            WayoutPoint_7.Active7 = false;
            WayoutPoint_8.Active8 = false;
            WayoutPoint_9.Active9 = false;
            WayoutPoint_9_1.Active9_1 = false;
            WayoutPoint_9_2.Active9_2 = false;
            WayoutPoint_10.Active10 = false;
            WayoutPoint_11.Active11 = false;
            WayoutPoint_11_1.Active11_1 = false;
            WayoutPoint_11_2.Active11_2 = false;
            Corridor_1.ActiveCorridor = false;
            Corridor_2.ActiveCorridor_2 = false;
            Corridor_3.ActiveCorridor_3 = false;
            Corridor_4.ActiveCorridor_4 = false;
            Corridor_5.ActiveCorridor_5 = false;
            Corridor_6.ActiveCorridor_6 = false;
            Corridor_7.ActiveCorridor_7 = false;
            Corridor_8.ActiveCorridor_8 = false;
            Corridor_9.ActiveCorridor_9 = false;
            WayoutTriggerRooms.SetActive(false);
            Corridor.SetActive(false);
            if (tierUpTrigger == 0 && onSight == true)
            {
                speedTemp = speedTemp + 3f;
                tierUpTrigger++;
                patrol = false;
                for (int x = 0; x < ActivatesCorridor.Length; x++) {
                    ActivatesCorridor[x].SetActive(true);
                }
                SoundManager.PlaySound("Evil3");
            }
            drawChase = true;
            if (countDown == true) {
                if (timer >= 0) {
                    timer -= Time.deltaTime;
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
                if (currentState == EnemyState.walk && canAttack == true)
                {
                    StartCoroutine(attack());
                    StartCoroutine(FinishesLaughingAnim());
                }
            }
            ChangeState(EnemyState.walk);
            killerAnim.SetBool("walking", true);
        }
        else
        {
            Corridor.SetActive(true);
            WayoutTriggerRooms.SetActive(true);
            ChaseMusicManager_4.timer = 5f;
            tierUpTrigger = 0;
            if (timer <= 0 && tierDown == true)
            {
                patrol = false;
                speedTemp = speedTemp - 3f;
                SoundManager.PlaySound("Evil2");
                tierDown = false;
            }
            drawChase = false;
            wayPointIndexChase = 0;
            if (WayoutPoint.Active == true)
            {
                var wayout = GameObject.FindGameObjectWithTag("Room 1").GetComponent<WayoutPoint>();
                if (WayoutPointindex <= wayout.Waypoints1.Length - 1)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, wayout.Waypoints1[WayoutPointindex].transform.position,
                                   moveSpeed * Time.deltaTime);
                    changeAnim(temp - transform.position);
                    myRigidBody.MovePosition(temp);
                    ChangeState(EnemyState.walk);
                    killerAnim.SetBool("walking", true);
                    if (transform.position == wayout.Waypoints1[WayoutPointindex].transform.position)
                    {
                        WayoutPointindex++;
                    }

                    if (WayoutPointindex == wayout.Waypoints1.Length)
                    {
                        WayoutPoint.Active = false;
                        currPoint = 0;
                        currGoal = path[0];
                    }
                }
            }
            else if (WayoutPoint_2.Active2 == true)
            {
                var wayout2 = GameObject.FindGameObjectWithTag("Room 2").GetComponent<WayoutPoint_2>();
                if (WayoutPointindex <= wayout2.Waypoints_2.Length - 1)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, wayout2.Waypoints_2[WayoutPointindex].transform.position,
                                   moveSpeed * Time.deltaTime);
                    changeAnim(temp - transform.position);
                    myRigidBody.MovePosition(temp);
                    ChangeState(EnemyState.walk);
                    killerAnim.SetBool("walking", true);
                    if (transform.position == wayout2.Waypoints_2[WayoutPointindex].transform.position)
                    {
                        WayoutPointindex++;
                    }

                    if (WayoutPointindex == wayout2.Waypoints_2.Length)
                    {
                        WayoutPoint_2.Active2 = false;
                        currPoint = 0;
                        currGoal = path[0];
                    }
                }
            }
            else if (WayoutPoint_3.Active3 == true)
            {
                var wayout3 = GameObject.FindGameObjectWithTag("Room 3").GetComponent<WayoutPoint_3>();
                if (WayoutPointindex <= wayout3.Waypoints_3.Length - 1)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, wayout3.Waypoints_3[WayoutPointindex].transform.position,
                                   moveSpeed * Time.deltaTime);
                    changeAnim(temp - transform.position);
                    myRigidBody.MovePosition(temp);
                    ChangeState(EnemyState.walk);
                    killerAnim.SetBool("walking", true);
                    if (transform.position == wayout3.Waypoints_3[WayoutPointindex].transform.position)
                    {
                        WayoutPointindex++;
                    }

                    if (WayoutPointindex == wayout3.Waypoints_3.Length)
                    {
                        WayoutPoint_3.Active3 = false;
                        currPoint = 0;
                        currGoal = path[0];
                    }
                }
            }
            else if (WayoutPoint_3_1.Active3_1 == true)
            {
                var wayout3_1 = GameObject.FindGameObjectWithTag("Room 3 Middle").GetComponent<WayoutPoint_3_1>();
                if (WayoutPointindex <= wayout3_1.Waypoints_3_1.Length - 1)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, wayout3_1.Waypoints_3_1[WayoutPointindex].transform.position,
                                   moveSpeed * Time.deltaTime);
                    changeAnim(temp - transform.position);
                    myRigidBody.MovePosition(temp);
                    ChangeState(EnemyState.walk);
                    killerAnim.SetBool("walking", true);
                    if (transform.position == wayout3_1.Waypoints_3_1[WayoutPointindex].transform.position)
                    {
                        WayoutPointindex++;
                    }

                    if (WayoutPointindex == wayout3_1.Waypoints_3_1.Length)
                    {
                        WayoutPoint_3_1.Active3_1 = false;
                        currPoint = 0;
                        currGoal = path[0];
                    }
                }
            }
            else if (WayoutPoint_3_2.Active3_2 == true)
            {
                var wayout3_2 = GameObject.FindGameObjectWithTag("Room 3 Right").GetComponent<WayoutPoint_3_2>();
                if (WayoutPointindex <= wayout3_2.Waypoints_3_2.Length - 1)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, wayout3_2.Waypoints_3_2[WayoutPointindex].transform.position,
                                   moveSpeed * Time.deltaTime);
                    changeAnim(temp - transform.position);
                    myRigidBody.MovePosition(temp);
                    ChangeState(EnemyState.walk);
                    killerAnim.SetBool("walking", true);
                    if (transform.position == wayout3_2.Waypoints_3_2[WayoutPointindex].transform.position)
                    {
                        WayoutPointindex++;
                    }

                    if (WayoutPointindex == wayout3_2.Waypoints_3_2.Length)
                    {
                        WayoutPoint_3_2.Active3_2 = false;
                        currPoint = 0;
                        currGoal = path[0];
                    }
                }
            }
            else if (WayoutPoint_4.Active4 == true)
            {
                var wayout4 = GameObject.FindGameObjectWithTag("Room 4").GetComponent<WayoutPoint_4>();
                if (WayoutPointindex <= wayout4.Waypoints_4.Length - 1)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, wayout4.Waypoints_4[WayoutPointindex].transform.position,
                                   moveSpeed * Time.deltaTime);
                    changeAnim(temp - transform.position);
                    myRigidBody.MovePosition(temp);
                    ChangeState(EnemyState.walk);
                    killerAnim.SetBool("walking", true);
                    if (transform.position == wayout4.Waypoints_4[WayoutPointindex].transform.position)
                    {
                        WayoutPointindex++;
                    }

                    if (WayoutPointindex == wayout4.Waypoints_4.Length)
                    {
                        WayoutPoint_4.Active4 = false;
                        currPoint = 0;
                        currGoal = path[0];
                    }

                }
            }
            else if (WayoutPoint_5.Active5 == true)
            {
                var wayout5 = GameObject.FindGameObjectWithTag("Room 5").GetComponent<WayoutPoint_5>();
                if (WayoutPointindex <= wayout5.Waypoints_5.Length - 1)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, wayout5.Waypoints_5[WayoutPointindex].transform.position,
                                   moveSpeed * Time.deltaTime);
                    changeAnim(temp - transform.position);
                    myRigidBody.MovePosition(temp);
                    ChangeState(EnemyState.walk);
                    killerAnim.SetBool("walking", true);
                    if (transform.position == wayout5.Waypoints_5[WayoutPointindex].transform.position)
                    {
                        WayoutPointindex++;
                    }
                }
            }
            else if (WayoutPoint_6.Active6 == true)
            {
                var wayout6 = GameObject.FindGameObjectWithTag("Room 6").GetComponent<WayoutPoint_6>();
                if (WayoutPointindex <= wayout6.Waypoints_6.Length - 1)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, wayout6.Waypoints_6[WayoutPointindex].transform.position,
                                   moveSpeed * Time.deltaTime);
                    changeAnim(temp - transform.position);
                    myRigidBody.MovePosition(temp);
                    ChangeState(EnemyState.walk);
                    killerAnim.SetBool("walking", true);
                    if (transform.position == wayout6.Waypoints_6[WayoutPointindex].transform.position)
                    {
                        WayoutPointindex++;
                    }

                    if (WayoutPointindex == wayout6.Waypoints_6.Length)
                    {
                        WayoutPoint_6.Active6 = false;
                        currPoint = 0;
                        currGoal = path[0];
                    }
                }
            }
            else if (WayoutPoint_7.Active7 == true)
            {
                var wayout7 = GameObject.FindGameObjectWithTag("Room 7").GetComponent<WayoutPoint_7>();
                if (WayoutPointindex <= wayout7.Waypoints_7.Length - 1)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, wayout7.Waypoints_7[WayoutPointindex].transform.position,
                                   moveSpeed * Time.deltaTime);
                    changeAnim(temp - transform.position);
                    myRigidBody.MovePosition(temp);
                    ChangeState(EnemyState.walk);
                    killerAnim.SetBool("walking", true);
                    if (transform.position == wayout7.Waypoints_7[WayoutPointindex].transform.position)
                    {
                        WayoutPointindex++;
                    }

                    if (WayoutPointindex == wayout7.Waypoints_7.Length)
                    {
                        WayoutPoint_7.Active7 = false;
                        currPoint = 0;
                        currGoal = path[0];
                    }
                }
            }
            else if (WayoutPoint_8.Active8 == true)
            {
                var wayout8 = GameObject.FindGameObjectWithTag("Room 8").GetComponent<WayoutPoint_8>();
                if (WayoutPointindex <= wayout8.Waypoints_8.Length - 1)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, wayout8.Waypoints_8[WayoutPointindex].transform.position,
                                   moveSpeed * Time.deltaTime);
                    changeAnim(temp - transform.position);
                    myRigidBody.MovePosition(temp);
                    ChangeState(EnemyState.walk);
                    killerAnim.SetBool("walking", true);
                    if (transform.position == wayout8.Waypoints_8[WayoutPointindex].transform.position)
                    {
                        WayoutPointindex++;
                    }

                    if (WayoutPointindex == wayout8.Waypoints_8.Length)
                    {
                        WayoutPoint_8.Active8 = false;
                        wayout8.Waypoint8.SetActive(false);
                        currPoint = 0;
                        currGoal = path[0];
                    }
                }
            }
            else if (WayoutPoint_9.Active9 == true)
            {
                var wayout9 = GameObject.FindGameObjectWithTag("Room 9").GetComponent<WayoutPoint_9>();
                if (WayoutPointindex <= wayout9.Waypoints_9.Length - 1)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, wayout9.Waypoints_9[WayoutPointindex].transform.position,
                                   moveSpeed * Time.deltaTime);
                    changeAnim(temp - transform.position);
                    myRigidBody.MovePosition(temp);
                    ChangeState(EnemyState.walk);
                    killerAnim.SetBool("walking", true);
                    if (transform.position == wayout9.Waypoints_9[WayoutPointindex].transform.position)
                    {
                        WayoutPointindex++;
                    }

                    if (WayoutPointindex == wayout9.Waypoints_9.Length)
                    {
                        WayoutPoint_9.Active9 = false;
                        currPoint = 0;
                        currGoal = path[0];
                    }
                }
            }
            else if (WayoutPoint_9_1.Active9_1 == true)
            {
                var wayout9_1 = GameObject.FindGameObjectWithTag("Room 9 Middle").GetComponent<WayoutPoint_9_1>();
                if (WayoutPointindex <= wayout9_1.Waypoints_9_1.Length - 1)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, wayout9_1.Waypoints_9_1[WayoutPointindex].transform.position,
                                   moveSpeed * Time.deltaTime);
                    changeAnim(temp - transform.position);
                    myRigidBody.MovePosition(temp);
                    ChangeState(EnemyState.walk);
                    killerAnim.SetBool("walking", true);
                    if (transform.position == wayout9_1.Waypoints_9_1[WayoutPointindex].transform.position)
                    {
                        WayoutPointindex++;
                    }

                    if (WayoutPointindex == wayout9_1.Waypoints_9_1.Length)
                    {
                        WayoutPoint_9_1.Active9_1 = false;
                        currPoint = 0;
                        currGoal = path[0];
                    }
                }
            }
            else if (WayoutPoint_9_2.Active9_2 == true)
            {
                var wayout9_2 = GameObject.FindGameObjectWithTag("Room 9 Right").GetComponent<WayoutPoint_9_2>();
                if (WayoutPointindex <= wayout9_2.Waypoints_9_2.Length - 1)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, wayout9_2.Waypoints_9_2[WayoutPointindex].transform.position,
                                   moveSpeed * Time.deltaTime);
                    changeAnim(temp - transform.position);
                    myRigidBody.MovePosition(temp);
                    ChangeState(EnemyState.walk);
                    killerAnim.SetBool("walking", true);
                    if (transform.position == wayout9_2.Waypoints_9_2[WayoutPointindex].transform.position)
                    {
                        WayoutPointindex++;
                    }

                    if (WayoutPointindex == wayout9_2.Waypoints_9_2.Length)
                    {
                        WayoutPoint_9_2.Active9_2 = false;
                        currPoint = 0;
                        currGoal = path[0];
                    }
                }
            }
            else if (WayoutPoint_10.Active10 == true)
            {
                var wayout10 = GameObject.FindGameObjectWithTag("Room 10").GetComponent<WayoutPoint_10>();
                if (WayoutPointindex <= wayout10.Waypoints_10.Length - 1)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, wayout10.Waypoints_10[WayoutPointindex].transform.position,
                                   moveSpeed * Time.deltaTime);
                    changeAnim(temp - transform.position);
                    myRigidBody.MovePosition(temp);
                    ChangeState(EnemyState.walk);
                    killerAnim.SetBool("walking", true);
                    if (transform.position == wayout10.Waypoints_10[WayoutPointindex].transform.position)
                    {
                        WayoutPointindex++;
                    }

                    if (WayoutPointindex == wayout10.Waypoints_10.Length)
                    {
                        WayoutPoint_10.Active10 = false;
                        currPoint = 0;
                        currGoal = path[0];
                    }
                }
            }
            else if (WayoutPoint_10_1.Active10_1 == true)
            {
                var wayout10_1 = GameObject.FindGameObjectWithTag("Room 10 Middle").GetComponent<WayoutPoint_10_1>();
                if (WayoutPointindex <= wayout10_1.Waypoints_10_1.Length - 1)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, wayout10_1.Waypoints_10_1[WayoutPointindex].transform.position,
                                   moveSpeed * Time.deltaTime);
                    changeAnim(temp - transform.position);
                    myRigidBody.MovePosition(temp);
                    ChangeState(EnemyState.walk);
                    killerAnim.SetBool("walking", true);
                    if (transform.position == wayout10_1.Waypoints_10_1[WayoutPointindex].transform.position)
                    {
                        WayoutPointindex++;
                    }

                    if (WayoutPointindex == wayout10_1.Waypoints_10_1.Length)
                    {
                        WayoutPoint_10_1.Active10_1 = false;
                        currPoint = 0;
                        currGoal = path[0];
                    }
                }
            }
            else if (WayoutPoint_10_2.Active10_2 == true)
            {
                var wayout10_2 = GameObject.FindGameObjectWithTag("Room 10 Right").GetComponent<WayoutPoint_10_2>();
                if (WayoutPointindex <= wayout10_2.Waypoints_10_2.Length - 1)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, wayout10_2.Waypoints_10_2[WayoutPointindex].transform.position,
                                   moveSpeed * Time.deltaTime);
                    changeAnim(temp - transform.position);
                    myRigidBody.MovePosition(temp);
                    ChangeState(EnemyState.walk);
                    killerAnim.SetBool("walking", true);
                    if (transform.position == wayout10_2.Waypoints_10_2[WayoutPointindex].transform.position)
                    {
                        WayoutPointindex++;
                    }

                    if (WayoutPointindex == wayout10_2.Waypoints_10_2.Length)
                    {
                        WayoutPoint_10_2.Active10_2 = false;
                        currPoint = 0;
                        currGoal = path[0];
                    }
                }
            }
            else if (WayoutPoint_11.Active11 == true)
            {
                var wayout11 = GameObject.FindGameObjectWithTag("Room 11").GetComponent<WayoutPoint_11>();
                if (WayoutPointindex <= wayout11.Waypoints_11.Length - 1)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, wayout11.Waypoints_11[WayoutPointindex].transform.position,
                                   moveSpeed * Time.deltaTime);
                    changeAnim(temp - transform.position);
                    myRigidBody.MovePosition(temp);
                    ChangeState(EnemyState.walk);
                    killerAnim.SetBool("walking", true);
                    if (transform.position == wayout11.Waypoints_11[WayoutPointindex].transform.position)
                    {
                        WayoutPointindex++;
                    }

                    if (WayoutPointindex == wayout11.Waypoints_11.Length)
                    {
                        WayoutPoint_11.Active11 = false;
                        currPoint = 0;
                        currGoal = path[0];
                    }
                }
            }
            else if (WayoutPoint_11_1.Active11_1 == true)
            {
                var wayout11_1 = GameObject.FindGameObjectWithTag("Room 11 Middle").GetComponent<WayoutPoint_11_1>();
                if (WayoutPointindex <= wayout11_1.Waypoints_11_1.Length - 1)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, wayout11_1.Waypoints_11_1[WayoutPointindex].transform.position,
                                   moveSpeed * Time.deltaTime);
                    changeAnim(temp - transform.position);
                    myRigidBody.MovePosition(temp);
                    ChangeState(EnemyState.walk);
                    killerAnim.SetBool("walking", true);
                    if (transform.position == wayout11_1.Waypoints_11_1[WayoutPointindex].transform.position)
                    {
                        WayoutPointindex++;
                    }

                    if (WayoutPointindex == wayout11_1.Waypoints_11_1.Length)
                    {
                        WayoutPoint_11_1.Active11_1 = false;
                        currPoint = 0;
                        currGoal = path[0];
                    }
                }
            }
            else if (WayoutPoint_11_2.Active11_2 == true)
            {
                var wayout11_2 = GameObject.FindGameObjectWithTag("Room 11 Right").GetComponent<WayoutPoint_11_2>();
                if (WayoutPointindex <= wayout11_2.Waypoints_11_2.Length - 1)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, wayout11_2.Waypoints_11_2[WayoutPointindex].transform.position,
                                   moveSpeed * Time.deltaTime);
                    changeAnim(temp - transform.position);
                    myRigidBody.MovePosition(temp);
                    ChangeState(EnemyState.walk);
                    killerAnim.SetBool("walking", true);
                    if (transform.position == wayout11_2.Waypoints_11_2[WayoutPointindex].transform.position)
                    {
                        WayoutPointindex++;
                    }

                    if (WayoutPointindex == wayout11_2.Waypoints_11_2.Length)
                    {
                        WayoutPoint_11_2.Active11_2 = false;
                        currPoint = 0;
                        currGoal = path[0];
                    }
                }
            }
            else if (Corridor_1.ActiveCorridor == true)
            {
                var wayoutCorridor = GameObject.FindGameObjectWithTag("Corridor 1").GetComponent<Corridor_1>();
                Debug.Log(patrol);
                if (WayoutPointindex <= wayoutCorridor.WaypointsCorridor.Length - 1)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, wayoutCorridor.WaypointsCorridor[WayoutPointindex].transform.position,
                                   moveSpeed * Time.deltaTime);
                    changeAnim(temp - transform.position);
                    myRigidBody.MovePosition(temp);
                    ChangeState(EnemyState.walk);
                    killerAnim.SetBool("walking", true);
                    if (transform.position == wayoutCorridor.WaypointsCorridor[WayoutPointindex].transform.position)
                    {
                        WayoutPointindex++;
                    }

                    if (WayoutPointindex == wayoutCorridor.WaypointsCorridor.Length)
                    {
                        Corridor_1.ActiveCorridor = false;
                        wayoutCorridor.Waypoint.SetActive(false);
                        currPoint = 0;
                        currGoal = path[0];
                    }
                }
            }
            else if (Corridor_2.ActiveCorridor_2 == true)
            {
                var wayoutCorridor_2 = GameObject.FindGameObjectWithTag("Corridor 2").GetComponent<Corridor_2>();
                Debug.Log(patrol);
                if (WayoutPointindex <= wayoutCorridor_2.WaypointsCorridor_2.Length - 1)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, wayoutCorridor_2.WaypointsCorridor_2[WayoutPointindex].transform.position,
                                   moveSpeed * Time.deltaTime);
                    changeAnim(temp - transform.position);
                    myRigidBody.MovePosition(temp);
                    ChangeState(EnemyState.walk);
                    killerAnim.SetBool("walking", true);
                    if (transform.position == wayoutCorridor_2.WaypointsCorridor_2[WayoutPointindex].transform.position)
                    {
                        WayoutPointindex++;
                    }

                    if (WayoutPointindex == wayoutCorridor_2.WaypointsCorridor_2.Length)
                    {
                        Corridor_2.ActiveCorridor_2 = false;
                        wayoutCorridor_2.Waypoint_2.SetActive(false);
                        currPoint = 0;
                        currGoal = path[0];
                    }
                }
            }
            else if (Corridor_3.ActiveCorridor_3 == true)
            {
                var wayoutCorridor_3 = GameObject.FindGameObjectWithTag("Corridor 3").GetComponent<Corridor_3>();
                Debug.Log(patrol);
                if (WayoutPointindex <= wayoutCorridor_3.WaypointsCorridor_3.Length - 1)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, wayoutCorridor_3.WaypointsCorridor_3[WayoutPointindex].transform.position,
                                   moveSpeed * Time.deltaTime);
                    changeAnim(temp - transform.position);
                    myRigidBody.MovePosition(temp);
                    ChangeState(EnemyState.walk);
                    killerAnim.SetBool("walking", true);
                    if (transform.position == wayoutCorridor_3.WaypointsCorridor_3[WayoutPointindex].transform.position)
                    {
                        WayoutPointindex++;
                    }

                    if (WayoutPointindex == wayoutCorridor_3.WaypointsCorridor_3.Length)
                    {
                        Corridor_3.ActiveCorridor_3 = false;
                        wayoutCorridor_3.Waypoint_3.SetActive(false);
                        currPoint = 0;
                        currGoal = path[0];
                    }
                }
            }
            else if (Corridor_4.ActiveCorridor_4 == true)
            {
                var wayoutCorridor_4 = GameObject.FindGameObjectWithTag("Corridor 4").GetComponent<Corridor_4>();
                Debug.Log(patrol);
                if (WayoutPointindex <= wayoutCorridor_4.WaypointsCorridor_4.Length - 1)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, wayoutCorridor_4.WaypointsCorridor_4[WayoutPointindex].transform.position,
                                   moveSpeed * Time.deltaTime);
                    changeAnim(temp - transform.position);
                    myRigidBody.MovePosition(temp);
                    ChangeState(EnemyState.walk);
                    killerAnim.SetBool("walking", true);
                    if (transform.position == wayoutCorridor_4.WaypointsCorridor_4[WayoutPointindex].transform.position)
                    {
                        WayoutPointindex++;
                    }

                    if (WayoutPointindex == wayoutCorridor_4.WaypointsCorridor_4.Length)
                    {
                        Corridor_4.ActiveCorridor_4 = false;
                        wayoutCorridor_4.Waypoint_4.SetActive(false);
                        currPoint = 0;
                        currGoal = path[0];
                    }
                }
            }
            else if (Corridor_5.ActiveCorridor_5 == true)
            {
                var wayoutCorridor_5 = GameObject.FindGameObjectWithTag("Corridor 5").GetComponent<Corridor_5>();
                Debug.Log(patrol);
                if (WayoutPointindex <= wayoutCorridor_5.WaypointsCorridor_5.Length - 1)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, wayoutCorridor_5.WaypointsCorridor_5[WayoutPointindex].transform.position,
                                   moveSpeed * Time.deltaTime);
                    changeAnim(temp - transform.position);
                    myRigidBody.MovePosition(temp);
                    ChangeState(EnemyState.walk);
                    killerAnim.SetBool("walking", true);
                    if (transform.position == wayoutCorridor_5.WaypointsCorridor_5[WayoutPointindex].transform.position)
                    {
                        WayoutPointindex++;
                    }

                    if (WayoutPointindex == wayoutCorridor_5.WaypointsCorridor_5.Length)
                    {
                        Corridor_5.ActiveCorridor_5 = false;
                        wayoutCorridor_5.Waypoint_5.SetActive(false);
                        currPoint = 0;
                        currGoal = path[0];
                    }
                }
            }
            else if (Corridor_6.ActiveCorridor_6 == true)
            {
                var wayoutCorridor_6 = GameObject.FindGameObjectWithTag("Corridor 6").GetComponent<Corridor_6>();
                Debug.Log(patrol);
                if (WayoutPointindex <= wayoutCorridor_6.WaypointsCorridor_6.Length - 1)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, wayoutCorridor_6.WaypointsCorridor_6[WayoutPointindex].transform.position,
                                   moveSpeed * Time.deltaTime);
                    changeAnim(temp - transform.position);
                    myRigidBody.MovePosition(temp);
                    ChangeState(EnemyState.walk);
                    killerAnim.SetBool("walking", true);
                    if (transform.position == wayoutCorridor_6.WaypointsCorridor_6[WayoutPointindex].transform.position)
                    {
                        WayoutPointindex++;
                    }

                    if (WayoutPointindex == wayoutCorridor_6.WaypointsCorridor_6.Length)
                    {
                        Corridor_6.ActiveCorridor_6 = false;
                        wayoutCorridor_6.Waypoint_6.SetActive(false);
                        currPoint = 0;
                        currGoal = path[0];
                    }
                }
            }
            else if (Corridor_7.ActiveCorridor_7 == true)
            {
                var wayoutCorridor_7 = GameObject.FindGameObjectWithTag("Corridor 7").GetComponent<Corridor_7>();
                if (WayoutPointindex <= wayoutCorridor_7.WaypointsCorridor_7.Length - 1)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, wayoutCorridor_7.WaypointsCorridor_7[WayoutPointindex].transform.position,
                                   moveSpeed * Time.deltaTime);
                    changeAnim(temp - transform.position);
                    myRigidBody.MovePosition(temp);
                    ChangeState(EnemyState.walk);
                    killerAnim.SetBool("walking", true);
                    if (transform.position == wayoutCorridor_7.WaypointsCorridor_7[WayoutPointindex].transform.position)
                    {
                        WayoutPointindex++;
                    }

                    if (WayoutPointindex == wayoutCorridor_7.WaypointsCorridor_7.Length)
                    {
                        Corridor_7.ActiveCorridor_7 = false;
                        wayoutCorridor_7.Waypoint_7.SetActive(false);
                        currPoint = 0;
                        currGoal = path[0];
                    }
                }
            }
            else if (Corridor_8.ActiveCorridor_8 == true)
            {
                var wayoutCorridor_8 = GameObject.FindGameObjectWithTag("Corridor 8").GetComponent<Corridor_8>();
                Debug.Log(patrol);
                if (WayoutPointindex <= wayoutCorridor_8.WaypointsCorridor_8.Length - 1)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, wayoutCorridor_8.WaypointsCorridor_8[WayoutPointindex].transform.position,
                                   moveSpeed * Time.deltaTime);
                    changeAnim(temp - transform.position);
                    myRigidBody.MovePosition(temp);
                    ChangeState(EnemyState.walk);
                    killerAnim.SetBool("walking", true);
                    if (transform.position == wayoutCorridor_8.WaypointsCorridor_8[WayoutPointindex].transform.position)
                    {
                        WayoutPointindex++;
                    }

                    if (WayoutPointindex == wayoutCorridor_8.WaypointsCorridor_8.Length)
                    {
                        Corridor_8.ActiveCorridor_8 = false;
                        wayoutCorridor_8.Waypoint_8.SetActive(false);
                        currPoint = 0;
                        currGoal = path[0];
                    }
                }
            }
            else if (Corridor_9.ActiveCorridor_9 == true)
            {
                var wayoutCorridor_9 = GameObject.FindGameObjectWithTag("Corridor 9").GetComponent<Corridor_9>();
                if (WayoutPointindex <= wayoutCorridor_9.WaypointsCorridor_9.Length - 1)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, wayoutCorridor_9.WaypointsCorridor_9[WayoutPointindex].transform.position,
                                   moveSpeed * Time.deltaTime);
                    changeAnim(temp - transform.position);
                    myRigidBody.MovePosition(temp);
                    ChangeState(EnemyState.walk);
                    killerAnim.SetBool("walking", true);
                    if (transform.position == wayoutCorridor_9.WaypointsCorridor_9[WayoutPointindex].transform.position)
                    {
                        WayoutPointindex++;
                    }

                    if (WayoutPointindex == wayoutCorridor_9.WaypointsCorridor_9.Length)
                    {
                        Corridor_9.ActiveCorridor_9 = false;
                        wayoutCorridor_9.Waypoint_9.SetActive(false);
                        currPoint = 0;
                        currGoal = path[0];
                    }
                }
            }
            else
            {
                WayoutPointindex = 0;
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
        if (transform.position == path[0].position)
        {
            patrol = true;
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
        KillerSound.PlaySoundEnemy("Knife Sound Effect");
        currentState = EnemyState.attack;
        canAttack = false;
        killerAnim.SetBool("Attacking", true);
        yield return new WaitForSeconds(2.15f);
        canAttack = true;
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

    private void ChangeDestination() {
        var wayout = GameObject.FindGameObjectWithTag("Room 1").GetComponent<WayoutPoint>();
        if (WayoutPointindex != wayout.Waypoints.Length - 1) {
            WayoutPointindex++;
            currDest = wayout.Waypoints1[WayoutPointindex];
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.DrawWireSphere(transform.position, chaseSmallDistance);
        Gizmos.DrawWireSphere(transform.position, TerrorRadius);

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CloseDoor"))
        {
            StartCoroutine(FinishesAnimKicking());
            var door = other.gameObject.GetComponent<DoorHealth>();
            door.doorHealth -= 1;
        }
    }

    IEnumerator FinishesAnimKicking() {
        killerAnim.SetBool("Kicking", true);
        kicking = true;
        animTrigger = true;
        yield return new WaitForSeconds(timerAnimKicking);
        counter = 0;
        kicking = false;
        killerAnim.SetBool("Kicking", false);
        animTrigger = false;
    }

    IEnumerator FinishesLaughingAnim() {
        moveSpeed = 0;
        animTriggerKicking = true;
        canAttack = false;
        killerAnim.SetBool("Laughing", true);
        yield return new WaitForSeconds(timerAnimLaughing);
        killerAnim.SetBool("Laughing", false);
        animTriggerKicking = false;
        canAttack = true;
    }

    void checkDelay() {
        if (animTrigger == true || canAttack == false || animTriggerKicking == true)
        {
            moveSpeed = 0;
        }
        else if (animTrigger == false || canAttack == true || animTriggerKicking == false)
        {
            moveSpeed = speedTemp;
        }
    }
}
