namespace GOL
{
    public class Grid
    {
        private bool[,] GridValue { get; set; }
        private bool[,] NextGridValue { get; set; }

        public Grid(int rows, int columns)
        {
            var grid = new bool[rows, columns];
            var random = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    grid[i, j] = random.Next(0, 2) == 1;
                }
            }

            GridValue = grid;
            NextGridValue = grid;
        }

        #region Query

        public int Rows => GridValue.GetLength(0);
        public int Columns => GridValue.GetLength(1);
        public int Count()
        {
            var query = from bool item in GridValue
                        select item;

            return query.Count(c => c);
        }
        public bool GetIfCellIsAlive(int row, int column) => GridValue[row, column];
        public CellStatus CheckCellStatus(int row, int column)
        {
            int neighbors = 0;
            int r, c;

            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    r = row - i + 1;
                    c = column - j + 1;

                    if ((r == row && c == column) ||
                        (r < 0 || c < 0) ||
                        (r > Rows - 1 || c > Columns - 1))
                    {
                        continue;
                    }

                    if (GetIfCellIsAlive(r, c))
                        neighbors++;
                }
            }

            return neighbors switch
            {
                < 2 => CellStatus.Dead,
                3 => CellStatus.Alive,
                > 3 => CellStatus.Dead,
                2 => CellStatus.Unchanged
            };
        }

        #endregion

        #region Command

        public void ClearGrid() => GridValue = new bool[Rows, Columns];
        public void ModifyCell(int row, int column, CellStatus status)
        {
            switch (status)
            {
                case CellStatus.Dead:
                    NextGridValue[row, column] = false;
                    break;
                case CellStatus.Alive:
                    NextGridValue[row, column] = true;
                    break;
                case CellStatus.Unchanged:
                    NextGridValue[row, column] = GridValue[row, column];
                    break;
            }
        }
        public void Switch()
        {
            GridValue = NextGridValue;
            NextGridValue = new bool[Rows, Columns];
        }
        public void SetInitialPattern(params (int r, int c)[] cells)
        {
            ClearGrid();

            foreach (var (r, c) in cells)
            {
                GridValue[r, c] = true;
            }
        }

        #endregion
    }
}