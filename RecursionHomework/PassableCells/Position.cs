namespace PassableCells
{
    using System;

    public class Position
    {
        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public bool Equals(Position other)
        {
            if ((object)other == null)
            {
                return false;
            }

            return (this.Row == other.Row) && (this.Col == other.Col);
        }

        public override string ToString()
        {
            return string.Format("[{0},{1}]",this.Row, this.Col);
        }
    }
}
