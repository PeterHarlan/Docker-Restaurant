using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FoodDisplay : MonoBehaviour {

    //Grabs the food object
    public Food food;

    //Grabs each of the UI elements
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public TextMeshProUGUI qtnItems;
    public TextMeshProUGUI price;
    public TextMeshProUGUI calculatedCost;
    public Image artwork;

    // Use this for initialization
    void Start () {
        //Sets the UI elements to the values found int he food object
        title.text = food.title;
        description.text = food.description;
        qtnItems.text = food.GetQtn().ToString();
        price.text = food.price.ToString();
        calculatedCost.text = food.calculatedCost.ToString();
        artwork.sprite = food.artwork;
	}
}
