using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.transform.parent.gameObject.tag == "Player")
        { 
            other.transform.parent.transform.parent.gameObject.GetComponent<PrometeoCarController>().hp -= 1;
            if (other.transform.parent.transform.parent.gameObject.GetComponent<PrometeoCarController>().hp <= 0)
            {
                GameManager.UnresgisterPlayer(other.transform.parent.transform.parent.transform.parent.gameObject.name);
                Destroy(other.transform.parent.transform.parent.transform.parent.gameObject);
            }
        }

    }
}
