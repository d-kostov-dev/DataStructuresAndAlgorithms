namespace ImplementAutoResizableStack
{
    public class StackArray<T>
    {
        private T[] stackValues;
        private int nextIndexToUse;

        public StackArray()
        {
            this.stackValues = new T[1];
            this.nextIndexToUse = 0;
        }

        public int Count
        {
            get
            {
                return this.stackValues.Length;
            }
        }

        public void Push(T element)
        {
            if (this.nextIndexToUse >= this.stackValues.Length)
            {
                this.IncreaseArray();
            }

            this.stackValues[this.nextIndexToUse] = element;
            this.nextIndexToUse++;
        }

        public T Pop()
        {
            var valueToReturn = this.stackValues[this.stackValues.Length - 1];
            this.DecreaseArray();
            this.nextIndexToUse--;

            return valueToReturn;
        }

        public T Peek()
        {
            return this.stackValues[this.stackValues.Length - 1];
        }

        private void IncreaseArray()
        {
            T[] newArray = new T[this.stackValues.Length + 1];

            for (int i = 0; i < this.stackValues.Length; i++)
            {
                newArray[i] = this.stackValues[i];
            }

            this.stackValues = newArray;
        }

        private void DecreaseArray()
        {
            T[] newArray = new T[this.stackValues.Length - 1];

            for (int i = 0; i < this.stackValues.Length - 1; i++)
            {
                newArray[i] = this.stackValues[i];
            }

            this.stackValues = newArray;
        }
    }
}
