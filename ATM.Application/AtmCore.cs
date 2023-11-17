using System.Text;

namespace ATM.Application;

public class AtmCore
{
    public int[] Notes { get; }

    private readonly int[] _notesLimits;

    public AtmCore(int[] notes)
    {
        Notes = notes;
        
        _notesLimits = new int[notes.Length];
        ResetLimits();
    }
    
    private int[] WithdrawWithLessPossibleBills(int withdrawAmount)
    {
        int remainingAmount = withdrawAmount;

        int[] notesAmount = new int[Notes.Length];

        for (int i = 0; i < Notes.Length; i++)
        {
            if (_notesLimits[i] == 0) //Indicates that this slot should not be used
                continue;
            
            int cash = Notes[i];
            
            int cashAmount = remainingAmount / cash;
            
            cashAmount = Math.Min(_notesLimits[i], cashAmount);
                
            remainingAmount -= cashAmount * cash;

            notesAmount[i] = cashAmount;
        }

        if (remainingAmount > 0)
            return new int[] {};
            
        return notesAmount;

    }
    
    public void ResetLimits() => Array.Fill(_notesLimits, int.MaxValue);

    private void SetCurrentLimits(int[] combination, int currentNota)
    {
        for (int y = 0; y <= currentNota; y++)
        {
            if (combination[y] > 0)
                _notesLimits[y] = combination[y] - 1;
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

        } while (currentComb.Length > 0 && currentComb[j] > 0 && j < Notes.Length - 1);
        
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

                    result.Append($"{combination[x]} x {Notes[x]} EUR");
                    printed = true;
                }
                        
            }

            result.AppendLine();
            result.AppendLine("------------------------------------------------------");
        }
        
        return result.ToString();
    }
}