using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class BOT_Management : MonoBehaviour
{
    public int botNum;
    public GameObject prefabBot;

    float min, max;
    float randomPos1, randomPos2;

    Vector3 [] ranPos;
    // Random range of bot position


    [SerializeField]
    private GameObject[] botArray;
      
    void Start()
    {
        min = -15.0f; max = 15.0f;

        botArray = new GameObject[botNum];
        ranPos = new Vector3[botNum];

        for (int i = 0; i < botNum; i++) {
            randomPos1 = Random.Range(min, max);
            randomPos2 = Random.Range(min, max);

            // 같은 좌표일 때
            if (i >= 1) {
                for (int j = 0; j < i; j++) {
                    if (ranPos[j].x == ranPos[i].x && ranPos[j].z == ranPos[i].z) {
                        randomPos1 = Random.Range(min, max);
                        randomPos2 = Random.Range(min, max);
                        j = 0; // 처음부터 다시 확인
                    }
                }
            }

            ranPos[i].x = randomPos1;
            ranPos[i].y = 1.0f;
            ranPos[i].z = randomPos2;

            botArray[i] = Instantiate(prefabBot,ranPos[i],Quaternion.identity);

        }


  
    }

    void Update()
    {
        
    }
}
