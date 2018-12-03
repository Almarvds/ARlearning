using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private const string PLAYER_ID_PREFIX = "Player "; 
    private static Dictionary<string, Player> players = new Dictionary<string, Player>();
    public Text name;


    public void RegisterPlayer(string Net_id, Player _player)
    {
        string playerID = PLAYER_ID_PREFIX + Net_id;
        players.Add(playerID, _player);
        _player.transform.name = playerID;
        name.text = "welcome to Mathbuilder " + playerID;
    }

}
