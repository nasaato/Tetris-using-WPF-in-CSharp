namespace Tetris_WPFApp
{
    public class GameState
    {
        // Резервное поле для следующего блока
        private Block currentBlock;

        public Block CurrentBlock
        {
            get => currentBlock;
            private set
            {
                currentBlock = value;
                currentBlock.Reset();

                for (int i = 0; i < 2; i++)
                {
                    currentBlock.Move(1, 0);

                    if (!BlockFits())
                    {
                        currentBlock.Move(-1, 0);
                    }
                }
            }
        }

        // Игровая сетка
        public GameGrid GameGrid { get; }

        // Очередь блоков
        public BlockQueue BlockQueue { get; }

        // Логическое значение "Конец игры"
        public bool GameOver { get; private set; }

        // Счет игры
        public int Score { get; private set; }

        // Удерживаемый блок
        public Block HeldBlock { get; private set; }

        // Можно ли удержать
        public bool CanHold { get; private set; }

        // Конструктор с 22 строками и 10 столбцами
        public GameState()
        {
            GameGrid = new GameGrid(22, 10);
            BlockQueue = new BlockQueue();
            CurrentBlock = BlockQueue.GetAndUpdate();
            CanHold = true;
        }

        // Метод проверки является ли блок легальным
        private bool BlockFits()
        {
            foreach (Position p in CurrentBlock.TilePositions())
            {
                if (!GameGrid.IsEmpty(p.Row, p.Column))
                {
                    return false;
                }
            }

            return true;
        }

        // Удержание блока
        public void HoldBlock()
        {
            if (!CanHold)
            {
                return;
            }

            if (HeldBlock == null)
            {
                HeldBlock = currentBlock;
                CurrentBlock = BlockQueue.GetAndUpdate();
            }
            else
            {
                Block temp = currentBlock;
                CurrentBlock = HeldBlock;
                HeldBlock = temp;
            }

            CanHold = false;
        }
        
        // Поворот текущего блока по часовой стрелке, если возможно
        public void RotateBlockCW()
        {
            CurrentBlock.RotateCW();

            // Если нельзя повернуть, то возвращаем в исходное положение
            if (!BlockFits()) { CurrentBlock.RotateCCW(); }
        }

        // Поворот текущего блока против часовой стрелки, если возможно
        public void RotateBlockCCW()
        {
            CurrentBlock.RotateCCW();

            // Если нельзя повернуть, то возвращаем в исходное положение
            if (!BlockFits()) { CurrentBlock.RotateCW(); }
        }

        // Перемещение текущего блока влево
        public void MoveBlockLeft()
        {
            CurrentBlock.Move(0, -1);

            // Если нельзя переместить, то возвращаем в исходное положение
            if (!BlockFits()) { CurrentBlock.Move(0, 1); }
        }

        // Перемещение текущего блока вправо
        public void MoveBlockRight()
        {
            CurrentBlock.Move(0, 1);

            // Если нельзя переместить, то возвращаем в исходное положение
            if (!BlockFits()) { CurrentBlock.Move(0, -1); }
        }

        // Проверка окончена ли игра
        private bool IsGameOver()
        {
            return !(GameGrid.IsRowEmpty(0) && GameGrid.IsRowEmpty(1));
        }

        // Метод который будет вызван, если фигура не может быть перемещен вниз
        private void PlaceBlock()
        {
            // Перебор позиций текущего блока и установка этих позиций
            foreach (Position p in CurrentBlock.TilePositions())
            {
                GameGrid[p.Row, p.Column] = CurrentBlock.Id;
            }

            Score += GameGrid.ClearFullRows();

            if (IsGameOver())
            {
                GameOver = true;
            }
            else
            {
                CurrentBlock = BlockQueue.GetAndUpdate();
                CanHold = true;
            }
        }

        // Метод перемещения текущего блока вниз
        public void MoveBlockDown()
        {
            CurrentBlock.Move(1, 0);

            // Если нельзя переместить, то возвращаем в исходное положение
            if (!BlockFits())
            {
                CurrentBlock.Move(-1, 0);
                PlaceBlock();
            }
        }

        // Количество пустых ячеек под блоком
        private int TileDropDistance(Position p)
        {
            int drop = 0;

            while (GameGrid.IsEmpty(p.Row + drop + 1, p.Column))
            {
                drop++;
            }
            
            return drop;
        }

        // На сколько блоков можно переместить вниз
        public int BlockDropDistance()
        {
            int drop = GameGrid.Rows;

            foreach (Position p in CurrentBlock.TilePositions())
            {
                drop = System.Math.Min(drop, TileDropDistance(p));
            }

            return drop;
        }

        // Перемещение блока вниз на сколько возможно
        public void DropBlock()
        {
            CurrentBlock.Move(BlockDropDistance(), 0);
            PlaceBlock();
        }
    }
}
