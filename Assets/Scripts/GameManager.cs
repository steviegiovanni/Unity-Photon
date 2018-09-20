using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

namespace Com.MyCompany.MyGame
{
    public class GameManager : Photon.PunBehaviour
    {
        #region Photon Messages
        public override void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
        {
            Debug.Log("OnPhotonPlayerConnected() " + newPlayer.NickName);
            if (PhotonNetwork.isMasterClient)
            {
                Debug.Log("OnPhotonPlayerConnected isMasterClient " + PhotonNetwork.isMasterClient);
                LoadArena();
            }
        }

        public override void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer)
        {
            Debug.Log("OnPhotonPlayerDisconnected() " + otherPlayer.NickName);
            if (PhotonNetwork.isMasterClient)
                Debug.Log("OnPhotonPlayerDisconnected isMasterClient " + PhotonNetwork.isMasterClient);
            LoadArena();
        }

        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(0);
        }
        #endregion

        #region Public Methods
        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }
        #endregion

        #region Private Methods
        void LoadArena()
        {
            if (!PhotonNetwork.isMasterClient)
            {
                Debug.LogError("PhotonNetwork: Trying to load a level but we are not the master Client");
            }
            Debug.Log("PhotonNetwork: Loading Level: " + PhotonNetwork.room.PlayerCount);
            PhotonNetwork.LoadLevel("Room for " + PhotonNetwork.room.PlayerCount);
        }
        #endregion
    }
}
