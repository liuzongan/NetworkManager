using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerController : NetworkBehaviour
{
    [Client]
    void Start()
    {
        Debug.Log("11111111111111111111111  "+playerControllerId);
        //ClientScene.AddPlayer(0);
    }

    [SyncVar]
    short mHorizontal;
    [SyncVar]
	short mVertical;
    
	[Command]
	void CmdMove(short h,short v)
	{
		mHorizontal = h;
		mVertical = v;
		//RpcDamage (h, v);
	}

	[ClientRpc]
	void RpcDamage(short h,short v)
	{
		mHorizontal = h;
		mVertical = v;
	}

	short lastH,hastV;
	void FixedUpdate()
	{
		if (isLocalPlayer)
		{
			short  h = (short)Input.GetAxisRaw("Horizontal") ;
			short  v = (short)Input.GetAxisRaw("Vertical") ;
			if (h != lastH || v != hastV) 
			{
				lastH = h;
				hastV = v;
				CmdMove (h, v);

			}
			return;
		}

	}


    void Update()
    {

        
        if(mHorizontal != 0 || mVertical != 0)
        {
            Vector3 dir = new Vector3(mHorizontal, 0, mVertical);
            Quaternion dd = Quaternion.LookRotation(dir) * Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0);
            transform.rotation = dd;
            transform.Translate(0,0,3 * Time.deltaTime);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Command function is called from the client, but invoked on the server
           // CmdFire();
        }
    }
}
