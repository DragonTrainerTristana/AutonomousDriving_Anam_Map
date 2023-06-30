using UnityEngine;
using UnityEngine.AI;   // 스크립트에서 내비게이션 시스템 기능을 사용하려면 AI 네임스페이스를 using 선언해야함
using static UnityEditor.PlayerSettings;

public class Object : MonoBehaviour
{
    // 길을 찾아서 이동할 에이전트
    NavMeshAgent agent;

    public GameObject[] target_Object;
    public Transform[] target;

    float originalTime = 0.0f;
    float boundaryTime = 10.0f;
    float stayTime = 0.0f;

    bool stopTime = false;
    float randomTime = 0.0f;

    int ranNum;
    int newNum;

    // 에이전트의 목적지



    private void Awake()
    {   
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false; //네비끄기
    }

    void Start()
    {



        ranNum = Random.Range(0, 20);


        // target location 
        target_Object = new GameObject[10];
        target = new Transform[10];



        for (int i = 0; i < 10; i++) {
            Debug.Log("TARGET (" + i + ")");
            target_Object[i] = GameObject.Find("TARGET (" + i + ")");
            target[i] = target_Object[i].transform;

        }




    }

    void Update()
    {

        originalTime += Time.deltaTime;

        if (originalTime >= 5.0f) {
            agent.speed = Random.Range(3.5f, 6.5f);
        }

        if (boundaryTime >= originalTime) {
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
                agent.speed = 5.0f;
            }
        }

        agent.SetDestination(target[ranNum].position);
        agent.enabled = true;
       


    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "TARGET") {

            for (;;) {
                newNum = Random.Range(0, 10);
                if (newNum == ranNum) { 
                }
                if (newNum != ranNum) { ranNum = newNum;  break; }
            }
        }
    }
}