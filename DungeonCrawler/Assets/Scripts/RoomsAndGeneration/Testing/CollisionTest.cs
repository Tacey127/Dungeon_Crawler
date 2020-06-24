using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    [SerializeField] GameObject gm;

    void OnTriggerEnter(Collider other)
    {
       
            Debug.Log("AAAAAAAAA");
    }
    
}
