using UnityEngine;

public class Bookstore : MonoBehaviour
{
    [Header("Book Information")]
    [SerializeField] private float coverPrice;
    [SerializeField] private int copiesSold;

    private void Start()
    {
        double wholesaleCost = CalculateWholesaleCost();
        double revenue = CalculateRevenue();
        double profit = CalculateProfit(revenue, wholesaleCost);

        PrintResults(wholesaleCost, revenue, profit);
    }

    // Calculates the total wholesale cost including discounts and shipping
    private double CalculateWholesaleCost()
    {
        double discountedBookCost = CalculateDiscountedBookCost();
        double shippingCost = CalculateShippingCost();

        return discountedBookCost + shippingCost;
    }

    // Calculates the discounted cost of all books
    private double CalculateDiscountedBookCost()
    {
        const double discountRate = 0.60;
        return coverPrice * discountRate * copiesSold;
    }

    // Calculates shipping cost based on number of copies
    private double CalculateShippingCost()
    {
        if (copiesSold <= 0)
        {
            return 0;
        }

        const double firstCopyShipping = 3.00;
        const double additionalCopyShipping = 0.75;

        return firstCopyShipping + (additionalCopyShipping * (copiesSold - 1));
    }

    // Calculates total revenue from selling books
    private double CalculateRevenue()
    {
        return coverPrice * copiesSold;
    }

    // Calculates profit before operational costs
    private double CalculateProfit(double revenue, double wholesaleCost)
    {
        return revenue - wholesaleCost;
    }

    // Outputs results
    private void PrintResults(double wholesaleCost, double revenue, double profit)
    {
        Debug.Log("=== Bookstore Sales Report ===");
        Debug.Log($"Wholesale Cost: ${wholesaleCost:F2}");
        Debug.Log($"Revenue: ${revenue:F2}");
        Debug.Log($"Profit (Before Operational Costs): ${profit:F2}");
    }
}