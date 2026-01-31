using UnityEngine;
using UnityEngine.Rendering.UI;

public class DollarBills : MonoBehaviour 
{
    public int amountPaid;
    public int numberofHundred;
    public int numberofFifty;
    public int numberofTwenty;
    public int numberofTen;
    public int numberofFive;
    public int numberofOne;
    public int HowMuchLeft = 0;
    void Start()
    {
        HowHundred();   //calls the first one

    }

    void HowHundred()
    {
        numberofHundred = amountPaid / 100;  //figure out how many hundred dollar bills there are

        HowMuchLeft = amountPaid - (numberofHundred * 100);  //figures out how much money is leftover
        
        if (HowMuchLeft > 0)
        {
            HowFifty();       //go calculate how much of the next bill there is
        }
        else { BillCount(); }      //give amount of each bill there is 
    }                           //repeat notes for each function
    void HowFifty()
    {
        numberofFifty = HowMuchLeft / 50;
        HowMuchLeft = HowMuchLeft - (numberofFifty * 50);

        if (HowMuchLeft > 0)
        {
            HowTwenty();
        }
        else { BillCount(); }
    }
    void HowTwenty()
    {
        numberofTwenty = HowMuchLeft / 20;
        HowMuchLeft = HowMuchLeft - (numberofTwenty * 20);
        if (HowMuchLeft > 0)
        {
            HowTen();
        }
        else { BillCount(); }
    }
    void HowTen()
    {
        numberofTen = HowMuchLeft / 10;
        HowMuchLeft = HowMuchLeft - (numberofTen * 10);

        if (HowMuchLeft > 0)
        {
            HowFive();
        }
        else { BillCount(); }
    }
    void HowFive()
    {

        numberofFive = HowMuchLeft / 5;
        HowMuchLeft = HowMuchLeft - (numberofFive * 5);
        if (HowMuchLeft > 0)
        {
            HowOne();
        }
        else { BillCount(); }
    }
    void HowOne()
    {
        numberofOne = HowMuchLeft / 1;
        HowMuchLeft = HowMuchLeft - (numberofFifty * 50);
        BillCount();
    }
    void BillCount()
    {
       Debug.Log("You have " +numberofHundred+ " $100 bills, " +numberofFifty+ " $50 bills, " +numberofTwenty+ " $20 bills, " +numberofTen+ " $10 bills, " +numberofFive+ " $5 bills, and " +numberofOne+ " $1 bills.");
        //output tells how much of each bill there is 
    }
    
    
}
