using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.AI;

public class MonsterCTRL : MonoBehaviour
{
    public float chaseRange = 10.0f;
    public NavMeshAgent navMeshAgent;
    public GameObject Player;
    [SerializeField] private float speed = 3.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        if(Player == null)
        {
            Player = GameObject.Find("Player");
        }
        navMeshAgent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        TargetDetect(Player);
    }
    private void TargetDetect(GameObject target)
    {
        //target���� �Ÿ� ���ϱ�
        float distanceToTarget = Vector3.Distance(target.gameObject.transform.position, transform.position);

        //target���� �Ÿ��� chaseRange���� ���� �� ����
        if (distanceToTarget <= chaseRange)
        {
            navMeshAgent.SetDestination(target.transform.position);
        }
    }
}
