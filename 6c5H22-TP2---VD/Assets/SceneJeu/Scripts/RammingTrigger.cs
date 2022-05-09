using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RammingTrigger : MonoBehaviour
{
    bool isToTheFront = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isToTheFront = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isToTheFront = false;
    }
}
