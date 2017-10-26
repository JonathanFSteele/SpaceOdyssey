using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogCrewPopUp : MonoBehaviour
{

    public void Log(GameObject Panel)
    {
        Panel.SetActive(!Panel.activeSelf);

    }
}
