using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Random = UnityEngine.Random;

public class SpawnScript : MonoBehaviour
{
    public GameObject playerPrefab;
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

    private void Start()
    {
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        PhotonNetwork.Instantiate(playerPrefab.name,randomPosition,Quaternion.identity);
    }
}
