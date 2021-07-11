using System;

namespace CreatorDiagrams.models
{
    public class Command
    {
        public Command() { }
        public int Numb { get; set; }
        private int _timeDo;
        public int TimeDo
        {
            get
            {
                return _timeDo;
            }
            set
            {
                _timeDo = value;
            }
        }
        private bool _type;//true - вычислительный процесс //false - опперация управления
        public bool Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }
        private bool _cache;//true - в кэш 
        public bool Cache
        {
            get
            {
                return _cache;
            }
            set
            {
                _cache = value;
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

        public Command(int TimeDo, bool Type, bool Cash)
        {
            this.TimeDo = TimeDo;
            this.Type = Type;
            this.Cache = Cash;
        }
    }
}
