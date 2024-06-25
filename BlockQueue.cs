namespace Tetris_WPFApp
{
    public class BlockQueue
    {
        // Массив блоков
        private readonly Block[] blocks = new Block[]
        {
            new BlockI(),
            new BlockJ(),
            new BlockL(),
            new BlockO(),
            new BlockS(),
            new BlockT(),
            new BlockZ()
        };

        // Случайный объект
        private readonly Random random = new Random();

        // Следующий блок в очереди
        public Block NextBlock { get; private set; }

        // Конструктор
        public BlockQueue()
        {
            NextBlock = RandomBlock();
        }

        // Метод возвращает случайный блок
        private Block RandomBlock()
        {
            return blocks[random.Next(blocks.Length)];
        }

        // Метод возвращает следующий блок и обновляет свойство NextBlock
        public Block GetAndUpdate()
        {
            Block block = NextBlock;

            do { NextBlock = RandomBlock(); }
            while (block.Id == NextBlock.Id);

            return block;
        }
    }
}
