using UnityEngine;
using UnityEngine.AI;   // ��ũ��Ʈ���� ������̼� �ý��� ����� ����Ϸ��� AI ���ӽ����̽��� using �����ؾ���
using static UnityEditor.PlayerSettings;

public class Object : MonoBehaviour
{
    // ���� ã�Ƽ� �̵��� ������Ʈ
    NavMeshAgent agent;

    public Transform[] target;
    //public Transform target;

    float originalTime = 0.0f;
    float originalTime2 = 0.0f;
    float boundaryTime = 7.0f;
    float stayTime = 0.0f;

    bool stopTime = false;
    float randomTime = 0.0f;

    int ranNum;
    int newNum;

    // ������Ʈ�� ������



    private void Awake()
    {   
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false; //�׺����
    }

    void Start()
    {

        ranNum = Random.Range(0, 10);
        agent.enabled = true;
        boundaryTime = Random.Range(10.0f, 50.0f);

        // target location 
        //target = new Transform[10];

    }

    void Update()
    {

        originalTime += Time.deltaTime;
        originalTime2 += Time.deltaTime;


        if (originalTime2 >= 5.0f && stopTime == false) {
            agent.speed = Random.Range(7.5f, 10.5f);
            originalTime2 = 0.0f;
        }

        if (boundaryTime <= originalTime) {
            originalTime = 0.0f;
            boundaryTime = Random.Range(10.0f, 50.0f);
            randomTime = Random.Range(5.0f, 15.0f);
            stopTime = true;
        }

        if (stopTime == true) {
            stayTime += Time.deltaTime;

            agent.speed = 0.0f;

            if (stayTime >= randomTime) {
                stopTime = false;
                stayTime = 0.0f;
                agent.speed = 6.0f;
            }
        }

        agent.SetDestination(target[ranNum].position);
        agent.enabled = true;

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "TARGET") {

            for (;;) {
                newNum = Random.Range(0, 10);
                if (newNum == ranNum){}
                if (newNum != ranNum) { ranNum = newNum;  break; }
            }
        }
    }
}