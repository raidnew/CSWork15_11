using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    public class Program
    {
        private int _countThread = 10;
        private Thread[] _threads;

        static private void MessageOutput(object data)
        {
            ThreadData threadData = (ThreadData)data;
            Console.WriteLine($"Start thread \"{threadData.name}\" repeats:{threadData.countRepeat} delay:{threadData.delayInterval}");

            for (int  i = 0; i<threadData.countRepeat;i++)
            {
                Console.WriteLine($"repeat {i} {threadData.name}");
                Thread.Sleep(threadData.delayInterval);
            }

            Console.WriteLine($"Finish {threadData.name}");
        }

        static void Main(string[] args)
        {
            new Program();
        }

        private Program()
        {
            _threads = new Thread[_countThread];
            Random rand = new Random();
            for (int i = 0; i < _countThread; i++)
            {
                Thread newThread = new Thread(MessageOutput);
                newThread.Start(new ThreadData($"name{i}", rand.Next(30, 80), 1));
                _threads[i] = newThread;
            }

            Console.ReadKey();
        }

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


