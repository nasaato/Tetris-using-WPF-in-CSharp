namespace Tetris_WPFApp
{
    public abstract class Block
    {
        protected abstract Position[][] Tiles { get; } // Позиция клеток в 4 состояния вращения
        protected abstract Position StartOfSet { get; } // Начальное смещение
        public abstract int Id { get; } // Код фигуры

        private int rotationState; // Состояние вращения
        private Position offset; // Текущее смещение

        public Block()
        {
            offset = new Position(StartOfSet.Row, StartOfSet.Column);
        }

        // Метод который возвращает позицию сетки занятую блоком с учетом поворота и смещения
        public IEnumerable<Position> TilePositions()
        {
            foreach (Position p in Tiles[rotationState])
            {
                yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
            }
        }

        // Метод поворота фигуры на 90 градусов по часовой стрелке
        public void RotateCW()
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }

        // Метод поворота фигуры на 90 градусов против часовой стрелки
        public void RotateCCW()
        {
            if (rotationState == 0) { rotationState = Tiles.Length - 1; }
            else { rotationState--; }
        }

        // Метод который перемещает блок на заданное количество строк и столбцов
        public void Move(int rows, int columns)
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        // Метод сброса позиции и вращения
        public void Reset()
        {
            rotationState = 0;
            offset.Row = StartOfSet.Row;
            offset.Column = StartOfSet.Column;
        }
    }
}
