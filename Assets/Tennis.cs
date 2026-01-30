using UnityEngine;
using System.Collections.Generic;

public class Tennis : MonoBehaviour
{
    [Header("Kyle Probabilities (%)")]
    [Range(0, 100)][SerializeField] private float kyleFirstPoint;
    [Range(0, 100)][SerializeField] private float kyleAfterWin;
    [Range(0, 100)][SerializeField] private float kyleAfterLoss;

    // Juan's probabilities (given)
    private const double juanFirstPoint = 0.60;
    private const double juanAfterWin = 0.80;
    private const double juanAfterLoss = 0.40;

    private Dictionary<string, double> memoizationTable;

    private void Start()
    {
        memoizationTable = new Dictionary<string, double>();

        double kyleWinProbability = CalculateGameWinProbability(
            kylePoints: 0,
            juanPoints: 0,
            lastPointWinner: LastPoint.None
        );

        double juanWinProbability = 1.0 - kyleWinProbability;

        PrintResults(kyleWinProbability, juanWinProbability);
    }

    // Repeating probability calculation with memoization
    private double CalculateGameWinProbability(
        int kylePoints,
        int juanPoints,
        LastPoint lastPointWinner
    )
    {
        // Checks win conditions
        if (HasWonGame(kylePoints, juanPoints))
            return 1.0;

        if (HasWonGame(juanPoints, kylePoints))
            return 0.0;

        string stateKey = $"{kylePoints}-{juanPoints}-{lastPointWinner}";
        if (memoizationTable.ContainsKey(stateKey))
            return memoizationTable[stateKey];

        double kylePointWinChance = GetPointWinProbability(lastPointWinner);

        double winIfKyleWinsPoint = CalculateGameWinProbability(
            kylePoints + 1,
            juanPoints,
            LastPoint.Kyle
        );

        double winIfKyleLosesPoint = CalculateGameWinProbability(
            kylePoints,
            juanPoints + 1,
            LastPoint.Juan
        );

        double totalWinChance =
            kylePointWinChance * winIfKyleWinsPoint +
            (1 - kylePointWinChance) * winIfKyleLosesPoint;

        memoizationTable[stateKey] = totalWinChance;
        return totalWinChance;
    }

    // Determines whether a player has won the game
    private bool HasWonGame(int playerPoints, int opponentPoints)
    {
        if (playerPoints >= 4 && opponentPoints <= 2)
            return true;

        if (playerPoints >= 4 && playerPoints - opponentPoints >= 2)
            return true;

        return false;
    }

    // Determines Kyle's probability of winning the next point
    private double GetPointWinProbability(LastPoint lastWinner)
    {
        if (lastWinner == LastPoint.None)
            return kyleFirstPoint / 100.0;

        if (lastWinner == LastPoint.Kyle)
            return kyleAfterWin / 100.0;

        return kyleAfterLoss / 100.0;
    }

    // Outputs results
    private void PrintResults(double kyleChance, double juanChance)
    {
        Debug.Log("=== Tennis Game Win Probabilities ===");
        Debug.Log($"Kyle Win Probability: {kyleChance:P2}");
        Debug.Log($"Juan Win Probability: {juanChance:P2}");
    }

    // Tracks who won the previous point
    private enum LastPoint
    {
        None,
        Kyle,
        Juan
    }
}