using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LaunchManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject enterGamePanel;
    [SerializeField] private GameObject connectionStatusPanel;
  
    private void Start()
    {
        enterGamePanel.SetActive(true);
        connectionStatusPanel.SetActive(false);
    } 
    
    
    
    public void ConnectToPhotonServer()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
            enterGamePanel.SetActive(false);
            connectionStatusPanel.SetActive(true);
        }
    }
    
// Update is called once per frame
    void Update()
    {
    }
// Called when the client is connected to the Master Server and ready for matchmaking and other tasks.
    public override void OnConnectedToMaster()
    {
        Debug.Log("Conectando a los servidores de Photon con el usuario " + PhotonNetwork.NickName );
    }

// Called to signal that the raw connection got established but before the client can call operation on the server.
    public override void OnConnected()
    {
        Debug.Log("Conectando a Internet");
    }
}
