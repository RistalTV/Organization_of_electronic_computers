using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibGenerateOfDiagrams
{
    public class Command
    {
        public Command() { }
        public int Numb { get; set; }
        private int timeDo;
        public int TimeDo
        {
            get
            {
                return timeDo;
            }
            set
            {
                timeDo = value;
            }
        }
        private bool type;//true - вычислительный процесс //false - опперация управления
        public bool Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        public string TypeS
        {
            get
            {
                return Type ? "_" : "УО";
            }
            set
            {
                if (value != String.Empty)
                    if (value.ToLower() == "_")
                    {
                        Type = true;
                    }
                    else
                    {
                        Type = false;
                    }
                else
                    Type = true;
            }
        }
        public string CacheS
        {
            get
            {
                return Cache ? "КЭШ" : "НК";
            }
            set
            {
                if (value != String.Empty)
                    if (value.ToLower() == "кэш")
                    {
                        Cache = true;
                    }
                    else
                    {
                        Cache = false;
                    }
                else
                    Cache = true;
            }
        }

        private bool cache;//true - в кэш 
        public bool Cache
        {
            get
            {
                return cache;
            }
            set
            {
                cache = value;
            }
        }
        Command(int TimeDo, bool Type, bool Cash)
        {
            this.TimeDo = TimeDo;
            this.Type = Type;
            this.Cache = Cash;
        }
    }
}
