using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;

    public float maxX;
    public float maxY;
    public float minX;
    public float minY;
    public float Z;

    public void Start()
    {
        Vector3 randompostion = new Vector3(Random.Range(maxX, minX),Z, Random.Range(maxY, minY));
        PhotonNetwork.Instantiate(playerPrefab.name, randompostion, Quaternion.identity);
    }
}
