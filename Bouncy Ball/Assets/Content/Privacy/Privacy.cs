using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.WebRequestMethods;

public class Privacy : MonoBehaviour
{
    public void OpenLink()
    {
        string link = "https://www.alexgamedev.de/";
        Application.OpenURL(link);
    }
}
