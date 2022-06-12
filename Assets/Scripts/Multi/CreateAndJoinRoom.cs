using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;


public class CreateAndJoinRoom : MonoBehaviourPunCallbacks
{
    public InputField createField;
    public InputField joinField;

    public GameObject message;
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createField.text);
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinField.text);
    }

    
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(3);
    }
    public void OnJoinedRoomFailed()
    {
        print(1);
        MessageText();
    }
    IEnumerator MessageText()
    {
        message.SetActive(true);
        yield return new WaitForSeconds(2);
        message.SetActive(false);

    }
}
