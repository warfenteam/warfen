using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NetworkView))]
public class Menu : MonoBehaviour {
    public string IP;
    public int Port = 25000;

    void OnGUI() {
        if (Network.peerType == NetworkPeerType.Disconnected) {
            this.IP = GUI.TextField(new Rect(100, 75, 300, 25), this.IP);
            if (GUI.Button(new Rect(100, 100, 100, 25), "Start Server")) {
                Network.InitializeServer(10, Port, false);
            }
            if (GUI.Button(new Rect(100, 125, 100, 25), "Start Client")) {
                Network.Connect(IP, Port);
            }
        }
        else if (Network.peerType == NetworkPeerType.Server) {
            GUI.Label(new Rect(100, 100, 100, 25), "Client");
            GUI.Label(new Rect(100, 125, 100, 25), "Connections: " + Network.connections.Length);

            if (GUI.Button(new Rect(100, 150, 100, 25), "Logout")) {
                Network.Disconnect(250);
            }
        }
        else if (Network.peerType == NetworkPeerType.Client) {
            GUI.Label(new Rect(100, 100, 100, 25), "Client");
            if (GUI.Button(new Rect(100, 125, 100, 25), "Logout")) {
                Network.Disconnect(250);
            }
        }
    }
}