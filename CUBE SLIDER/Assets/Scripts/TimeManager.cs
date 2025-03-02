using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private int minutes;
    private int hours;
    private int days;

    private float tempSecond;

    public void Update()
    {
        tempSecond += Time.deltaTime;
        if (tempSecond >= 1)
        {
            minutes -= 1;
            tempSecond = 0;
        }
    }
}
