using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.transform.parent.gameObject.tag == "Player")
        {
            Debug.Log("Collision!");
            other.transform.parent.transform.parent.transform.parent.gameObject.GetComponent<PlayerCtrl>().lifePoint -= 1;
        }

    }
}
