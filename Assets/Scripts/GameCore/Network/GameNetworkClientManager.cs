using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class GameNetworkClientManager : NetworkManager
{
    /**
     public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
     {
         //var player = (GameObject)GameObject.Instantiate(playerPrefab, playerSpawnPos, Quaternion.identity);
         //NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
         Debug.Log(string.Format("OnServerAddPlayer playerControllerId:{0}", playerControllerId));
         base.OnServerAddPlayer(conn, playerControllerId);
     }

     public override void OnServerConnect(NetworkConnection conn)
     {
         base.OnServerConnect(conn);
         Debug.Log("OnServerConnect");
     }
     public override void OnServerConnect(NetworkConnection conn)
    {
        Debug.Log("################################OnServerConnect");
        base.OnServerConnect(conn);
        Debug.Log("################################OnServerConnect");
    }

         public override void OnStopClient()
    {
        base.OnStopClient();
        Debug.Log("################################OnStopClient");
    }
 
    public override void OnStopHost()
    {
        base.OnStopHost();
        Debug.Log("################################OnStopHost");
    }
    public override void OnStartHost()
    {
        base.OnStartHost();
        Debug.Log("################################OnStartHost");
    }

     **/

	void Start()
	{
		Time.fixedDeltaTime = 1.0f / 24;
	}

    public override void OnStartServer()
    {
        base.OnStartServer();        
        //Debug.Log("################################OnStartServer");
    }


    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader)
    {
        uint playerId = extraMessageReader.ReadPackedUInt32();
        Vector3 position = extraMessageReader.ReadVector3();
        string  path = extraMessageReader.ReadString();
        GameObject player = Resources.Load<GameObject>(path);
        var go = (GameObject)Instantiate(player, position, Quaternion.identity);
        NetworkServer.AddPlayerForConnection(conn, go, playerControllerId);
    }



    public override void OnStartClient(NetworkClient client)
    {
     
        base.OnStartClient(client);
        Debug.Log("OnStartClient");
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        Debug.Log("############################################OnClientConnect");
        base.OnClientConnect(conn);
        PlayerMessage pmes = new PlayerMessage();
        pmes.path = "Avatars/linlong01/linlong01";
        ClientScene.RegisterPrefab(Resources.Load<GameObject>(pmes.path));
        ClientScene.AddPlayer(conn,0, pmes);

        Debug.Log("############################################OnClientConnect");

    }

    public override void OnClientDisconnect(NetworkConnection conn)
    {
        base.OnClientDisconnect(conn);
        Debug.Log("OnClientDisconnect");
    }

    public override void OnClientError(NetworkConnection conn, int errorCode)
    {
        base.OnClientError(conn,errorCode);
        Debug.Log("OnClientError");
    }





}
