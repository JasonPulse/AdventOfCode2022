using AdventOfCode2022.Common.BaseClasses;
using AdventOfCode2022.Common.Interfaces;
using Serilog;

namespace AdventOfCode2022.Year2023.Day7;

public class Year2023_Day07 : BaseDay
{
    private ILogger _log { get; set; }
    private IInputFileService _fileService { get; set; }
    private List<Hand> Hands { get; set; }
    
    public Year2023_Day07(IInputFileService inputFileService) : base("Day7InputData.txt", inputFileService)
    {
        _log = Log.ForContext<Year2023_Day07>();
        this._fileService = inputFileService;
        Hands = new List<Hand>();
    }
    
    public IEnumerable<string> LoadInputData()
    {
        return GetInputs($"{LineSplitter}", "Year2023/Day7/");
    }

    public void ProcessInput(string[] inputLines)
    {
        foreach (var line in inputLines)
        {
            var h = new List<Cards>();
            var split = line.Split(' ');
            for (int i = 0; i < split[0].Length; i++)
            {
                var ch = split[0][i].ToString();
                switch (ch)
                {
                    case "A":
                    {
                        ch = "Ace";
                        break;
                    }

                    case "K":
                    {
                        ch = "King";
                        break;
                    }

                    case "Q":
                    {
                        ch = "Queen";
                        break;
                    }

                    case "J":
                    {
                        ch = "Joker";
                        break;
                    }
                    
                    case "T":
                    {
                        ch = "Ten";
                        break;
                    }
                }
                h.Add(Enum.Parse<Cards>(ch));
            }
            
            Hands.Add(new Hand(h, int.Parse(split[1])));
        }

        // Lowest Rank will be at index 0
        //var sorted = Hands.OrderByDescending(x => (int)x.CalculateHand).ThenByDescending(x => x.HighCard).Reverse().ToList();
        
        Hands.Sort(new Comparison<Hand>((hand, hand1) =>
        {
            try
            {
                if ((int)hand.CalculateHand > (int)hand1.CalculateHand) return 1;
                if ((int)hand.CalculateHand < (int)hand1.CalculateHand) return -1;
        
                if (hand.CalculateHand == hand1.CalculateHand && hand.HighCard == hand1.HighCard && hand.Bet == hand1.Bet) return 0;
                // Both seem to be the same go for Card vs Card
                for (int i = 0; i < 5; i++)
                {
                    if (hand.GetCardValue(i) > hand1.GetCardValue(i))
                    {
                        return 1;
                    }

                    if (hand.GetCardValue(i) < hand1.GetCardValue(i))
                    {
                        return -1;
                    }
                }

                // Nothing Matched
                _log.Error("Unable to Match Anything With {@Hand}, {@Hand1}", hand, hand1);
                return 0;

            }
            catch (Exception e)
            {
                _log.Error(e, "Unable to compare {@Hand} {@Hand1}", hand, hand1);
                return 0;
            }
        }));
        //Hands = sorted;
    }

    public int GetWinnings()
    {
        var winnings = 0;
        foreach (var hand in Hands)
        {
            winnings += hand.GetWinnings(Hands.IndexOf(hand) + 1);
        }

        return winnings;
    }
    
    record Hand(List<Cards> CardsList, int Bet)
    {
        private Guid Id = Guid.NewGuid(); 
        public int HighCard => CardsList.Select(x => (int)x).Max();
        public CardHand CalculateHand => GetHand();

        public int GetWinnings(int rank)
        {
            return Bet * rank;
        }
        private CardHand GetHand()
        {
            var joker = CardsList.FindAll(x => x == Cards.Joker).Count;
            var possible = new Dictionary<Cards, int>();
            possible.Add(Cards.Ace, CardsList.FindAll(x => x == Cards.Ace).Count);
            possible.Add(Cards.King, CardsList.FindAll(x => x == Cards.King).Count);
            possible.Add(Cards.Queen, CardsList.FindAll(x => x == Cards.Queen).Count);
            possible.Add(Cards.Ten, CardsList.FindAll(x => x == Cards.Ten).Count);
            possible.Add(Cards.Nine, CardsList.FindAll(x => x == Cards.Nine).Count);
            possible.Add(Cards.Eight, CardsList.FindAll(x => x == Cards.Eight).Count);
            possible.Add(Cards.Seven, CardsList.FindAll(x => x == Cards.Seven).Count);
            possible.Add(Cards.Six, CardsList.FindAll(x => x == Cards.Six).Count);
            possible.Add(Cards.Five, CardsList.FindAll(x => x == Cards.Five).Count);
            possible.Add(Cards.Four, CardsList.FindAll(x => x == Cards.Four).Count);
            possible.Add(Cards.Three, CardsList.FindAll(x => x == Cards.Three).Count);
            possible.Add(Cards.Two, CardsList.FindAll(x => x == Cards.Two).Count);

            if (joker == 5)
            {
                return CardHand.FiveOfAKind;
            }

            if (joker == 4)
            {
                return CardHand.FiveOfAKind;
            }
            
            if (possible.Any(x => x.Value == 5))
            {
                return CardHand.FiveOfAKind;
            }
            
            if (possible.Any(x => x.Value == 4))
            {
                return joker > 0 ? CardHand.FiveOfAKind : CardHand.FourOfAKind;
            }

            if (possible.Any(x => x.Value == 3))
            {
                if (joker > 0)
                {
                    return joker == 2 ? CardHand.FiveOfAKind : CardHand.FourOfAKind;
                }
                return possible.Any(x => x.Value == 2) ? CardHand.FullHouse : CardHand.ThreeOfAKind;
            }

            
            if (possible.Any(x => x.Value == 2))
            {
                var num = possible.Count(x => x.Value == 2);
                if (joker > 0)
                {
                    switch (joker)
                    {
                        case 1:
                            switch (num)
                            {
                                case 1:
                                    return CardHand.ThreeOfAKind;
                                case 2:
                                    return CardHand.FullHouse;
                            }

                            break;
                        case 2:
                            return CardHand.FourOfAKind;
                        case 3:
                            return CardHand.FiveOfAKind;
                    }
                }
                
                return num == 2 ? CardHand.TwoPair : CardHand.OnePair;
            }

            switch (joker)
            {
                case 1:
                    return CardHand.OnePair;
                case 2:
                    return CardHand.ThreeOfAKind;
                case 3:
                    return CardHand.FourOfAKind;
            }
            
            return CardHand.HighCard;
        }

        public int GetCardValue(int index)
        {
            return (int)CardsList[index];
        }
    }

    internal enum CardHand
    {
        FiveOfAKind = 7,
        FourOfAKind = 6,
        FullHouse = 5,
        ThreeOfAKind = 4,
        TwoPair = 3,
        OnePair = 2,
        HighCard = 1
    }
    internal enum Cards
    {
        Ace = 14,
        King = 13,
        Queen = 12,
        Joker = 1,
        Ten = 10,
        Nine = 9,
        Eight = 8,
        Seven = 7,
        Six = 6,
        Five = 5,
        Four = 4,
        Three = 3,
        Two = 2
    }
}