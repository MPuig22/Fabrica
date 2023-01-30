using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;



public class GameSceneManager : MonoBehaviourPunCallbacks
{
    public static GameSceneManager instance;

    [Space]
    [Header("Prefabs jugadores")]
    public GameObject prefabJugador_Master;
    public GameObject prefabJugador_Cliente;


    [Space]
    [Header("Posiciones jugadores")]
    public Transform posicionMaster;
    public Transform posicionOtroJugador;


    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        // Revisamos si estamos conectados un servidor de Photon
        if (PhotonNetwork.IsConnected)
        {
            // Revisamos que nuestra variable no sea null
            if (PhotonNetwork.IsMasterClient)
            {
            
                // Instanciamos nuestro jugador en una posición para el master
                PhotonNetwork.Instantiate(prefabJugador_Master.name, posicionMaster.position, Quaternion.identity);

            } else
            {
                // Instanciamos nuestro jugador en una posición para el master
                PhotonNetwork.Instantiate(prefabJugador_Cliente.name, posicionOtroJugador.position, Quaternion.identity);
            }
        }
    }

    // als tres voids seguents hi havia override pero hem dona error, esta tret per poder tancar unity




    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.NickName + " se ha conectado a " + PhotonNetwork.CurrentRoom.Name);
    }


    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " se ha conectado a " + PhotonNetwork.CurrentRoom.Name +
                  " -- Numero players: " + PhotonNetwork.CurrentRoom.PlayerCount);
    }


    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("GameLauncherScene");
    }

    // aquest ultim no necessita un override
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }



}
