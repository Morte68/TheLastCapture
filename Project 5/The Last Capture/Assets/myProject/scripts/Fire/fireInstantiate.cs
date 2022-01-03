using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireInstantiate : MonoBehaviour
{
    [SerializeField] Transform fireInstantiatePoint;
    [SerializeField] GameObject fire;
    float timeInterval = 5f;
    float timeIntervalCurrent = 0f;
    float timeStop = 30f;
    float timeStopCurrent = 0f;
    bool isTimeStop = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isTimeStop == false)
        {
            timeIntervalCurrent += Time.deltaTime;
            timeStopCurrent += Time.deltaTime;

            if (timeIntervalCurrent >= timeInterval)
            {
                Instantiate(fire, fireInstantiatePoint.position, fireInstantiatePoint.rotation);
                timeIntervalCurrent = 0f;
            }

            if (timeStopCurrent >= timeStop)
            {
                isTimeStop = true;
            }
        }
    }

}
