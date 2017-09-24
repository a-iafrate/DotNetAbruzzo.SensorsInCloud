using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsInCloud.App.Models
{
   public class MainPageModel: INotifyPropertyChanged
    {
        private decimal value1 { get; set; }
        public decimal value2 { get; set; }


        public decimal Value2
        {
            get { return value2; }
            set
            {
                if (value2 != value)
                {
                    value2 = value;
                    this.RaisedOnPropertyChanged("Value2");
                }
            }
        }
        public decimal Value1
        {
            get { return value1; }
            set
            {
                if (value1 != value)
                {
                    value1 = value;
                    this.RaisedOnPropertyChanged("Value1");
                }
            }
        }


        #region Interface Member

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisedOnPropertyChanged(string _PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(_PropertyName));
            }
        }

        #endregion
    }
}
