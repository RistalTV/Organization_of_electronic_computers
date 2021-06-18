using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.ViewModel
{
    public class UpDownTextBoxViewModel : BaseViewModel
    {
        private uint _value=1;
        private uint _minValue;
        private uint _maxValue;
        private string _metaData;
        public uint Value
        {
            get => _value;
            set
            {

                if (value >= _minValue && value <= _maxValue)
                {
                    _value = value;
                }
                else
                    _value = _minValue;
                OnPropertyChanged();
            }
        }
        public uint MinValue 
        {
            get => _minValue;
            set
            {
                if (value >= 0 && value < 9999 && value < _maxValue)
                {
                    _minValue = value;
                }
                else
                    _minValue = _maxValue - 1;
                OnPropertyChanged();
            }
        }
        public uint MaxValue 
        {
            get => _maxValue;
            set
            {
                if (value >= 0 && value < 9999 && value > _minValue)
                {
                    _maxValue = value;
                }
                else
                    _maxValue = _minValue + 2;
                OnPropertyChanged();
            }
        }
        public string MetaData 
        { 
            get => _metaData; 
            set { _metaData = value; OnPropertyChanged(); } 
        }

        public UpDownTextBoxViewModel(uint _min=1, uint _max=20, uint _val=1, string _MetaData= null)
        {
            if (_MetaData == null)
                _MetaData = String.Empty;
            this.MinValue = _min;
            this.MaxValue = _max;
            this.Value = _val;
            this.MetaData = _MetaData;
        }
    }
}
