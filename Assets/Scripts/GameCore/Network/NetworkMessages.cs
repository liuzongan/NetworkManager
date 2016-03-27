using UnityEngine;
using UnityEngine.Networking;

public class MsgTypeCore
{
    public static short Player = MsgType.Highest + 1;
};

public class PlayerMessage : MessageBase
{
    public uint playerId;
    public Vector3 position;
    public string path;
    

    // This method would be generated
    public override void Deserialize(NetworkReader reader)
    {
        playerId = reader.ReadPackedUInt32();
        position = reader.ReadVector3();
        path = reader.ReadString();

    }

    // This method would be generated
    public override void Serialize(NetworkWriter writer)
    {
        writer.WritePackedUInt32(playerId);
        writer.Write(position); 
        writer.Write(path);
    }
}

