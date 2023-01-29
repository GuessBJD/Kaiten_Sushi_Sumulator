using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cook : MonoBehaviour
{
    [SerializeField] private GameObject camera, player, sushiTamago, sushiSalmon, sushiTuna;

    private Vector3 leavePointPos;
    private GameObject leavePoint, spawnPoint, spawn;

    public bool cook(GameObject targetBoard)
    {
        //orginPos = camera.transform.position;

        camera.transform.SetParent(targetBoard.transform.GetChild(2).gameObject.transform);
        spawnPoint = targetBoard.transform.GetChild(1).gameObject;
        leavePoint = targetBoard.transform.GetChild(3).gameObject;
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

        if (spawn != null)
        {
            Destroy(spawn);
        }

        switch (name)
        {
            case "TamagoYakiPlate":
                spawn = Instantiate(sushiTamago, new Vector3(0, 0, 0), Quaternion.identity);
                spawn.transform.SetParent(spawnPoint.transform);
                spawn.transform.localPosition = spawnPoint.transform.localPosition;
                break;
            case "SalmonPlate":
                spawn = Instantiate(sushiSalmon, new Vector3(0, 0, 0), Quaternion.identity);
                spawn.transform.SetParent(spawnPoint.transform);
                spawn.transform.localPosition = spawnPoint.transform.localPosition;
                break;
            case "TunaPlate":
                spawn = Instantiate(sushiTuna, new Vector3(0, 0, 0), Quaternion.identity);
                spawn.transform.SetParent(spawnPoint.transform);
                spawn.transform.localPosition = spawnPoint.transform.localPosition;
                break;
            default:
                break;
        }

    }
}
