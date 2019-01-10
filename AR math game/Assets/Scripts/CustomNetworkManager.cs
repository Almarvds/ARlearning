using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

public class CustomNetworkManager : NetworkManager {

    private float nextRefreshTime; 

    public void StartHosting()
    {
        Debug.Log("first player hosting");
        StartMatchMaker();
        matchMaker.CreateMatch("Almars Match", 4, true, "", "", "", 0, 0, OnMatchCreated);
    }

    private void OnMatchCreated(bool success, string extendedinfo, MatchInfo responsedata)
    {
        base.StartHost(responsedata);
        Debug.Log("match created");
        RefreshMatches();
    }

    //private void Update()
    //{
    //    if (Time.time >= nextRefreshTime)
    //    {
    //        RefreshMatches();
    //    }
    //}

    private void RefreshMatches()
    {
        nextRefreshTime = Time.time + 5f;

        if (matchMaker == null)
            StartMatchMaker();

        matchMaker.ListMatches(0, 10, "", true, 0, 0, HandleListMatchesComplete);
    }

    private void HandleListMatchesComplete(bool success,
         string extendedinfo,
         List<MatchInfoSnapshot> responsedata)
    {
        AvailableMatchesList.HandleNewMatchList(responsedata);
    }

    public void JoinMatch()
    {
        if (matchMaker == null)
            StartMatchMaker();

        Debug.Log(matches[matches.Count - 1].networkId);
        matchMaker.JoinMatch(matches[matches.Count - 1].networkId, "", "", "", 0, 0, HandleJoinedMatch);
    }

    private void HandleJoinedMatch(bool success, string extendedinfo, MatchInfo responsedata)
    {
        StartClient(responsedata);
    }





    public void StartHost2()
    {
        Debug.Log("starting matchmaker");
        StartMatchMaker();
        CreateInternetMatch("Almars Match");
    }

    //call this method to request a match to be created on the server
    public void CreateInternetMatch(string matchName)
    {
        Debug.Log("Creating match");
        matchMaker.CreateMatch(matchName, 4, true, "", "", "", 0, 0, OnInternetMatchCreate);
    }

    //this method is called when your request for creating a match is returned
    private void OnInternetMatchCreate(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        if (success)
        {
            Debug.Log("Create match succeeded");

            MatchInfo hostInfo = matchInfo;
            NetworkServer.Listen(hostInfo, 9000);

            Debug.Log("starting to host game");
            StartHost(hostInfo);
        }
        else
        {
            Debug.LogError("Create match failed");
        }
    }

    //join an available match
    public void FindInternetMatch()
    {
        Debug.Log("'Second player joining");
        if (matchMaker == null)
        {
            StartMatchMaker();
        }       
            matchMaker.ListMatches(0, 10, "Almars Match", true, 0, 0, OnInternetMatchList);
    }

    private void OnInternetMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matches)
    {
        if (success)
        {
            if (matches.Count != 0)
            {
                Debug.Log("A list of matches was returned");

                //join the last server (just in case there are two..    
                matchMaker.JoinMatch(matches[matches.Count - 1].networkId, "", "", "", 0, 0, OnJoinInternetMatch);
            }
            else
            {
                Debug.Log("No matches in requested room!");
            }
        }
        else
        {
            Debug.LogError("Couldn't connect to match maker");
        }
    }

    private void OnJoinInternetMatch(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        if (success)
        {
            Debug.Log("Able to join a match");

            MatchInfo hostInfo = matchInfo;
            StartClient(hostInfo);
        }
        else
        {
            Debug.LogError("Join match failed");
        }
    }

}
