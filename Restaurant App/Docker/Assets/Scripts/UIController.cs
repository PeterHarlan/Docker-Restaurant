using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour {

    //Holds each of the items on the menu
    public List<Food> foodItems = new List<Food>();
    //Holds the qtn GUI for each of the food element
    public List<TextMeshProUGUI> qtnList = new List<TextMeshProUGUI>();
    //Holds the calculated cost GUI for each of the food element
    public List<TextMeshProUGUI> itemCalculatedCostList = new List<TextMeshProUGUI>();

    //Holds slider object that allows the user to enter a tip percent
    public Slider tipSlider;
    public TextMeshProUGUI tipPercentGUI;

    public TextMeshProUGUI tipAmountGUI;
    public TextMeshProUGUI calculatorTipAmountGUI;
    //Holds the calculated tip amount
    private double tipAmount;

    public TextMeshProUGUI billAmountGUI;
    //Holds the calculated bill amount
    private double billAmount;

    public TextMeshProUGUI taxAmountGUI;
    //Holds the calculated tax amount
    private double taxAmount;

    public TextMeshProUGUI totalAmountGUI;
    private double totalAmount;

    public TextMeshProUGUI peopleCountGUI;
    public TextMeshProUGUI costPerPersonGUI;
    //Total number of individuals splitting the check
    private int peopleCount;

    // Use this for initialization, called on load
    void Awake () {

        peopleCount = 1;
        //for (int i= 0; i < foodItems.Count; i++)
        //{
        //    //Reset the food values onload
        //    foodItems[i].ResetValues();
        //}
        ResetCalculation();
    }

    public void Start()
    {
        //Adds a listener to the main slider and invokes a method when the value changes.
        tipSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        GetTip();
        GetTotal();
    }

    //Add quantity to a meal
    public void AddQtn(int foodIndex)
    {
        foodItems[foodIndex].AddQtn();
        Amounts(foodIndex);
    }

    //Subtract a quantity to a meal
    public void SubQtn(int foodIndex)
    {
        foodItems[foodIndex].SubQtn();
        GetTip();
        Amounts(foodIndex);
    }

    //Increment people count
    public void AddPeople()
    {
        peopleCount++;
        UpdatePeopleCount();
        GetPerPersonPrice();
    }

    //Decrement people count
    public void SubPeople()
    {
        if (peopleCount >= 2)
        {
            peopleCount--;
            UpdatePeopleCount();
            GetPerPersonPrice();
        }
    }

    //Resets everything
    public void ResetCalculation()
    {
        //Iterate thorugh every object
        for (int i = 0; i < foodItems.Count; i++)
        {
            //Reset the object values
            foodItems[i].ResetValues();
            foodItems[i].Print();
            //Update the UI values
            itemCalculatedCostList[i].text = foodItems[i].GetCalculatedCost().ToString("C2");
            qtnList[i].text = foodItems[i].GetQtn().ToString();
        }
        //Resets the tip percent
        tipSlider.value = 0;
        tipPercentGUI.text = tipSlider.value.ToString() + "%";

        //Update tip amount 
        tipAmount = 0;
        tipAmountGUI.text = tipAmount.ToString("C2");
        calculatorTipAmountGUI.text = tipAmount.ToString("C2");

        //Update the people count
        peopleCount = 1;
        UpdatePeopleCount();
        //Reset Bill, Tax, Tip, Total, 
        GetBill();
        GetTax();
        GetTip();
        GetTotal();


    }

    //Update all of the calculated amounts
    private void Amounts(int foodIndex)
    { 
        //Update the food object values 
        foodItems[foodIndex].UpdateCalculatedCost();
        qtnList[foodIndex].text = foodItems[foodIndex].GetQtn().ToString();
        itemCalculatedCostList[foodIndex].text = foodItems[foodIndex].GetCalculatedCost().ToString("C2");
       
        //Update the calculated values 
        GetBill();
        GetTax();
        GetTip();
        GetTotal();
    }

    //Generates the Bill amount in the calculation section
    private void GetBill()
    {
        billAmount = 0;
        foreach (Food meal in foodItems) {
            billAmount += meal.GetCalculatedCost();
        }
        billAmountGUI.text = billAmount.ToString("C2");
    }

    private void GetTax()
    {
        taxAmount = billAmount * .06;
        taxAmount = Mathf.Round((float)taxAmount * 100f) / 100f;
        taxAmountGUI.text = taxAmount.ToString("C2");
    }

    //Update tip amount
    private void GetTip()
    {
        //Update tip percent
        tipPercentGUI.text = tipSlider.value.ToString() + "%";

        //Calculate tip amount
        tipAmount = tipSlider.value * billAmount * .01;
        tipAmount = Mathf.Round((float)tipAmount * 100f) / 100f;
        tipAmountGUI.text = tipAmount.ToString("C2");
        calculatorTipAmountGUI.text = tipAmount.ToString("C2");
    }

    //Calculate the total amount
    private void GetTotal()
    {
        totalAmount = billAmount + taxAmount + tipAmount;
        totalAmount = Mathf.Round((float)totalAmount * 100f) / 100f;
        totalAmountGUI.text = totalAmount.ToString("C2");
        GetPerPersonPrice();
    }

    //Calculates the price per person 
    private void GetPerPersonPrice()
    {
        costPerPersonGUI.text = (totalAmount / peopleCount).ToString("C2");
    }

    //Updates the people count gui
    private void UpdatePeopleCount()
    {
        peopleCountGUI.text = peopleCount.ToString();
    }
}
