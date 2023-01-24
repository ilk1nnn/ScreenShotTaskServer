using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TcpServerToClientSendSS.Commands;

namespace TcpServerToClientSendSS.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

        public ConnectCommand ConnectCommand => new ConnectCommand(this);
        public ImageCommand ImageCommand => new ImageCommand(this);
        private string ipAddress;

        public string IpAddress
        {
            get
            {
                return ipAddress;
            }
            set
            {
                ipAddress = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(IpAddress)));
            }
        }

       



        private string source;

        public string Source
        {
            get
            {
                return source;
            }
            set
            {
                source = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Source)));
            }
        }



        private StackPanel stackPanel;

        public StackPanel StackPanel
        {
            get
            {
                return stackPanel;
            }
            set
            {
                stackPanel = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(StackPanel)));
            }
        }

        private ObservableCollection<StackPanel> allScreens;

        public ObservableCollection<StackPanel> AllScreens
        {
            get
            {
                return allScreens;
            }
            set
            {
                allScreens = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(AllScreens)));
            }
        }

        private string timer;

        public string Timer
        {
            get { return timer; }
            set
            {
                timer = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Timer)));
            }
        }

    }
}
