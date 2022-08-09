namespace RoverController;

public class Rover
{
    private readonly Plateau _plateau;
    public int X { get; private set; }
    public int Y { get; private set; }

    public CardinalDirection CardinalDirection { get; private set; }

    private string Commands { get; }

    public Rover(int x, int y, CardinalDirection cardinalDirection, string commands, Plateau plateau)
    {
        X = x;
        Y = y;
        CardinalDirection = cardinalDirection;
        Commands = commands;
        _plateau = plateau;
    }

    private bool IsRoverOnPlateau()
    {
        return X >= 0 && X < _plateau.SizeX && Y >= 0 && Y < _plateau.SizeY;
    }

    private void RotateRover(char relativeDirection)
    {
        if (relativeDirection == 'L')
        {
            TurnLeft();
        }
        else if (relativeDirection == 'R')
        {
            TurnRight();
        }
    }

    public void Start()
    {
        if (!IsRoverOnPlateau())
        {
            Console.WriteLine("Rover is not on plateau");
            return;
        }

        foreach (var command in Commands)
        {
            if (command.Equals('M'))
            {
                MoveRover();
            }
            else
            {
                RotateRover(command);
            }
        }
    }

    private void MoveRover()
    {
        switch (CardinalDirection)
        {
            case CardinalDirection.N:
                Y += 1;
                break;
            case CardinalDirection.W:
                X -= 1;
                break;
            case CardinalDirection.S:
                Y -= 1;
                break;
            case CardinalDirection.E:
                X += 1;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void TurnLeft()
    {
        CardinalDirection = CardinalDirection switch
        {
            CardinalDirection.N => CardinalDirection.W,
            CardinalDirection.E => CardinalDirection.N,
            CardinalDirection.S => CardinalDirection.E,
            CardinalDirection.W => CardinalDirection.S,
            _ => CardinalDirection
        };
    }

    private void TurnRight()
    {
        CardinalDirection = CardinalDirection switch
        {
            CardinalDirection.N => CardinalDirection.E,
            CardinalDirection.E => CardinalDirection.S,
            CardinalDirection.S => CardinalDirection.W,
            CardinalDirection.W => CardinalDirection.N,
            _ => CardinalDirection
        };
    }
}