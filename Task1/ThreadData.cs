namespace Task1
{
    public partial class Program
    {
        private struct ThreadData
        {
            public string name;
            public int delayInterval;
            public int countRepeat;

            public ThreadData(string name, int countRepeat, int delayInterval)
            {
                this.name = name;
                this.delayInterval = delayInterval;
                this.countRepeat = countRepeat;
            }
        }

    }

}


