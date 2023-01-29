using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiRollerCoaster : MonoBehaviour
{
    [SerializeField] private GameObject camera, player;
    //private Vector3 orginPos;

    public bool board(GameObject targetBoard)
    {
        //orginPos = camera.transform.position;
        camera.transform.SetParent(targetBoard.transform.GetChild(5).gameObject.transform);
        //camera.transform.localPosition = new Vector3(0f, 0.3f, 0f);
        return true;
    }

    public bool unboard()
    {
        camera.transform.SetParent(player.transform);
        //camera.transform.localPosition = orginPos;
        return false;
    }
}
