namespace ATM.Application.UnitTests;

public static class AtmCoreTestsData
{
    public static IEnumerable<object[]> GetWithdrawCombinationsAmount()
    {
        yield return new object[] { 100, 4 };
        yield return new object[] { 30, 1 };
        yield return new object[] { 50, 2 };
        yield return new object[] { 60, 2 };
        yield return new object[] { 80, 2 };
        yield return new object[] { 100, 4 };
        yield return new object[] { 140, 4 };
        yield return new object[] { 230, 7 };
        yield return new object[] { 370, 11 };
        yield return new object[] { 610, 19 };
        yield return new object[] { 980, 29 };
    }

    public static IEnumerable<object[]> GetWithdrawCombinationsDetails()
    {
        yield return new object[] { 10, new List<int[]>
                                     {
                                         new[] { 0, 0, 1 }
                                     }
                                   };

        yield return new object[] { 30, new List<int[]>
                                             {
                                                 new[] { 0, 0, 3 }
                                             }
                                   };

        yield return new object[] { 50, new List<int[]>
                                             {
                                                 new[] { 0, 1, 0 },
                                                 new[] { 0, 0, 5 }
                                             }
                                   };

        yield return new object[] { 60, new List<int[]>
                                             {
                                                 new[] { 0, 1, 1 },
                                                 new[] { 0, 0, 6 }
                                             }
                                   };

        yield return new object[] { 80, new List<int[]>
                                             {
                                                 new[] { 0, 1, 3 },
                                                 new[] { 0, 0, 8 }
                                             }
                                   };

        yield return new object[] { 140, new List<int[]>
                                             {
                                                 new[] { 1, 0, 4 },
                                                 new[] { 0, 2, 4 },
                                                 new[] { 0, 1, 9 },
                                                 new[] { 0, 0, 14 }
                                             }
                                   };

        yield return new object[] { 230, new List<int[]>
                                             {
                                                 new[] { 2, 0, 3 },
                                                 new[] { 1, 2, 3 },
                                                 new[] { 0, 4, 3 },
                                                 new[] { 0, 3, 8 },
                                                 new[] { 0, 2, 13 },
                                                 new[] { 0, 1, 18 },
                                                 new[] { 0, 0, 23 }
                                             }
                                   };

        yield return new object[] { 370, new List<int[]>
                                             {
                                                 new[] { 3, 1, 2 },
                                                 new[] { 2, 3, 2 },
                                                 new[] { 1, 5, 2 },
                                                 new[] { 0, 7, 2 },
                                                 new[] { 0, 6, 7 },
                                                 new[] { 0, 5, 12 },
                                                 new[] { 0, 4, 17 },
                                                 new[] { 0, 3, 22 },
                                                 new[] { 0, 2, 27 },
                                                 new[] { 0, 1, 32 },
                                                 new[] { 0, 0, 37 }
                                             }
                                   };

        yield return new object[] { 610, new List<int[]>
                                             {
                                                 new[] { 6, 0, 1 },
                                                 new[] { 5, 2, 1 },
                                                 new[] { 4, 4, 1 },
                                                 new[] { 3, 6, 1 },
                                                 new[] { 2, 8, 1 },
                                                 new[] { 1, 10, 1 },
                                                 new[] { 0, 12, 1 },
                                                 new[] { 0, 11, 6 },
                                                 new[] { 0, 10, 11 },
                                                 new[] { 0, 9, 16 },
                                                 new[] { 0, 8, 21 },
                                                 new[] { 0, 7, 26 },
                                                 new[] { 0, 6, 31 },
                                                 new[] { 0, 5, 36 },
                                                 new[] { 0, 4, 41 },
                                                 new[] { 0, 3, 46 },
                                                 new[] { 0, 2, 51 },
                                                 new[] { 0, 1, 56 },
                                                 new[] { 0, 0, 61 }
                                             }
                                   };

        yield return new object[] { 980, new List<int[]>
                                             {
                                                 new[] { 9, 1, 3 },
                                                 new[] { 8, 3, 3 },
                                                 new[] { 7, 5, 3 },
                                                 new[] { 6, 7, 3 },
                                                 new[] { 5, 9, 3 },
                                                 new[] { 4, 11, 3 },
                                                 new[] { 3, 13, 3 },
                                                 new[] { 2, 15, 3 },
                                                 new[] { 1, 17, 3 },
                                                 new[] { 0, 19, 3 },
                                                 new[] { 0, 18, 8 },
                                                 new[] { 0, 17, 13 },
                                                 new[] { 0, 16, 18 },
                                                 new[] { 0, 15, 23 },
                                                 new[] { 0, 14, 28 },
                                                 new[] { 0, 13, 33 },
                                                 new[] { 0, 12, 38 },
                                                 new[] { 0, 11, 43 },
                                                 new[] { 0, 10, 48 },
                                                 new[] { 0, 9, 53 },
                                                 new[] { 0, 8, 58 },
                                                 new[] { 0, 7, 63 },
                                                 new[] { 0, 6, 68 },
                                                 new[] { 0, 5, 73 },
                                                 new[] { 0, 4, 78 },
                                                 new[] { 0, 3, 83 },
                                                 new[] { 0, 2, 88 },
                                                 new[] { 0, 1, 93 },
                                                 new[] { 0, 0, 98 }
                                             }
                                   };

            }
}