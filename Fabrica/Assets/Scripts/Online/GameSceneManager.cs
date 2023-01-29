using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;



public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager instance;


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
            if (GameManager.instance.SelectedSkinPlayer != null)
            {
                int randomPoint = Random.Range(-4, 5);

                // Instanciamos nuestro jugador en una posición random (limitada) del mapa
                PhotonNetwork.Instantiate(GameManager.instance.SelectedSkinPlayer.name, new Vector3(randomPoint, 2, randomPoint),
                    Quaternion.identity);

            }
        }
    }

    // als tres voids seguents hi havia override pero hem dona error, esta tret per poder tancar unity

    public void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.NickName + " se ha conectado a " + PhotonNetwork.CurrentRoom.Name);
    }

    public void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " se ha conectado a " + PhotonNetwork.CurrentRoom.Name +
                  " -- Numero players: " + PhotonNetwork.CurrentRoom.PlayerCount);
    }


    public void OnLeftRoom()
    {
        SceneManager.LoadScene("GameLauncherScene");
    }

    // aquest ultim no necessita un override
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }



}
