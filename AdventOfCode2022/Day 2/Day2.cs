using System.Diagnostics;

namespace AdventOfCode2022.Day_2;

public class Day2
{
    
    private int Score { get; set; }
    private string InputData { get; set; }

    public async Task GetInputData()
    {
        var ff = new FileFunctions();
        InputData = await ff.ReadFile("Day 2/InputData.txt");
    }

    public int GetScore()
    {
        return Score;
    }
    
    public void ProcessInputData()
    {
        this.Score = 0;
        var data = this.InputData;
        var rounds = data.Split("\r\n");
        foreach (var round in rounds)
        {
            var actions = round.Split(' ');
            var opponentAction = MovesPoints.Null;
            var ourAction = MovesPoints.Null;
            opponentAction = actions[0] switch
            {
                "A" => MovesPoints.Rock,
                "B" => MovesPoints.Paper,
                "C" => MovesPoints.Scissors,
                _ => opponentAction
            };

            ourAction = actions[1] switch
            {
                "X" => MovesPoints.Rock,
                "Y" => MovesPoints.Paper,
                "Z" => MovesPoints.Scissors,
                _ => ourAction
            };

            Score += (int)ourAction + (int)CalculateMatch(opponentAction, ourAction);
        }
    }

    public void ProcessInputDataPart2()
    {
        this.Score = 0;
        var data = this.InputData;
        var rounds = data.Split("\r\n");
        foreach (var round in rounds)
        {
            var actions = round.Split(' ');
            var opponentAction = MovesPoints.Null;
            var ourAction = MovesPoints.Null;
            opponentAction = actions[0] switch
            {
                "A" => MovesPoints.Rock,
                "B" => MovesPoints.Paper,
                "C" => MovesPoints.Scissors,
                _ => opponentAction
            };

            ourAction = actions[1] switch
            {
                "X" =>
                    // Need to Lose
                    CalculateOurMove(opponentAction, OutcomePoints.Lose),
                "Y" =>
                    // Need to Tie
                    CalculateOurMove(opponentAction, OutcomePoints.Tie),
                "Z" =>
                    // Need to Win
                    CalculateOurMove(opponentAction, OutcomePoints.Win),
                _ => ourAction
            };

            Score += (int)ourAction + (int)CalculateMatch(opponentAction, ourAction);
        }
    }

    private OutcomePoints CalculateMatch(MovesPoints opponent, MovesPoints our)
    {
        switch (our)
        {
            case MovesPoints.Rock:
            {
                switch (opponent)
                {
                    case MovesPoints.Rock:
                        return OutcomePoints.Tie;
                    case MovesPoints.Paper:
                        return OutcomePoints.Lose;
                    case MovesPoints.Scissors:
                        return OutcomePoints.Win;
                    case MovesPoints.Null:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(opponent), opponent, null);
                }

                break;
            }
            case MovesPoints.Paper:
            {
                switch (opponent)
                {
                    case MovesPoints.Rock:
                        return OutcomePoints.Win;
                    case MovesPoints.Paper:
                        return OutcomePoints.Tie;
                    case MovesPoints.Scissors:
                        return OutcomePoints.Lose;
                    case MovesPoints.Null:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(opponent), opponent, null);
                }

                break;
            }
            case MovesPoints.Scissors:
            {
                switch (opponent)
                {
                    case MovesPoints.Rock:
                        return OutcomePoints.Lose;
                    case MovesPoints.Paper:
                        return OutcomePoints.Win;
                    case MovesPoints.Scissors:
                        return OutcomePoints.Tie;
                    case MovesPoints.Null:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(opponent), opponent, null);
                }
                
                break;
            }
            case MovesPoints.Null:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(our), our, null);
        }

        return OutcomePoints.Lose;
    }

    private MovesPoints CalculateOurMove(MovesPoints opponent, OutcomePoints matchResult)
    {
        switch (matchResult)
        {
            case OutcomePoints.Win:
            {
                switch (opponent)
                {
                    case MovesPoints.Rock:
                        return MovesPoints.Paper;
                    case MovesPoints.Paper:
                        return MovesPoints.Scissors;
                    case MovesPoints.Scissors:
                        return MovesPoints.Rock;
                    case MovesPoints.Null:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(opponent), opponent, null);
                }
                break;
            }
            case OutcomePoints.Lose:
            {
                switch (opponent)
                {
                    case MovesPoints.Rock:
                        return MovesPoints.Scissors;
                    case MovesPoints.Paper:
                        return MovesPoints.Rock;
                    case MovesPoints.Scissors:
                        return MovesPoints.Paper;
                    case MovesPoints.Null:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(opponent), opponent, null);
                }
                break;
            }
            case OutcomePoints.Tie:
            {
                return opponent;
            }
            default:
                throw new ArgumentOutOfRangeException(nameof(matchResult), matchResult, null);
        }

        return MovesPoints.Null;
    }
}