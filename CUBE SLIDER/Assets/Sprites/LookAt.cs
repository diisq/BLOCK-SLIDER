using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform Player;
    void Update()
    {
        transform.LookAt(Player.position);
    }
    
}
