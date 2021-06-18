using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormLab_1
{
    public static class Computer
    {
        public static List<ClassRet> DoDo(Queue<Command> queue, int tick1, int tick2, int tick3)// очередь || выгрузка из памяти \\ формула памяти\\ во сколько шина медленней процессора
        {
            var queueMain = new Queue<Command>(queue);
            var listProcess = new List<ClassRet>();
            var cash = false;
            var conveer = false;
            var conveerN = 0;
            var timeConveer = 0;
            var timeCash = 0;
            Command term = null;
            Command termCash = null;
            var queueMainAfterCASH = new Queue<Command>();
            var queueCash = new Queue<Command>();
            var try1 = false;
            for (var i = 0; ; i++)
            {
                listProcess.Add(new ClassRet());
                if (!conveer)
                {
                    if (queueMainAfterCASH.Count != 0)
                    {
                        term = queueMainAfterCASH.Dequeue();
                        if (!term.Type)
                        {
                            conveerN = term.TimeDo * tick3;
                            try1 = true;
                        }
                        else
                        {
                            conveerN = term.TimeDo;
                        }
                        timeConveer = conveerN + tick1;
                        listProcess.Last().Conveer = 1;
                        listProcess.Last().ConveerN = term.Numb;
                        conveer = true;
                    }
                    else if (queueMain.Count != 0)
                    {
                        term = queueMain.Dequeue();
                        while (!term.Cache)
                        {
                            listProcess.Last().ListQuest.Add(term.Numb);
                            queueCash.Enqueue(term);
                            if (queueMain.Count == 0)
                            {
                                term = null;
                                break;
                            }
                            else
                            {
                                term = queueMain.Dequeue();
                            }
                        }
                        if (term != null)
                        {
                            if (!term.Type)
                            {
                                conveerN = term.TimeDo * tick3;
                                try1 = true;
                            }
                            else
                            {
                                conveerN = term.TimeDo;
                            }
                            timeConveer = conveerN + tick1;
                            listProcess.Last().Conveer = 1;
                            listProcess.Last().ConveerN = term.Numb;
                            conveer = true;
                        }
                        else
                        {
                            listProcess.Last().Conveer = 0;
                            listProcess.Last().ConveerN = 0;
                        }
                    }
                    else
                    {
                        listProcess.Last().Conveer = 0;
                        listProcess.Last().ConveerN = 0;
                    }
                }
                else
                {
                    if (timeConveer > conveerN)
                    {
                        listProcess.Last().Conveer = 1;
                        listProcess.Last().ConveerN = term.Numb;
                    }
                    else if (timeConveer == conveerN)
                    {
                        if (term.Type)
                        {
                            listProcess.Last().ConveerN = term.Numb;
                            listProcess.Last().Conveer = 2;
                        }
                        else
                        {
                            if (try1)
                            {
                                listProcess.Last().ListQuest.Add(term.Numb);
                                try1 = false;
                            }
                            if (!cash)
                            {
                                listProcess.Last().ConveerN = term.Numb;
                                listProcess.Last().Conveer = 3;
                                cash = true;
                            }
                            else
                            {
                                listProcess.Last().ConveerN = 0;
                                listProcess.Last().Conveer = 0;
                                timeConveer++;
                            }
                        }
                    }
                    else
                    {
                        listProcess.Last().ConveerN = term.Numb;
                        if (term.Type)
                        {
                            listProcess.Last().Conveer = 2;
                        }
                        else
                        {
                            listProcess.Last().Conveer = 3;
                        }
                    }
                }
                //
                if (!cash)
                {
                    if (queueCash.Count != 0)
                    {
                        termCash = queueCash.Dequeue();
                        cash = true;
                        timeCash = tick2 * tick3;
                        listProcess.Last().Cash = true;
                        listProcess.Last().CashN = termCash.Numb;
                    }
                    else
                    {
                        listProcess.Last().Cash = false;
                        listProcess.Last().CashN = 0;
                    }
                }
                else
                {
                    if (timeCash != 0)
                    {
                        listProcess.Last().Cash = true;
                        listProcess.Last().CashN = termCash.Numb;
                    }
                    else
                    {
                        listProcess.Last().Cash = false;
                        listProcess.Last().CashN = 0;
                    }
                }

                //
                if (timeConveer != 0)
                {
                    if ((--timeConveer) == 0)
                    {
                        conveer = false;
                        if (!term.Type)
                        {
                            cash = false;
                        }
                        term = null;
                    }
                }
                //
                if (timeCash != 0)
                {
                    if ((--timeCash) == 0)
                    {
                        queueMainAfterCASH.Enqueue(termCash);
                        cash = false;
                        termCash = null;
                    }
                }
                if (!conveer && !cash && timeConveer == 0 && timeCash == 0 && queueMain.Count == 0 && queueMainAfterCASH.Count == 0 && queueCash.Count == 0)
                {
                    return listProcess;
                }
            }
        }

        public static async Task DoDoM(Queue<Command> queue, int tick1, int tick2, int tick3)// очередь || выгрузка из памяти \\ формула памяти\\ во сколько шина медленней процессора
        {
            await Task.Run(() => {
                var queueMain = new Queue<Command>(queue);
                var cash = false;
                var conveer = false;
                var conveerN = 0;
                var timeConveer = 0;
                var timeCash = 0;
                Command term = null;
                Command termCash = null;
                var queueMainAfterCASH = new Queue<Command>();
                var queueCash = new Queue<Command>();
                var try1 = false;
                for (var i = 0; ; i++)
                {
                    if (!conveer)
                    {
                        if (queueMainAfterCASH.Count != 0)
                        {
                            term = queueMainAfterCASH.Dequeue();
                            if (!term.Type)
                            {
                                conveerN = term.TimeDo * tick3;
                                try1 = true;
                            }
                            else
                            {
                                conveerN = term.TimeDo;
                            }
                            timeConveer = conveerN + tick1;
                            conveer = true;
                        }
                        else if (queueMain.Count != 0)
                        {
                            term = queueMain.Dequeue();
                            while (!term.Cache)
                            {
                                queueCash.Enqueue(term);
                                if (queueMain.Count == 0)
                                {
                                    term = null;
                                    break;
                                }
                                else
                                {
                                    term = queueMain.Dequeue();
                                }
                            }
                            if (term != null)
                            {
                                if (!term.Type)
                                {
                                    conveerN = term.TimeDo * tick3;
                                    try1 = true;
                                }
                                else
                                {
                                    conveerN = term.TimeDo;
                                }
                                timeConveer = conveerN + tick1;
                                conveer = true;
                            }
                        }
                    }
                    else
                    {
                        if (timeConveer == conveerN)
                        {
                            if (!term.Type)
                            {
                                if (try1)
                                {
                                    try1 = false;
                                }
                                if (!cash)
                                {
                                    cash = true;
                                }
                                else
                                {
                                    timeConveer++;
                                }
                            }
                        }
                        else if (timeConveer < conveerN)
                        {
                            if (term.Type)
                            {
                            }
                            else
                            {
                            }
                        }
                    }
                    //
                    if (!cash)
                    {
                        if (queueCash.Count != 0)
                        {
                            termCash = queueCash.Dequeue();
                            cash = true;
                            timeCash = tick2 * tick3;
                        }
                    }

                    //
                    if (timeConveer != 0)
                    {
                        if ((--timeConveer) == 0)
                        {
                            conveer = false;
                            if (!term.Type)
                            {
                                cash = false;
                            }
                            term = null;
                        }
                    }
                    //
                    if (timeCash != 0)
                    {
                        if ((--timeCash) == 0)
                        {
                            queueMainAfterCASH.Enqueue(termCash);
                            cash = false;
                            termCash = null;
                        }
                    }
                    if (!conveer && !cash && timeConveer == 0 && timeCash == 0 && queueMain.Count == 0 && queueMainAfterCASH.Count == 0 && queueCash.Count == 0)
                    {
                        return;
                    }
                }

            });
        }

        public static Queue<Command> RandomOperation(int N)
        {
            var rand = new Random();
            var queueMain = new Queue<Command>();
            int rand1;
            int rand2;
            for (var i = 0; i < N; i++)
            {
                var term = new Command();
                _ = rand.Next(100);
                term.Cache = (rand.Next(100) < 75);
                term.Numb = i + 1;
                rand1 = rand.Next(100);
                rand2 = rand.Next(100);
                if (rand1 < 20)
                {
                    term.Type = true;
                    if (rand2 < 70)
                    {
                        term.TimeDo = 5;
                    }
                    else if (rand2 < 90)
                    {
                        term.TimeDo = 2;
                    }
                    else
                    {
                        term.TimeDo = 1;
                    }
                }
                else if (rand1 < 35)
                {
                    term.Type = true;
                    if (rand2 < 70)
                    {
                        term.TimeDo = 2;
                    }
                    else if (rand2 < 90)
                    {
                        term.TimeDo = 5;
                    }
                    else
                    {
                        term.TimeDo = 1;
                    }
                }
                else if (rand1 < 55)
                {
                    term.Type = false;
                    if (rand2 < 80)
                    {
                        term.TimeDo = 2;
                    }
                    else
                    {
                        term.TimeDo = 1;
                    }
                }
                else
                {
                    term.Type = true;
                    if (rand2 < 60)
                    {
                        term.TimeDo = 2;
                    }
                    else
                    {
                        term.TimeDo = 1;
                    }
                }
                queueMain.Enqueue(term);
            }
            return queueMain;
        }
    }
}
