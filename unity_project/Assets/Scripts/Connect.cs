using UnityEngine;
using System.Collections;

public class Connect :  Photon.MonoBehaviour
{


		public bool offline = false;
		private byte Version = GameManager.Version;
		bool showConnectionState = true;
		string prevConnectionState;
	
		// Use this for initialization
		void Start ()
		{
				PhotonNetwork.autoJoinLobby = false;    // we join randomly. always. no need to join a lobby to get the list of rooms.
		
		
				if (offline) {
						PhotonNetwork.offlineMode = true;
						Debug.Log ("Offline Mode!");

				} else {
            PhotonNetwork.ConnectUsingSettings (Version.ToString ());
				}
		}

		void Update ()
		{
				if (showConnectionState) {
						if (PhotonNetwork.connectionStateDetailed.ToString () != prevConnectionState) {
								Debug.Log (PhotonNetwork.connectionStateDetailed);
								prevConnectionState = PhotonNetwork.connectionStateDetailed.ToString ();
						}
				}

		}
	
		public virtual void OnConnectedToMaster ()
		{
				if (PhotonNetwork.networkingPeer.AvailableRegions != null)
						Debug.LogWarning ("List of available regions counts " + PhotonNetwork.networkingPeer.AvailableRegions.Count + ". First: " + PhotonNetwork.networkingPeer.AvailableRegions [0] + " \t Current Region: " + PhotonNetwork.networkingPeer.CloudRegion);
				Debug.Log ("OnConnectedToMaster() was called by PUN. Now this client is connected and could join a room. Calling: PhotonNetwork.JoinRandomRoom();");
				PhotonNetwork.JoinRandomRoom ();
		}
	
		public virtual void OnPhotonRandomJoinFailed ()
		{
//				if (PhotonNetwork.GetRoomList ().Length < 1)
				PhotonNetwork.CreateRoom (null, new RoomOptions () { maxPlayers = 8 }, null);
				Debug.Log ("OnPhotonRandomJoinFailed() was called by PUN. No random room available, so we create one. Calling: PhotonNetwork.CreateRoom(null, new RoomOptions() {maxPlayers = 4}, null);");
		}
	
		// the following methods are implemented to give you some context. re-implement them as needed.
	
		public virtual void OnFailedToConnectToPhoton (DisconnectCause cause)
		{
				Debug.LogError ("Cause: " + cause);
		}
	
		public void OnJoinedRoom ()
		{
				showConnectionState = false;
				GameManager.thisM.currLevel.OnConnected ();
		}


	
		public void OnJoinedLobby ()
		{
				Debug.Log ("OnJoinedLobby(). Use a GUI to show existing rooms available in PhotonNetwork.GetRoomList().");
		}

}
