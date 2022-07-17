using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform ATMToControl;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindPlayer();
        AimATM();
    }

    private void FindPlayer()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void AimATM()
    {
        ATMToControl.LookAt(target);
    }

}
