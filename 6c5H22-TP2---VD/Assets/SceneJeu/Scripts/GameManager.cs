using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ball;

    public Transform position01;
    public Transform position02;

    private const string playerIdPrefix = "Player";

    private static Dictionary<string, PlayerCtrl> players = new Dictionary<string, PlayerCtrl>();

    public static string RegisterPlayer(string netID, PlayerCtrl player)
    {
        string playerId = playerIdPrefix + netID;
        players.Add(playerId, player);
        return playerId;
    }

    public static void UnregisterPlayer(string playerId)
    {
        players.Remove(playerId);
    }

    public void SpawnBalls() 
    {
        Instantiate(ball, position01.transform.position, position01.transform.rotation);
        Instantiate(ball, position02.transform.position, position02.transform.rotation);
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(270, 25, 200, 500));
        GUILayout.BeginVertical();

        foreach (KeyValuePair<string, PlayerCtrl> playerId in players)
            GUILayout.Label(playerId.Key + " - " + playerId.Value.lifePoint);

        GUILayout.EndVertical();
        GUILayout.EndArea();
    }
}
