using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class HideOnLoad : MonoBehaviour {

  public GameObject foo1;
  public GameObject foo2;

	void Start () {
    foo1.SetActive(false);
    foo2.SetActive(false);
	}
 
}
