using System.Text;

namespace ATM.Application;

public class AtmCore
{
    public int[] Denominations { get; }

    private readonly int[] _denominationLimits;

    public AtmCore(int[] denominations)
    {
        Denominations = denominations;
        
        _denominationLimits = new int[denominations.Length];
        ResetLimits();
    }
    
    private int[] WithdrawWithLessPossibleBills(int withdrawAmount)
    {
        int remainingAmount = withdrawAmount;

        int[] denominationsAmount = new int[Denominations.Length];

        for (int i = 0; i < Denominations.Length; i++)
        {
            if (_denominationLimits[i] == 0) //Indicates that this slot should not be used
                continue;
            
            int cash = Denominations[i];
            
            int cashAmount = remainingAmount / cash;
            
            //if (_denominationLimits[i] > 0)
            cashAmount = Math.Min(_denominationLimits[i], cashAmount);
                
            remainingAmount -= cashAmount * cash;

            denominationsAmount[i] = cashAmount;
        }

        if (remainingAmount > 0)
            return new int[] {};
            
        return denominationsAmount;

    }
    
    public void ResetLimits() => Array.Fill(_denominationLimits, int.MaxValue);

    private void SetCurrentLimits(int[] combination, int currentNota)
    {
        for (int y = 0; y <= currentNota; y++)
        {
            if (combination[y] > 0)
                _denominationLimits[y] = combination[y] - 1;
        } 
    }
    
    public List<int[]> GetAllWithdrawOdds(int withdrawAmount)
    {
        var combinations = new List<int[]>();
        
        int[] currentComb;
        int j;
        
        do
        {
            currentComb = WithdrawWithLessPossibleBills(withdrawAmount);
            
            if (currentComb.Length > 0)
                combinations.Add(currentComb.ToArray());
            
            j = Array.FindIndex(currentComb, i => i > 0);
            
            SetCurrentLimits(currentComb, j);

        } while (currentComb.Length > 0 && currentComb[j] > 0 && j < Denominations.Length - 1);
        
        return combinations;
    }
    
    public string GetPrintableCombinations(int withdrawAmount, List<int[]> combinations)
    {
        var result = new StringBuilder();
        
        result.AppendLine($"It was found {combinations.Count} possible combinations to withdraw {withdrawAmount}:");
        result.AppendLine();
        
        int i = 0;
        foreach (var combination in combinations)
        {
            result.AppendLine($"Payout {++i}:");
            bool printed = false;
            
            for (int x = 0; x < combination.Length; x++)
            {
                if (combination[x] > 0)
                {
                    if (printed)
                        result.Append(" + ");

                    result.Append($"{combination[x]} x {Denominations[x]} EUR");
                    printed = true;
                }
                        
            }

            result.AppendLine();
            result.AppendLine("------------------------------------------------------");
        }
        
        return result.ToString();
    }
}