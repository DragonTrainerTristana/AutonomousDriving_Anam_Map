using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Manage : MonoBehaviour
{

    public GameObject[] BOT;
    public GameObject TOP;
    public int numBOT;
    public float boundaryTime;

    //Variable of Time
    float originalTime;
    float originalTime2;

    bool timeState = false;
    int num = 0;

    string[,] array;
        
    //Path
    string filename = "";

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        filename = Application.dataPath + "/check.csv";

        array = new string[10, 2000];

        Debug.Log(BOT[0].transform.position.x);
            
        originalTime = 0.0f;
        originalTime2 = 0.0f;
        boundaryTime = 180.0f;

    }

    // Update is called once per frame
    void Update()
    {
        originalTime += Time.deltaTime;
        originalTime2 += Time.deltaTime;

        if (originalTime2 > 2.0f && timeState == false) { 
            originalTime2 = 0.0f;
            for (int i = 0; i < numBOT; i++)
            {
                for (int j = num; j < num + 2; j++)
                {
                    if (j % 2 == 0)
                    {
                        array[i, j] = BOT[i].transform.position.x.ToString();
                    }
                    else {
                        array[i, j] = BOT[i].transform.position.z.ToString();
                    }
                }
            }
            num+=2;
        }

        if (originalTime > boundaryTime && timeState == false) {

            Debug.Log("EXPORT START");
            timeState = true;
            using (StreamWriter sw = new StreamWriter(filename))
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    string line = "";
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        line += array[i, j] + ",";
                    }
                    line = line.TrimEnd(',');
                    sw.WriteLine(line);
                }
            }
            Debug.Log("EXPORT COMPLETE");
        }
    }
}
