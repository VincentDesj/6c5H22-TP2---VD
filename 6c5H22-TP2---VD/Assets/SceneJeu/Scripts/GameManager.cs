using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const string playerIdPrefix = "Player";

    private static Dictionary<string, PlayerCtrl> players = new Dictionary<string, PlayerCtrl>();

    public static void RegisterPlayer(string netID, PlayerCtrl player)
    {
        if (player.gameObject.tag == "Player") 
        { 
            string playerId = playerIdPrefix + (Int32.Parse(netID) - 2);
            players.Add(playerId, player);
            player.transform.name = playerId;
        }
    }

    public static void UnregisterPlayer(string playerId)
    {
        players.Remove(playerId);
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(1000, 25, 200, 500));
        GUILayout.BeginVertical();

        foreach (string playerId in players.Keys) 
        {
            if (players[playerId].tag == "Player")
                if (players[playerId] == null) 
                { 
                    
                }
                GUILayout.Label(playerId + " - " + players[playerId].lifePoint);
        }

        GUILayout.EndVertical();
        GUILayout.EndArea();
    }
}
