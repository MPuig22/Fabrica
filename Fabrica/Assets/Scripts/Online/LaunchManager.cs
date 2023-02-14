using System.Collections;
using System;
using System.Collections.Generic;
using EasyUI.Toast;
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
    [SerializeField] private GameObject lobbyRoomPanel;

    [SerializeField] private List<GameObject> panel_list = new List<GameObject>();

    [Header("--- Objects Panel Enter Game ---"), Space(10)]
    [SerializeField] private TMP_InputField playerName_inputfield;

    [Header("--- Objects Panel Loby ---"), Space(10)]
    [SerializeField] private TextMeshProUGUI usuarios_conectados_info_txt;
    [SerializeField] private GameObject content_ListaUsuarios_conectados;
    [SerializeField] private Item_info_UsuarioConectado _item_Info_UsuarioConectado;
    
    [SerializeField] private GameObject startGame_btn;

    // private variables
   





    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start()
    {
        OcultarTodosLosPaneles();
        enterGamePanel.SetActive(true);
        
    } 
    
   [PunRPC]
   public void Actualizar_Lista_Usuarios()
    {
        LimpiarListaUsuarios();

        // Recorremos toda la lista de usuarios capturados del JSON y creamos un boton el la UI por cada uno.
        foreach (var player in PhotonNetwork.PlayerList)
        {
            Item_info_UsuarioConectado itemListaUsuariosConectados;
            itemListaUsuariosConectados = Instantiate(_item_Info_UsuarioConectado, content_ListaUsuarios_conectados.transform);
            itemListaUsuariosConectados.nickname_usuario = player.NickName;
            itemListaUsuariosConectados.name = player.NickName;
        }

        usuarios_conectados_info_txt.text = $"Usuarios conectados {PhotonNetwork.CurrentRoom.PlayerCount}/{PhotonNetwork.CurrentRoom.MaxPlayers}";

        if ((PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers) && PhotonNetwork.IsMasterClient)
        {
            startGame_btn.SetActive(true);
        }
        else
        {
            startGame_btn.SetActive(false);
        }
    }
    

    // Metodo que destruye los elementos del content del scroll view para luego poder cargar la info nueva
    private void LimpiarListaUsuarios()
    {
        foreach (Transform child in content_ListaUsuarios_conectados.transform)
        {
            Destroy(child.gameObject);
        }
    }
    
    

    public void ConnectToPhotonServer()
    {
      //verificamos que nuestro input field tenga texto
      if (string.IsNullOrEmpty(playerName_inputfield.text))
      {
          Toast.Show("Necesitas introducir datos");
      }
      else
      {
            // cambiamos el nickname de photonNetwork por el valor de texto del input field
            PhotonNetwork.NickName = playerName_inputfield.text;
            PhotonNetwork.ConnectUsingSettings();
            // Mostramos al usuario el siguiente panel despues de establecer la conexi�n
            OcultarTodosLosPaneles();
            connectionStatusPanel.SetActive(true);
      }
    }

    // Metodo que trata de conectar al usuario a una Room aleatoria, en caso de no existir llaremos al metodo override OnJoinRandomRoomFiled
    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    private void CreateAndJoinRoom()
    {
        string randomRoomName = "Room" + Random.Range(0, 10000);

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = 2;

        PhotonNetwork.CreateRoom(randomRoomName, roomOptions);
    }

    #region Override Photon

    public override void OnConnectedToMaster()
    {
        Debug.Log("Conectando a los servidores de Photon con el usuario " + PhotonNetwork.NickName + " " + PhotonNetwork.LocalPlayer.NickName);
        OcultarTodosLosPaneles();
        panel_createOrJoinRoom.SetActive(true);
    }

    public override void OnConnected()
    {
        Debug.Log("Conectando a Internet");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        CreateAndJoinRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.NickName + "se ha conectado a " + PhotonNetwork.CurrentRoom.Name);

        // Creamos la propiedad skinIndex para el player que se acaba de conectar para luego poder actualizarla
        // ya que indicara que skin ha escogido para ir al juego
        Hashtable player_skin_propertie = new Hashtable();
        player_skin_propertie.Add("skinIndex", 0);
        PhotonNetwork.LocalPlayer.CustomProperties = player_skin_propertie;

        lobbyRoomPanel.SetActive(true);
        photonView.RPC("Actualizar_Lista_Usuarios", RpcTarget.All);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " se ha conectado a " + PhotonNetwork.CurrentRoom.Name);
        Debug.Log("Numero de players: " + PhotonNetwork.CurrentRoom.PlayerCount);
    }

    #endregion

    

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        photonView.RPC("Actualizar_Lista_Usuarios", RpcTarget.All);
    }

    public void LeaveRoom()
    {
        OcultarTodosLosPaneles();
        PhotonNetwork.LeaveRoom();
        panel_createOrJoinRoom.SetActive(true);
    }

    [PunRPC]
    public void LoadGameScene_PunRPC()
    {
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.CurrentRoom.IsVisible = false;
        PhotonNetwork.LoadLevel("GameScene");
    }

    private void OcultarTodosLosPaneles()
    {
        foreach (GameObject panel in panel_list)
        {
            panel.SetActive(false);
        }
    }
}
