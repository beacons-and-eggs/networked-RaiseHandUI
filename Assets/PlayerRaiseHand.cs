using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerRaiseHand : NetworkBehaviour {

	// public GameObject RaiseHandUIPrefab;

	void Start () {
		// n/a
	}
		
	void Update () {
		// Constantly listen for a mouse click
		if (Input.GetMouseButtonDown (0)) { // Upon a LEFT mouse click

			if (!Network.isServer) {	// if clicked on a client, send a command to the server
				CmdDisplay ();
			}
			else {						// if clicked on the server, send RPC to all clients
				RpcDisplay ();
			}

		}
	}

	// Send notification from server to all clients
	[ClientRpc]
	void RpcDisplay(){
		print("RpcDisplay() sent across network.");

		Notification.instance.Display ("Question", "From Alie", 3f);

		print("Completed RpcDisplay function.");
	}

	// Send a command from client to the server
	[Command]
	void CmdDisplay() {
		print("CmdDisplay() sent across network.");

		Notification.instance.Display ("Question", "From Alie", 3f); // doesn't seem to do anything

		RpcDisplay(); // Have the server send a Rpc

		/* Other idea on how to implement (incomplete)
		// create RaiseHandUI object from prefab
		var raiseHandUI = (GameObject)Instantiate(RaiseHandUIPrefab);

		// spawn RaiseHandUI on clients
		NetworkServer.Spawn(raiseHandUI);

		// Broadcast the display command to all clients on the network
		// Notification.instance.Display ("Question", "From Alie", 3f);

		var notificationScript = raiseHandUI.GetComponent("Notification");
		notificationScript.Display("Question", "From Alie", 3f);

		// destroy object after 3 seconds
		Destroy(raiseHandUI, 3.0f);
		*/

		print("Completed CmdDisplay function.");
	}
}