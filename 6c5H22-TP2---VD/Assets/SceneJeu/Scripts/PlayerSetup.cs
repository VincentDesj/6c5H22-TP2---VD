using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    Behaviour[] componentsToDisable;

    void Start()
    {
        if (!isLocalPlayer) {
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
        }
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        string netId = GetComponent<NetworkIdentity>().netId.ToString();
        PlayerPrefs player = GetComponent<Player>();

        GameManager.RegisterPlayer(netId, player);
    }
}
