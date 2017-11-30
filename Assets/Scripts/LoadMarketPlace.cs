using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//WILL NEED to auto generate each row with script in future

// Attached to every row in Item_Field_Horizontal Group(x) within...
// Canvas_MarketPlaceUI_wScript -> Right_Side
public class LoadMarketPlace : MonoBehaviour {

	public GameObject library;
	public Player player;
	public GameObject playerObj;
	public Item itemScript;

//LEFT SIDE Objects
	public Image itemPicture;
	public Text itemDescription;
	public Text balanceDisplayText;

//Initialize Item Rows
	public Transform verticalGroup; 
	public Transform itemFieldPrefab; 

	public void LoadMarketplace()
	{
		playerObj = GameObject.FindGameObjectWithTag ("Player");
		player = playerObj.GetComponent<Player>();
		library = GameObject.FindGameObjectWithTag ("Library");
		int itemListSize = library.GetComponent<ItemLibrary> ().itemArraySize;
		// print("itemArraySize: " + itemListSize);
		for (int i=0; i<itemListSize; i++) {
			Debug.Log("Destroy: " + i);
			Destroy(GameObject.Find("Row(Clone)"+i));
		}
		for(int i=0; i<itemListSize; i++)
		{
			Item item = library.GetComponent<ItemLibrary> ().getNextItem ("market_supplies");
			Transform field = Instantiate(itemFieldPrefab);
			Button incButton = field.GetChild(2).GetChild(1).GetComponent<Button>();
			Button decButton = field.GetChild(2).GetChild(0).GetComponent<Button>();
			Button buyButton = field.GetChild(4).GetComponent<Button>();
			field.transform.SetParent(verticalGroup.transform, false); //for loading items dynamically as particular child

			ItemScroll rowPtr = field.GetComponent<ItemScroll> ();	
			rowPtr.itemScript = item;
			rowPtr.itemPrice.text = item.price.ToString () + " €";
			rowPtr.itemName.text = item.name;
			rowPtr.itemAmount.text = "1";
			rowPtr.transform.parent = verticalGroup;
			rowPtr.gameObject.SetActive(true);
			rowPtr.transform.localScale = itemFieldPrefab.transform.localScale;
			rowPtr.transform.name = "Row(Clone)" + i;
			rowPtr.itemTotal.text = item.price.ToString () + " €";
			if (player.credits - item.price < 0) {
				//Debug.Log ("Not Enough Money");
				incButton.interactable = false;
				decButton.interactable = false;
				buyButton.interactable = false;
					
			}
			else if (player.playerShip.maxSupplies == 0) {
				//Debug.Log ("No Ship");
				incButton.interactable = false;
				decButton.interactable = false;
				buyButton.interactable = false;

			}
			else if (player.playerShip.supplies >= player.playerShip.maxSupplies) {
				//Debug.Log ("Not Enough Room");
				incButton.interactable = false;
				decButton.interactable = false;
				buyButton.interactable = false;

			} else {
				//Debug.Log("Looks Good Buy Away...");
				incButton.interactable = true;
				decButton.interactable = true;
				buyButton.interactable = true;
			}
		}
	}

} //end of script
