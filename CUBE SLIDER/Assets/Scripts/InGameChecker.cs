using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameChecker : MonoBehaviour
{
    public GameObject panel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            {
                panel.SetActive(!panel.activeInHierarchy);
            }
        }
    } 
    
    }
