namespace GOL
{
    public class GridDrawer(Grid grid)
    {
        public void Draw(int generation, int count)
        {
            Console.Clear();

            Console.WriteLine($"Generation: {generation} | Count: {count}");
            Console.WriteLine();

            for (int i = 0; i < grid.Rows; i++)
            {
                for (int j = 0; j < grid.Columns; j++)
                {
                    string alive = grid.GetIfCellIsAlive(i, j) ? "*" : " ";
                    Console.Write($"[{alive}]");
                }

                Console.WriteLine();
            }
        }
    }
}