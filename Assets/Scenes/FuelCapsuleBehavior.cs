using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCapsuleBehavior : MonoBehaviour
{


    void OnCollisionEnter2D(Collision2D collision) // not working at the moment, maybe not needed
    {

        Debug.Log("There has been a collision with a capsule.");

    }

}
