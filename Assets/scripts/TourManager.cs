using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class TourManager : MonoBehaviour
{
    // list of sites
    public GameObject[] objSites;
    //main menu
    public GameObject canvasMainMenu;
    //should the camera move
    public bool isCameraMove = false;


    // Start is called before the first frame update
    void Start()
    {
        ReturntoMenu();
    }

    // Update is called once per frame
    void Update()
    {
        if(isCameraMove)
        {

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ReturntoMenu();
            }

            if(Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if(Physics.Raycast(ray, out hit, 100.0f))
                {
                   if(hit.transform.gameObject.tag == "image")
                    {
                        hit.transform.gameObject.GetComponent<MediaImage>().ShowImage();
                    }
                    else if (hit.transform.gameObject.tag == "NextSite")
                    {
                        LoadSite(hit.transform.gameObject.GetComponent<NextSite>().GetSiteToLoad());
                    }
                }
            }


        }
    }

    public void LoadSite(int siteNumber)
    {
        //hide sites 
        for (int i = 0; i < objSites.Length; i++)
        {
            objSites[i].SetActive(false);
        }
        //show site
        objSites[siteNumber].SetActive(true);
        //hide menu
        canvasMainMenu.SetActive(true);
        //enable the camera
        isCameraMove = true;
        GetComponent<cameraController>().ResetCamera();
    }

    public void ReturntoMenu()
    {

        //show menu
        canvasMainMenu.SetActive(true);
        //hide sites
        for(int i = 0; i < objSites.Length; i++)
        {

            objSites[i].SetActive(false);

        }

        // disable the camera
        isCameraMove = false;

    }

    public void ReturnToSite()
    {
        isCameraMove = true;

    }
    public void OpenMedia()
    {
        isCameraMove = false;
    }
}


