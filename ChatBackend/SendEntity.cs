using System.Runtime.Serialization;

namespace ChatCommunication
{
    [DataContract]
    public class SendEntity
    {
        private string _username = "Anonymous";
        private string _message = "";

        public SendEntity(){ }
        public SendEntity(string u, string m)
        {
            _username = u;
            _message = m;
        }

        [DataMember]
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        [DataMember]
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }

    public delegate void DisplayMessageDelegate(SendEntity data);
    }

