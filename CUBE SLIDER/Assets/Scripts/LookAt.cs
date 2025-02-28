using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform player;
    void Update()
    {
        Vector3 dir = (player.position - transform.position).normalized;
        transform.forward = dir;
    }
}
