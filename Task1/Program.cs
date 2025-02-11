﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    public partial class Program
    {
        private int _countThread = 10;
        private Thread[] _threads;

        static void Main(string[] args)
        {
            new Program();
        }

        private void MessageOutput(object data)
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

    }

}


