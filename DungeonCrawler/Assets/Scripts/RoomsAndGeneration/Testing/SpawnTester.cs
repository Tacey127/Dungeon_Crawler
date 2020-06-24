using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTester : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject sq;
    [SerializeField] bool giveCollision = false;
    void Start()
    {

        //turn off physics
        Physics.autoSimulation = false;

        GameObject haveCol = Instantiate(sq, transform);
        haveCol.SetActive(giveCollision);

        Instantiate(sq, transform);


        Physics.Simulate(0.01f);
        //ITS ALIVE

    }

    // Update is called once per frame

}
