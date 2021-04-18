namespace FantasticHero.CoreGame.Logic.CoreGame
{
    public class GameObjectLogic
    {
        public GameObjectLogic(int x, int y)
        {
            X = x;
            Y = y;
        }

        private readonly char unitializedToken = char.MinValue;
        private readonly char emptyToken = ' ';
        private readonly char borderToken = '/';
        private readonly char bodyToken = '#';
        private readonly char monsters = 'X';

        private int remaining;

        public int X { get; private set; }
        public int Y { get; private set; }
        public char Value { get; private set; }

        public bool IsBorder
        {
            get
            {
                return Value == borderToken;
            }
        }

        public bool IsBody
        {
            get
            {
                return Value == bodyToken;
            }
        }

        public bool IsMonsters
        {
            get
            {
                return Value == monsters;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return Value == emptyToken || Value == unitializedToken;
            }
        }

        public bool IsForbidden
        {
            get
            {
                return IsBorder || IsBody;
            }
        }

        public void SetEmpty()
        {
            Update(emptyToken);
        }

        public void SetHead(char headToken)
        {
            Update(headToken);
        }


        public void SetBorder()
        {
            Update(borderToken);
        }

        public void SetMonsters()
        {
            Update(monsters);
        }

        public void Update(char newVal)
        {
            Value = newVal;
        }

        public void Decay()
        {
            if (--remaining == 0)
            {
                SetEmpty();
            }
        }

        public override string ToString() => $"{X}, {Y}";

        public void SetBody(int length)
        {
            Update(bodyToken);
            remaining = length;
        }
    }
}
