using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSite : MonoBehaviour
{
    [SerializeField] private int siteToLoad = 0;

    public int GetSiteToLoad()
    {
        return siteToLoad;
    }
}
