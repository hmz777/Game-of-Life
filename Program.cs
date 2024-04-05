using GOL;

var grid = new Grid(20, 20);
var gridUpdater = new GridUpdater(grid);
var gridDrawer = new GridDrawer(grid);
var generation = 1;

gridDrawer.Draw(generation, grid.Count());

Console.WriteLine();
Console.WriteLine("Game of Life implementation by Hamzi");
Console.WriteLine("Press enter to start...");
Console.ReadLine();

while (true)
{
    gridUpdater.Update();

    generation++;

    gridDrawer.Draw(generation, grid.Count());

    await Task.Delay(50);
}