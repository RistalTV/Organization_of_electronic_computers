using System.Collections.Generic;

namespace WinFormLab_1
{
    public class ParamCommand
    {
        public ParamCommand()
        {
            listQuest = new List<int>();
        }
        // номер элемента в кэше
        int cashN;
        public int CashN
        {
            get
            {
                return cashN;
            }
            set
            {
                cashN = value;
            }
        }
        // параметры кэша правда-есть элемент в кэше
        bool cash;
        public bool Cash
        {
            get
            {
                return cash;
            }
            set
            {
                cash = value;
            }
        }
        // номер элемента в конвеере
        int conveerN;
        public int ConveerN
        {
            get
            {
                return conveerN;
            }
            set
            {
                conveerN = value;
            }
        }
        // параметр в конвеере 1 -   2 - вычислительный процесс 3 операция управления 0 -нет операции
        int conveer;
        public int Conveer
        {
            get
            {
                return conveer;
            }
            set
            {
                conveer = value;
            }
        }
        // 0 - если нет запроса \\другие номер запроса 
        List<int> listQuest;
        public List<int> ListQuest
        {
            get
            {
                return listQuest;
            }
            set
            {
                listQuest = value;
            }
        }
    }
}
