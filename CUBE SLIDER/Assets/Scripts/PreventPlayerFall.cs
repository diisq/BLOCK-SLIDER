using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    
    void Update()
    {
        if(transform.position.y <= -17)
        {
            transform.position = new Vector3(0, 10, 0);
        }
    }
    
}
