using UnityEngine;
using UnityEngine.AI;   // ��ũ��Ʈ���� ������̼� �ý��� ����� ����Ϸ��� AI ���ӽ����̽��� using �����ؾ���
using static UnityEditor.PlayerSettings;

public class Object : MonoBehaviour
{
    // ���� ã�Ƽ� �̵��� ������Ʈ
    NavMeshAgent agent;

    // ������Ʈ�� ������
    [SerializeField]
    Transform target;

    private void Awake()
    {

     
        // ������ ���۵Ǹ� ���� ������Ʈ�� ������ NavMeshAgent ������Ʈ�� �����ͼ� ����
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false; //�׺����
    }

    void Start()
    {
    }

    void Update()
    {
        // �����̽� Ű�� ������ Target�� ��ġ���� �̵��ϴ� ��θ� ����ؼ� �̵�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ������Ʈ���� �������� �˷��ִ� �Լ�
            agent.SetDestination(target.position);
            agent.enabled = true;
        }
    }
}