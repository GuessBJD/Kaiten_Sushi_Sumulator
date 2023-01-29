using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VRGaze : MonoBehaviour
{
    public Image imgGaze;

    public float totalGazeTime = 0.5f;
    
    bool gvrStatus = false;
    bool interactStatus = false;
    [SerializeField] bool moving = false;
    [SerializeField] bool riding = false;
    [SerializeField] bool sitting = false;
    [SerializeField] bool cooking = false;
    float gvrTimer = 0f;

    [SerializeField] private GameObject moveTile, rePoint;

    public int distanceOfRay = 10; 

    //[SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit _hit;

        if (gvrStatus == true)
        {
            if (moving == true)
            {
                GetComponent<PlayerWalk>().stop();
                //Debug.Log("paused");
            }

            gvrTimer += Time.deltaTime;
            imgGaze.fillAmount = gvrTimer / totalGazeTime;
        }
        else
        {
            if (moving == true)
            {
                GetComponent<PlayerWalk>().move();
                //Debug.Log("resumed");
            }
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if(Physics.Raycast(ray, out _hit, distanceOfRay))
        {
            if (imgGaze.fillAmount == 1 && interactStatus == false && riding == false && sitting == false && cooking == false && _hit.collider.transform.CompareTag("MoveStopTile")) 
            {
                moving = GetComponent<PlayerWalk>().walkHandler();
                
                interactStatus = true;
            }

            if (imgGaze.fillAmount == 1 && interactStatus == false && riding == false && sitting == false && cooking == false && _hit.collider.transform.CompareTag("Sushi"))
            {
                if (moving == true)
                    moving = GetComponent<PlayerWalk>().walkHandler();
                
                riding = GetComponent<SushiRollerCoaster>().board(_hit.transform.gameObject);

                interactStatus = true;

                if (interactStatus == true)
                {
                    moveTile.SetActive(false);
                    rePoint.SetActive(true);
                }   
            }

            if (imgGaze.fillAmount == 1 && interactStatus == false && riding == true && _hit.collider.transform.CompareTag("Return"))
            {
                riding = GetComponent<SushiRollerCoaster>().unboard();

                interactStatus = true;

                if (interactStatus == true)
                {
                    moveTile.SetActive(true);
                    rePoint.SetActive(false);
                }
            }

            if (imgGaze.fillAmount == 1 && interactStatus == false && riding == false && sitting == false && cooking == false && _hit.collider.transform.CompareTag("Chair"))
            {
                if (moving == true)
                    moving = GetComponent<PlayerWalk>().walkHandler();

                sitting = GetComponent<Dine>().seat(_hit.transform.gameObject);

                interactStatus = true;

                if (interactStatus == true)
                {
                    moveTile.SetActive(false);
                }
            }

            if (imgGaze.fillAmount == 1 && interactStatus == false && (sitting == true || cooking == true) && _hit.collider.transform.CompareTag("Leave"))
            {
                if (sitting == true)
                    sitting = GetComponent<Dine>().leave();

                if(cooking == true)
                    cooking = GetComponent<Cook>().leave();

                interactStatus = true;

                if (interactStatus == true)
                {
                    moveTile.SetActive(true);
                }
            }

            if (imgGaze.fillAmount == 1 && interactStatus == false && sitting == true & _hit.collider.transform.CompareTag("Sushi"))
            {
                interactStatus = true;
                GetComponent<Dine>().grab(_hit.transform.gameObject);
            }

            if (imgGaze.fillAmount == 1 && interactStatus == false && riding == false && sitting == false && cooking == false && _hit.collider.transform.CompareTag("Cook"))
            {
                if (moving == true)
                    moving = GetComponent<PlayerWalk>().walkHandler();

                cooking = GetComponent<Cook>().cook(_hit.transform.gameObject);

                interactStatus = true;

                if (interactStatus == true)
                {
                    moveTile.SetActive(false);
                }
            }

            /*
            if (imgGaze.fillAmount == 1 && interactStatus == false && cooking == true && _hit.collider.transform.CompareTag("Leave"))
            { 
                cooking = GetComponent<Cook>().leave();

                interactStatus = true;

                if (interactStatus == true)
                {
                    moveTile.SetActive(true);
                }
            }
            */

            if (imgGaze.fillAmount == 1 && interactStatus == false && cooking == true && (_hit.collider.transform.CompareTag("Ingredient") || _hit.collider.transform.CompareTag("Sushi")))
            {
                interactStatus = true;
                GetComponent<Cook>().grab(_hit.transform.gameObject);
            }

            if(imgGaze.fillAmount == 1)
            {
                GVROff();
            }
        }

    }

    public void GVROn()
    {
        gvrStatus = true;
        interactStatus = false;
    }


    public void GVROff()
    {
        gvrStatus = false;
        gvrTimer = 0f;
        imgGaze.fillAmount = 0;
    }

}
