using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // private double ClickTime;
    // private double ComboTime;
    // private float cooldownDuration = 1f; 
    // private float cooldownTimer; 
    // private bool isClick;
    private Animator _animator;
    
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }


    void Update()
    {
        /*
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
            
            cooldownTimer = Mathf.Max(0, cooldownTimer);
            
            if (cooldownTimer==0)
            {
                _counter = 0;
                _animator.SetInteger("ComboCount",_counter);
                
            }
    
            if (Input.GetMouseButtonDown(0) )
            {
               
                 if (_counter>2)
                 {
                     _counter = 0;
                     _animator.SetInteger("ComboCount",_counter);
                 }
                 else
                 {
                     _counter++;
                     _animator.SetInteger("ComboCount",_counter);
                     cooldownTimer = cooldownDuration;
                 }
               
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (cooldownTimer == 0)
            {
                _counter++;
                _animator.SetInteger("ComboCount",_counter);
                cooldownTimer = cooldownDuration;
            }
        }
        */
    }


   
      
        
    
}
