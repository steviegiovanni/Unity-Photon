using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.MyCompany.MyGame
{
    public class Launcher : Photon.PunBehaviour
    {
        #region Public Variables
        public PhotonLogLevel LogLevel = PhotonLogLevel.Informational;
        public byte MaxPlayersPerRoom = 4;
        public GameObject controlPanel;
        public GameObject progressLabel;

        #endregion

        #region Private Variables
        string _gameVersion = "1";
        bool isConnecting;

        #endregion

        #region MonoBehaviour Callbacks

        private void Awake()
        {
            PhotonNetwork.autoJoinLobby = false;
            PhotonNetwork.automaticallySyncScene = true;
            PhotonNetwork.logLevel = LogLevel;
        }

        private void Start()
        {
            progressLabel.SetActive(false);
            controlPanel.SetActive(true);
        }

        #endregion

        #region Public Methods

        public void Connect()
        {
            isConnecting = true;
            progressLabel.SetActive(true);
            controlPanel.SetActive(false);

            if (PhotonNetwork.connected)
                PhotonNetwork.JoinRandomRoom();
            else
                PhotonNetwork.ConnectUsingSettings(_gameVersion);
        }

        #endregion

        #region Photon.PunBehaviour Callbacks

        public override void OnConnectedToMaster()
        {
            Debug.Log("Launcher: OnConnectedToMaster() was called by PUN");
            if(isConnecting)
                PhotonNetwork.JoinRandomRoom();
        }

        public override void OnDisconnectedFromPhoton()
        {
            progressLabel.SetActive(true);
            controlPanel.SetActive(false);
            Debug.LogWarning("Launcher: OnDisconnectedFromPhoton() was called by PUN");
        }

        public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
        {
            Debug.Log("Launcher: OnPhotonRandomJoinFailed() was called by PUN. No random room available, so we create one.\nCaling: PhotonNetwork.CreateRoom(nukk, new RoomOptions(){maxPlayers = 4}, null);");
            PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = MaxPlayersPerRoom }, null);
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("We load the 'Room for 1'");
            PhotonNetwork.LoadLevel("Room for 1");
        }

        #endregion
    }
}
