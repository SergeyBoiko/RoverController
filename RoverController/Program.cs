using RoverController;

var plateau = new Plateau(6, 6);

var roverOne = new Rover(1, 2, CardinalDirection.N, "LMLMLMLMM", plateau);
roverOne.Start();

var roverTwo = new Rover(3, 3, CardinalDirection.E, "MMRMMRMRRM", plateau);
roverTwo.Start();

Console.WriteLine("Rover one: {0},{1},{2}", roverOne.X, roverOne.Y, roverOne.CardinalDirection);
Console.WriteLine("Rover two: {0},{1},{2}", roverTwo.X, roverTwo.Y, roverTwo.CardinalDirection);
Console.ReadKey();