using Photon.Pun;
using UnityEngine;

public class PhotonTest : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("PHOTON BASARIYLA BAGLANDI!");
    }
}
