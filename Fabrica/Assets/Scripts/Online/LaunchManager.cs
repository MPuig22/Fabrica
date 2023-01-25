using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.SceneManagement;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Random = UnityEngine.Random;

public class LaunchManager : MonoBehaviourPunCallbacks
{
    [Header("--- Panels ---"), Space(10)]
    [SerializeField] private GameObject enterGamePanel;
    [SerializeField] private GameObject connectionStatusPanel;
    [SerializeField] private GameObject panel_createOrJoinRoom;
    [SerializeField] private GameObject LobbyPanel;

    [SerializeField] private List<GameObject> panel_list = new List<GameObject>();

    [Header("--- Objects Panel Enter Game ---"), Space(10)]
    [SerializeField] private TMP_InputField playerName_inputfield;

    [Header("--- Objects Panel Loby ---"), Space(10)]
    [SerializeField] private TextMeshProUGUI usuarios_conectados_info_txt;
    [SerializeField] private GameObject content_ListaUsuarios_conectados;
 




    private void Start()
    {
        enterGamePanel.SetActive(true);
        connectionStatusPanel.SetActive(false);
        LobbyPanel.SetActive(false);
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
        connectionStatusPanel.SetActive(false);
        LobbyPanel.SetActive(true);
    }

// Called to signal that the raw connection got established but before the client can call operation on the server.
    public override void OnConnected()
    {
        Debug.Log("Conectando a Internet");
    }
}
