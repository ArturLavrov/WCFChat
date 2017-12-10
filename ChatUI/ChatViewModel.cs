using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ChatCommunication;
using MVVMCommon;

namespace ChatUI
{
    //TODO:change ChatViewModel.
    public class ChatViewModel:ViewModelBase
    {
        private string _messagecontent;
        private string _displaycontent;
        private Communication _backend;
        public string MessageContent
        {
            get { return _messagecontent; }
            set
            {
                _messagecontent = value;
                NotifyPropertyChanged("MessageContent");
            }
        }
        public string DisplayContent
        {
            get { return _displaycontent; }
            set
            {
                _displaycontent = value;
                NotifyPropertyChanged("DisplayContent");
            }
        }
        public ChatViewModel()
        {
            _backend = new Communication(DisplayMessage);
        }
        private void DisplayMessage(SendEntity composite)
        {
            string username = composite.Username ?? "";
            string message = composite.Message ?? "";
            DisplayContent += (username + ": " + message + Environment.NewLine);
        }
        
        private void SendMessage()
        {
            _backend.SendMessage(MessageContent);
        }

        public ICommand SendMessageCommand
        {
            get { return new RelayCommand(c => SendMessage());}
        }

    }
}
