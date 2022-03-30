// See https://aka.ms/new-console-template for more information
using Battleships;

try
{
    var player = new Player();
    var board = new Board();
    Console.WriteLine("Start battle");
    var simulator = new Simulator(board, player);
    simulator.Run();
    Console.WriteLine("End battle");
}
catch (Exception ex)
{
    Console.WriteLine($"{ex.Message}. Game stopped.");
}