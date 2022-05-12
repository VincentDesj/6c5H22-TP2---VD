using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerCtrl : NetworkBehaviour
{
	public int lifePoint = 5;

    public override void OnStartServer()
	{
		base.OnStartServer();
	}

	void Update()
	{
		if (lifePoint <= 0)
			Destroy(gameObject);
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		string netId = GetComponent<NetworkIdentity>().netId.ToString();
		PlayerCtrl player = GetComponent<PlayerCtrl>();

		GameManager.RegisterPlayer(netId, player);
	}

	private void OnDisable()
	{
		GameManager.UnregisterPlayer(transform.name);
	}
}
