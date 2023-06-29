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

    // Random range of bot position


    [SerializeField]
    private GameObject[] botArray;
    Vector3 ranPos;

    void Start()
    {
        min = -15.0f; max = 15.0f;

        botArray = new GameObject[botNum];
        for (int i = 0; i < botNum; i++) {
            Debug.Log(i);
            randomPos1 = Random.Range(min, max);
            randomPos2 = Random.Range(min, max);

            ranPos.x = randomPos1;
            ranPos.y = 1.0f;
            ranPos.z = randomPos2;

            botArray[i] = Instantiate(prefabBot,ranPos,Quaternion.identity);
        }


  
    }

    void Update()
    {
        
    }
}
