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

	public Item itemScript;

//LEFT SIDE Objects
	public Image itemPicture;
	public Text itemDescription;
	public Text balanceDisplayText;

//Initialize Item Rows
	public GameObject verticalGroup; 
	public GameObject itemFieldPrefab; 


// public void LoadScrollEntries()
	public void Start()
	{	
		library = GameObject.FindGameObjectWithTag ("Library");
		int itemListSize = library.GetComponent<ItemLibrary> ().itemArraySize;
		// print("itemArraySize: " + itemListSize);
		
		for(int i=0; i<itemListSize; i++)
		{
			Item item = library.GetComponent<ItemLibrary> ().getNextItem ("market_supplies");

			GameObject field = Instantiate(itemFieldPrefab);
			field.transform.SetParent(verticalGroup.transform, false); //for loading items dynamically as particular child
			
			ItemScroll rowPtr = field.GetComponent<ItemScroll> ();	
			rowPtr.itemScript = item;
			rowPtr.itemPrice.text = item.price.ToString () + " £";
			rowPtr.itemName.text = item.name;
			rowPtr.itemAmount.text = "1";
			rowPtr.itemTotal.text = item.price.ToString () + " £";
		}
	}
} //end of script
