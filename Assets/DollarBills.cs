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
        HowHundred();

    }

    void HowHundred()
    {
        numberofHundred = amountPaid / 100;

        HowMuchLeft = amountPaid - (numberofHundred * 100);
        
        if (HowMuchLeft > 0)
        {
            HowFifty();
        }
        else { BillCount(); }
    }
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

    }
    
    
}
