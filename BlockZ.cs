namespace Tetris_WPFApp
{
    public class BlockZ : Block
    {
        // Позиции для 4 состояний вращения
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] { new(0, 0), new(0, 1), new(1, 1), new(1, 2) },
            new Position[] { new(0, 2), new(1, 1), new(1, 2), new(2, 1) },
            new Position[] { new(1, 0), new(1, 1), new(2, 1), new(2, 2) },
            new Position[] { new(0, 1), new(1, 0), new(1, 1), new(2, 0) }
        };

        public override int Id => 7; // Код состояния вращения фигуры
        protected override Position StartOfSet => new Position(0, 3); // Начальное смещение (середина верхнего ряда)
        protected override Position[][] Tiles => tiles;
    }
}
