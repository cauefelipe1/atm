using System.Text;
using ATM.Application;
    
namespace ATM;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("How much do you want to withdraw?");
        
        string userInput = Console.ReadLine();
        int withdrawAmount = int.Parse(userInput);

        int[] notes = { 100, 50, 10};
        
        var atm = new AtmCore(notes);
            
        var withdrawOdds = atm.GetAllWithdrawOdds(withdrawAmount);
        
        if (withdrawOdds.Count > 0)
            Console.WriteLine(atm.GetPrintableCombinations(withdrawAmount, withdrawOdds));
        else
            Console.WriteLine($"It is not possible to withdraw {withdrawAmount} EUR");
    }
}