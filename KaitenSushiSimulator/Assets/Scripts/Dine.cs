using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dine : MonoBehaviour
{
    [SerializeField] private GameObject camera, player, sushiTamago, sushiSalmon, sushiTuna;

    private Vector3 leavePointPos;
    private GameObject leavePoint, spawnPoint, spawn;

    public bool seat(GameObject targetBoard)
    {       
        //orginPos = camera.transform.position;

        camera.transform.SetParent(targetBoard.transform.GetChild(10).gameObject.transform);
        spawnPoint = targetBoard.transform.GetChild(9).gameObject;
        leavePoint = targetBoard.transform.GetChild(11).gameObject;
        leavePoint.SetActive(true);
        leavePointPos = leavePoint.transform.position;

        //camera.transform.localPosition = new Vector3(0f, 0.3f, 0f);
        return true;
    }

    public bool leave()
    {
        player.transform.position = leavePointPos;

        camera.transform.SetParent(player.transform);

        if (spawn != null)
        {
            Destroy(spawn);
        }

        leavePoint.SetActive(false);
        //camera.transform.localPosition = orginPos;
        return false;
    }

    public void grab(GameObject targetBoard)
    {
        string name = targetBoard.name.Split()[0];

        //Debug.Log(name);

        if(spawn != null)
        {
            Destroy(spawn);
        }

        switch (name)
        {
            case "SushiTamago":
                spawn = Instantiate(sushiTamago, new Vector3(0,0,0), Quaternion.identity);
                spawn.transform.SetParent(spawnPoint.transform);
                spawn.transform.localPosition = spawnPoint.transform.localPosition;
                break;
            case "SushiSalmon":
                spawn = Instantiate(sushiSalmon, new Vector3(0, 0, 0), Quaternion.identity);
                spawn.transform.SetParent(spawnPoint.transform);
                spawn.transform.localPosition = spawnPoint.transform.localPosition;
                break;
            case "SushiTuna":
                spawn = Instantiate(sushiTuna, new Vector3(0, 0, 0), Quaternion.identity);
                spawn.transform.SetParent(spawnPoint.transform);
                spawn.transform.localPosition = spawnPoint.transform.localPosition;
                break;
            default:
                break;
        }
        
    }

}
