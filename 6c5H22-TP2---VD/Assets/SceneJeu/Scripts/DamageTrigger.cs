using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    public GameObject body;
    private RammingTrigger rammingTrigger;
    private bool isToTheFront;

    private void Start()
    {
        isToTheFront = this.GetComponentInChildren<Body>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.tag == "Player")
        {
            Debug.Log("Player is now at" + (other.GetComponent<PrometeoCarController>().hp - 1));
            other.GetComponent<PrometeoCarController>().hp = other.GetComponent<PrometeoCarController>().hp - 1;
        }
    }
}
