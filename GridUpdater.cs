namespace GOL
{
    public class GridUpdater(Grid grid)
    {
        public void Update()
        {
            for (int i = 0; i < grid.Rows; i++)
            {
                for (int j = 0; j < grid.Columns; j++)
                {
                    grid.ModifyCell(i, j, grid.CheckCellStatus(i, j));
                }
            }

            grid.Switch();
        }
    }
}