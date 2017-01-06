using UnityEngine;
using System.Collections;

public class Connect : Photon.MonoBehaviour
{


    public bool offline = false;
    private byte Version = GameManager.Version;
    bool showConnectionState = true;
    string prevConnectionState;
    public string loadSceneName;

    // Use this for initialization
    void Start()
    {

        //if (offline)
        //{
        //    PhotonNetwork.offlineMode = true;
        //    Debug.Log("Offline Mode!");

        //}
        //else
        //{
        PhotonNetwork.automaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings(Version.ToString());
        //}

    }

    public void FindRooms()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public void Create()
    {
        PhotonNetwork.automaticallySyncScene = true;
        PhotonNetwork.CreateRoom(null, new RoomOptions() { maxPlayers = 16 }, null);
        PhotonNetwork.LoadLevel(loadSceneName);

    }

    void Update()
    {
        if (showConnectionState)
        {
            if (PhotonNetwork.connectionStateDetailed.ToString() != prevConnectionState)
            {
                Debug.Log(PhotonNetwork.connectionStateDetailed);
                prevConnectionState = PhotonNetwork.connectionStateDetailed.ToString();
            }
        }

    }

    public virtual void OnConnectedToMaster()
    {
        if (PhotonNetwork.networkingPeer.AvailableRegions != null)
            Debug.LogWarning("List of available regions counts " + PhotonNetwork.networkingPeer.AvailableRegions.Count + ". First: " + PhotonNetwork.networkingPeer.AvailableRegions[0] + " \t Current Region: " + PhotonNetwork.networkingPeer.CloudRegion);
        Debug.Log("OnConnectedToMaster() was called by PUN. Now this client is connected and could join a room. Calling: PhotonNetwork.JoinRandomRoom();");
        //PhotonNetwork.JoinRandomRoom();
    }

    public virtual void OnPhotonRandomJoinFailed()
    {
        UIManager.thisM.currentUI.UpdateUI();
    }

    // the following methods are implemented to give you some context. re-implement them as needed.

    public virtual void OnFailedToConnectToPhoton(DisconnectCause cause)
    {
        Debug.LogError("Cause: " + cause);
    }

    public void OnJoinedRoom()
    {
        showConnectionState = false;
        GameManager.thisM.OnConnected();
    }



    public void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby(). Use a GUI to show existing rooms available in PhotonNetwork.GetRoomList().");
    }

}
