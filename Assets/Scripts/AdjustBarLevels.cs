using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class AdjustBarLevels : MonoBehaviour
{
  private int shipHPConst;
  private int fuelConst;
  private int supplyConst;
  private int crewConst;

  public int shipHP = 1000;
  public int fuelAmt = 2000;
  public int supplyAmt = 500;
  public int crewAmt = 20;

  public Text hpDisplayText;
  public Text fuelDisplayText;
  public Text supplyDisplayText;
  public Text crewDisplayText;

  public Image shipHPBar;
  public Image fuelBar;
  public Image supplyBar;
  public Image crewBar;


  void Start() {
    shipHPConst = shipHP;
    fuelConst = fuelAmt;
    supplyConst = supplyAmt;
    crewConst = crewAmt;

    hpDisplayText.text = "Ship HP: " + shipHP.ToString ();
    fuelDisplayText.text = "Fuel: " + fuelAmt.ToString ();
    supplyDisplayText.text = "Supplies: " + supplyAmt.ToString ();
    crewDisplayText.text = "Crew: " + crewAmt.ToString ();
  }


  public void depleteHP(int damageCount)
  {
  	shipHP -= damageCount;

  	if (shipHPBar != null) {
  		shipHPBar.fillAmount = (float)shipHP / (float)shipHPConst;
  		hpDisplayText.text = "Ship HP: " + shipHP.ToString ();
  	}
  }


  public void depleteFuel(int reduceAmt)
  {
    fuelAmt -= reduceAmt;

    if (fuelBar != null) {
      fuelBar.fillAmount = (float)fuelAmt / (float)fuelConst;
      fuelDisplayText.text = "Fuel: " + fuelAmt.ToString ();
    }
  }


  public void depleteSupply(int reduceAmt)
  {
    supplyAmt -= reduceAmt;

    if (supplyBar != null) {
  		supplyBar.fillAmount = (float)supplyAmt / (float)supplyConst;
      supplyDisplayText.text = "Supplies: " + supplyAmt.ToString ();
    }
  }


  public void depleteCrew(int reduceAmt)
  {
    crewConst -= reduceAmt;

    if (crewBar != null) {
      crewBar.fillAmount = (float)crewConst / (float)crewConst;
  		crewDisplayText.text = "Crew: " + crewConst.ToString ();
    }
  }    


  
}

