using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S : MonoBehaviour
{
    public GameObject panel;
    void Awake()
    {
        
    }
    public void dontbeadumbasstheyarenowinagoodstate(){
        panel.SetActive(false);
    }
}
