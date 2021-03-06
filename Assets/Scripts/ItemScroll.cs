﻿// Attached to every row in Item_Field_Horizontal Group(x) within...
// Canvas_MarketPlaceUI_wScript -> Right_Side

//script updates Supply bar and amount too

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ItemScroll : MonoBehaviour {

public Player player;
//public Ship playerShip;
public Item itemScript;
public GameObject playerObj;

public Text itemName; //used to initialize values through LoadMarketPlace.cs
public Text itemPrice; //used to initialize values through LoadMarketPlace.cs
public Text itemAmount;
public Text itemTotal;


private int intAmount = 1;
private int intTotal = 1;
private int incFlag = 0;

public Button decButton;
public Button incButton;
public Button buyButton;

// public GameObject scrollRectwVerticalGroups;
public GameObject areYouSureItemPrefab; 

public void destroyYouSureWindow()
{
	buyButton.interactable = true;
	Destroy(gameObject);
}

public void rowClick()
{
	Item item = itemScript.GetComponent<Item> ();
	GameObject picUI = GameObject.FindGameObjectWithTag("itemPicture_Image");
	GameObject textUI = GameObject.FindGameObjectWithTag("itemDescription_Text");
	Image iPicture = picUI.GetComponent<Image> ();
	Text itemDescription = textUI.GetComponent<Text> ();
	iPicture.sprite = item.itemPicture;
	itemDescription.text = item.description.ToString () + item.supplyBonus.ToString ();
}


public void incAmount()
{
	playerObj = GameObject.FindGameObjectWithTag ("Player");
	player = playerObj.GetComponent<Player>();
	Item item = itemScript.GetComponent<Item> ();
	GameObject picUI = GameObject.FindGameObjectWithTag("itemPicture_Image");
	GameObject textUI = GameObject.FindGameObjectWithTag("itemDescription_Text");
	Image iPicture = picUI.GetComponent<Image> ();
	Text itemDescription = textUI.GetComponent<Text> ();
	iPicture.sprite = item.itemPicture;
	itemDescription.text = item.description.ToString () + item.supplyBonus.ToString ();


	if (intAmount + player.playerShip.supplies == player.playerShip.maxSupplies) {
		incButton.interactable = false;
	}
	else if (intAmount + player.playerShip.supplies > player.playerShip.maxSupplies) {
		incButton.interactable = false;
		buyButton.interactable = false;
	}
	else {
		intAmount++;
		buyButton.interactable = true;
		incButton.interactable = true;
	}
	if(player.credits - item.price*intAmount >= 0)
	{
		intTotal = item.price*intAmount;
		itemTotal.text = intTotal.ToString () + " €";		
		itemAmount.text = intAmount.ToString ();

	}
	else if(incFlag > 0)
	{
		itemAmount.text = (incFlag).ToString ();
		intAmount--;
		itemTotal.text = "Not Enough";					
	}		
	else  
	{
		itemAmount.text = (intAmount).ToString ();
		incFlag = intAmount;
		itemTotal.text = "Not Enough";			
	}

}


public void decAmount()
{
	playerObj = GameObject.FindGameObjectWithTag ("Player");
	player = playerObj.GetComponent<Player>();
	Item item = itemScript.GetComponent<Item> ();
	GameObject picUI = GameObject.FindGameObjectWithTag("itemPicture_Image");
	GameObject textUI = GameObject.FindGameObjectWithTag("itemDescription_Text");
	Image iPicture = picUI.GetComponent<Image> ();
	Text itemDescription = textUI.GetComponent<Text> ();
	iPicture.sprite = item.itemPicture;
	itemDescription.text = item.description.ToString () + item.supplyBonus.ToString ();



	if(intAmount > 1)
	{
		intAmount--;
		if (intAmount + player.playerShip.supplies == player.playerShip.maxSupplies) {
			incButton.interactable = false;
		}
		else if (intAmount + player.playerShip.supplies > player.playerShip.maxSupplies) {
			incButton.interactable = false;
			buyButton.interactable = false;
		}
		else {
			buyButton.interactable = true;
			incButton.interactable = true;
		}
		itemAmount.text = intAmount.ToString ();
		intTotal = item.price*intAmount;
		itemTotal.text = intTotal.ToString () + " €";		
		incFlag = 0;
	}

	if(player.credits - item.price*intAmount >= 0)
		itemTotal.text = intTotal.ToString () + " €";		
	else  
	itemTotal.text = "Not Enough";			

}


//FOR buyButton
public void buyItemPart1()
{
	Item item = itemScript.GetComponent<Item> ();
	GameObject picUI = GameObject.FindGameObjectWithTag("itemPicture_Image");
	GameObject textUI = GameObject.FindGameObjectWithTag("itemDescription_Text");
	Image iPicture = picUI.GetComponent<Image> ();
	Text itemDescription = textUI.GetComponent<Text> ();
	iPicture.sprite = item.itemPicture;
	itemDescription.text = item.description.ToString () + item.supplyBonus.ToString ();


	if(player.credits - item.price*intAmount >= 0)
	{
		buyButton.interactable = false;

		GameObject foo = GameObject.FindGameObjectWithTag("ScrollRectwVerticalGroups");
		GameObject field = Instantiate(areYouSureItemPrefab);
		field.transform.SetParent(foo.transform, false); //for loading items dynamically as particular child
		field.SetActive(true);

		field.GetComponent<ItemScroll>().itemScript = item;
		field.GetComponent<ItemScroll>().itemScript.amountPurchasing = intAmount;
		field.GetComponent<ItemScroll>().buyButton = buyButton;

		//intAmount = 1;
	}
	else  
	itemTotal.text = "Not Enough!";	

}


//FOR AREyouSureScreen
public void buyItemPart2()
{
	Item item = itemScript.GetComponent<Item> ();
	playerObj = GameObject.FindGameObjectWithTag("Player");
	player = playerObj.GetComponent<Player>();

	if(player.credits - item.price*item.amountPurchasing >= 0)
	{
		player.credits -= item.price*item.amountPurchasing;


		GameObject supplyTextDisplay = GameObject.FindGameObjectWithTag ("SupplyAmountText_X");
		GameObject supplyBARDisplay = GameObject.FindGameObjectWithTag ("SupplyAmountBAR_X");

		player.playerShip.supplies += item.supplyBonus*item.amountPurchasing;

		if(player.playerShip.supplies > player.playerShip.maxSupplies)
			player.playerShip.supplies = player.playerShip.maxSupplies;

		// supplyTextDisplay.GetComponent<Text>().text = playerShip.supplies.ToString () + '/' + playerShip.maxSupplies.ToString();
		// supplyBARDisplay.GetComponent<Image>().fillAmount = (float)playerShip.supplies / playerShip.maxSupplies;

		GameObject getParentScript = GameObject.FindGameObjectWithTag("ScrollRectwVerticalGroups");
		getParentScript.GetComponent<AdjustBarAndStatLevels>().balanceDisplayText.text = "Balance: " + player.credits.ToString () + " €";		


		getParentScript.GetComponent<AdjustBarAndStatLevels>().supplyDisplayText.text = player.playerShip.supplies.ToString () + '/' + player.playerShip.maxSupplies.ToString();
		getParentScript.GetComponent<AdjustBarAndStatLevels> ().supplyBar.fillAmount = (float)player.playerShip.supplies / player.playerShip.maxSupplies;

		// supplyTextDisplay.GetComponent<Text>().text = playerShip.supplies.ToString () + '/' + playerShip.maxSupplies.ToString();
		// supplyBARDisplay.GetComponent<Image>().fillAmount = (float)playerShip.supplies / playerShip.maxSupplies;
		//intAmount = 1;
	}
	else  
	itemTotal.text = "Not Enough!!!";
}


} //end of script
