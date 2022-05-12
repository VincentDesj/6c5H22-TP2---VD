using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerCtrl : NetworkBehaviour
{
	private GameManager gameManager = new GameManager();

	public int lifePoint = 5;

	public override void OnStartServer()
	{
		base.OnStartServer();
		Debug.Log("On fait des boules");
		gameManager.SpawnBalls();
		//TODO spawn balls.
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
