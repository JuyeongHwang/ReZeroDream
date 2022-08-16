using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMovement : MonoBehaviour
{

    //�ڿ��� �Ѿƿ��� ��������, �տ��� �ٰ����� ����ͼ� �ѹ� ��ġ�� ������

    // -> ���� ���Ѿ���. ���� Ǯ�� ���� ������ �ִ� ��?? �ѹ� ������ ��� ����ְ�, �ٸ� �ൿ �Ұ���. userstate : attackReady

    public Transform pathHolder;
    [Header("Status")]
    public float speed = 3.0f;
    public float waitTime = .3f;
    public float turnSpeed = 90;
    public float chasingTime = 5.0f;
    public float viewDistance = 10;
    [Header("Commons")]
    public Light spotlight;
    public LayerMask viewMask;
    float viewAngle;

    enum MonsterState { PATROL, CHASE, ATTACK, BACK, CATCHED };
    [SerializeField] MonsterState monsterState = MonsterState.PATROL;
    [SerializeField] private int targetWayPointIndex = 0;

    private Transform player;
    private Animator anim; // walkAttack  ( 0 : ���ݸ�, 0.3 : ���� & �ȱ� 0.6 �̻� �ȱ�)
    private Color originalSpotlightColor;
    private Vector3[] waypoints;
    private Coroutine follow;
    

    private void Start()
    {

        viewAngle = spotlight.spotAngle;
        player = FindObjectOfType<PlayerInput>().transform;        
        anim = GetComponent<Animator>();
        originalSpotlightColor = spotlight.color;

        waypoints = new Vector3[pathHolder.childCount];
        for(int i = 0; i<waypoints.Length; i++)
        {
            waypoints[i] = pathHolder.GetChild(i).position;
            waypoints[i].y = transform.position.y;
        }

        monsterState = MonsterState.PATROL;
        follow = StartCoroutine(FollowPath(waypoints));
    }


    private void Update()
    {

        //1. ���Ͱ� ���� ��� �� ����

        ControlMonsterState();
        //2. ���Ͱ� �÷��̾ �� �� ������,
        if (CanSeePlayer() && monsterState != MonsterState.BACK)
        {
            //2-1. ó�� �߰��ѰŶ��, ��Ʈ�� ����
            if (monsterState != MonsterState.CHASE)
            {
                StopCoroutine(follow);
            }
            //2-2. �Ѵ´�
            ChasePlayer();
        }
        else
        {
            if (monsterState != MonsterState.PATROL)
            {

                monsterState = MonsterState.PATROL;
                follow = StartCoroutine(FollowPath(waypoints));
                anim.SetFloat("WalkAttack", 1.0f);
                viewDistance = 10;
                spotlight.color = originalSpotlightColor;
            }

        }
    }

    void ControlMonsterState()
    {
        if (monsterState == MonsterState.CATCHED)
        {
            return;
        }

        else if (monsterState == MonsterState.CHASE)
        {
            StopCoroutine(follow);
            spotlight.color = Color.cyan;
            viewDistance = 20;

            transform.LookAt(player.position);

            Vector3 diff = player.position - transform.position;
            float distance = diff.magnitude;
            Vector3 orient = diff / distance;
            Vector3 newPos = transform.transform.position + orient * 15 * Time.deltaTime;//Vector3.Lerp(transform.transform.position, transform.transform.position + orient, speed * Time.deltaTime);//this.transform.position + direction.normalized * 10 * Time.deltaTime;

            transform.GetComponent<Rigidbody>().MovePosition(newPos);
        }
        else if(monsterState == MonsterState.ATTACK)
        {
            anim.SetTrigger("Attack");
            print("���� �и�");

            follow = StartCoroutine(FollowPath(waypoints));
            monsterState = MonsterState.PATROL;
        }
        else if(monsterState == MonsterState.PATROL)
        {
            anim.SetFloat("WalkAttack", 1.0f);
            viewDistance = 10;
            spotlight.color = originalSpotlightColor;
        }
    }
    bool CanSeePlayer()
    {
        //1. �ݰ� �ȿ� �ִ°�
        if (Vector3.Distance(transform.position, player.position) < viewDistance)
        {
            //2. ���� �� �ޱ� �ȿ� �ִ°�
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            float angleBetweenGuardAndPlayer = Vector3.Angle(transform.forward, dirToPlayer);
            if (angleBetweenGuardAndPlayer < viewAngle / 2f)
            {
                //3. ��ֹ��� �������°� - ���̾��ũ, ĳ��Ʈ Ȱ��
                if (!Physics.Linecast(transform.position, player.position, viewMask))
                {
                    return true;
                }
            }
        }
        return false;

    }



    void ChasePlayer()
    {

        spotlight.color = Color.cyan;
        viewDistance = 20;
        float animScale = 1.0f;


        if (Vector3.Distance(player.position, transform.position) < 1.0f && monsterState != MonsterState.ATTACK)        //�÷��̾�� ��������� �о
        {
            monsterState = MonsterState.ATTACK;
            anim.SetTrigger("Attack");
            monsterState = MonsterState.BACK;
        }
        else //�Ѿư�
        {
            monsterState = MonsterState.CHASE;

            float chaseSpeed = speed * 7;

            animScale -= Time.deltaTime * 0.5f;
            Vector3 diff = player.position - transform.position;
            float distance = diff.magnitude;
            Vector3 orient = diff / distance;
            Vector3 newPos = transform.transform.position + orient * chaseSpeed * Time.deltaTime;//Vector3.Lerp(transform.transform.position, transform.transform.position + orient, speed * Time.deltaTime);//this.transform.position + direction.normalized * 10 * Time.deltaTime;
            transform.GetComponent<Rigidbody>().MovePosition(newPos);

            transform.LookAt(player.position);
            anim.SetFloat("WalkAttack", animScale);

        }
    }






    IEnumerator FollowPath(Vector3[] waypoints)
    {
        Vector3 targetWayPoint = waypoints[targetWayPointIndex];

        yield return TurnToFace(targetWayPoint); //Ÿ������ ȸ��

        while (true)
        {
            //Ÿ������ �̵�
            transform.position = Vector3.MoveTowards(transform.position, targetWayPoint, speed * Time.deltaTime);
            //anim.SetFloat("WalkAttack 0", 1.0f);

            //���� �� Ÿ�ٿ� �����ߴٸ�,
            if ((targetWayPoint - this.transform.position).magnitude < 0.05f)
            {

                targetWayPointIndex++;
                targetWayPointIndex = (targetWayPointIndex) % waypoints.Length;
                targetWayPoint = waypoints[targetWayPointIndex];
                yield return StartCoroutine(TurnToFace(targetWayPoint));
            }

            yield return null;
        }

    }


    IEnumerator TurnToFace(Vector3 lookTarget)
    {
        Vector3 dirToLookTarget = (lookTarget - this.transform.position).normalized;
        float targetAngle = 90 - Mathf.Atan2(dirToLookTarget.z, dirToLookTarget.x) * Mathf.Rad2Deg;

        //(this.transform.eulerAngles.y-targetAngle)
        while (Mathf.Abs(Mathf.DeltaAngle(this.transform.eulerAngles.y, targetAngle)) > 0.05f)
        {
            float angle = Mathf.MoveTowardsAngle(this.transform.eulerAngles.y, targetAngle, turnSpeed * Time.deltaTime);
            this.transform.eulerAngles = Vector3.up * angle;
            yield return null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "trap")
        {
            monsterState = MonsterState.CATCHED;
            anim.SetTrigger("Dizzy");
            spotlight.enabled = false;
        }
    }


    private void OnDrawGizmos()
    {
        Vector3 startPos = pathHolder.GetChild(0).position;
        Vector3 prevWayPos = startPos;

        foreach (Transform wayPoint in pathHolder)
        {
            Gizmos.DrawSphere(wayPoint.position, .3f);
            Gizmos.DrawLine(prevWayPos, wayPoint.position);
            prevWayPos = wayPoint.position;
        }
        Gizmos.DrawLine(startPos, prevWayPos);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * viewDistance);
    }

}
