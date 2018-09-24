using Multiplayer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RemoteViewportCamera : MonoBehaviour {
    private GameObject _remoteCamera = null;
    public NetworkManager _networkManager;

    int selectedPlayerId = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            selectedPlayerId++;
            
            Player [] players = GameObject.FindObjectsOfType<Player>();
            if(players.Length > 0)
            {
                if (selectedPlayerId >= players.Length)
                    selectedPlayerId = 0;
                _remoteCamera = players[selectedPlayerId].gameObject;
            }

        }

		if(_remoteCamera != null)
            this.transform.SetPositionAndRotation(_remoteCamera.transform.position, _remoteCamera.transform.rotation);
	}
}
