/////////////////////////////////////////////////////////////////////////////////////////////////////////
// # Project Name: NeuronAlz
// # Code Developer: JORGE MENEU MORENO
// # Date: 25/11/2021
// # Credits: Unity Documentation, Unity Answers
// # Definition:
//   Este script coloca la pieza en su holder si estána  una distancia de 50.
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPosition : MonoBehaviour
{
    public GameObject my_holder;
    private Rigidbody2D myRigidbody;

    void Update()
    {

        myRigidbody = GetComponent<Rigidbody2D>();
        if (MixPieces.instance.StartGame == true)
        {
                if ((Vector3.Distance(transform.position, my_holder.transform.position)) <= 50f)
                {
                    transform.position = my_holder.transform.position;
                    myRigidbody.simulated = false;
                }
        }


    }
}
