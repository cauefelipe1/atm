using FluentAssertions;

namespace ATM.Application.UnitTests;

public class AtmCoreTests
{
    private int[] _availableNotes = { 100, 50, 10 };
    
    [Theory(DisplayName = "Validate the GetAllOdds")]
    [MemberData(nameof(AtmCoreTestsData.GetWithdrawCombinationsAmount), MemberType = typeof(AtmCoreTestsData))]
    public void Possible_Get_All_Odds_Withdraw(int withdrawAmount, int odds)
    {
        var core = new AtmCore(_availableNotes);

        var result = core.GetAllWithdrawOdds(withdrawAmount);
        
        Assert.Equal(odds, result.Count);
    }
    
    [Theory(DisplayName = "Validate the GetAllOdds combinations")]
    [MemberData(nameof(AtmCoreTestsData.GetWithdrawCombinationsDetails), MemberType = typeof(AtmCoreTestsData))]
    public void Possible_Get_All_Odds_Withdraw_Combinations(int withdrawAmount, List<int[]> odds)
    {
        var core = new AtmCore(_availableNotes);

        var result = core.GetAllWithdrawOdds(withdrawAmount);

        result.Should().NotBeNull();
        result.Should().HaveSameCount(odds);
        result.Should().BeEquivalentTo(odds);
    }
    
    [Theory(DisplayName = "Validate the GetAllOdds")]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(5)]
    [InlineData(101)]
    [InlineData(234)]
    public void Possible_Get_All_Odds_Withdraw_Impossible(int withdrawAmount)
    {
        var core = new AtmCore(_availableNotes);

        var result = core.GetAllWithdrawOdds(withdrawAmount);

        result.Should().NotBeNull();
        result.Should().HaveCount(0);
    }
}