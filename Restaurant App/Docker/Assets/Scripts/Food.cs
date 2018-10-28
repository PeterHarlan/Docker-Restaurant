using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Food", menuName = "Food")]
public class Food : ScriptableObject {

    public string title, description;
    private int qtnItems;
    public double price, calculatedCost;
    public Sprite artwork;

    public void Print()
    {
        Debug.Log("Title: " + title + "\nDescription: " + description +
            "\nqtnItems: " + qtnItems + "\nPrice: " + price + "\nCalculatedCost: " + calculatedCost);
    }

    public void UpdateTitle(string title)
    {
        this.title = title;
    }
    public void AddQtn()
    {
        this.qtnItems++;
    }

    public void SubQtn() {
        this.qtnItems--;
        if (this.qtnItems < 0)
        {
            this.qtnItems = 0;
        }
    }

    public int GetQtn()
    {
        return this.qtnItems;
    }

    public void ResetValues()
    {
        this.qtnItems = 0;
        this.calculatedCost = 0.00;
    }

    public void UpdateCalculatedCost()
    {
        this.calculatedCost = this.price * qtnItems;
    }

    public double GetCalculatedCost()
    {
        return this.calculatedCost;
    }


}
