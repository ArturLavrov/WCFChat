using System;
using System.ServiceModel;
using ChatBL;
using ChatBL.CryptographyAlghoritms;

namespace ChatCommunication
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Communication : ICommunication
    {

        #region Everything we need to receive messages

        private DisplayMessageDelegate _displayMessageDelegate;

        public Communication(){ }

     
        public Communication(DisplayMessageDelegate dmd)
        {
            _displayMessageDelegate = dmd;
            StartService();
        }

        public void DisplayMessage(SendEntity someEntity)
        {
            if (someEntity == null)
            {
                throw new ArgumentNullException("Problem with input message");
            }
            if (_displayMessageDelegate != null)
            {
                Context context;
                context = new Context(new CheaserChipher());
                someEntity.Message = context.ContextDecoding(someEntity.Message, 3);
                _displayMessageDelegate(someEntity);
            }
        }

        #endregion // Everything we need to receive messages

        #region Everything we need for bi-directional communication

        private string _myUserName = "Anonymous";
        private ServiceHost host;
        private ChannelFactory<ICommunication> channelFactory;
        private ICommunication _channel;

        //TODO:refactor SendMessage method.
        public void SendMessage(string text)
        {
            if (text.StartsWith("setname:", StringComparison.OrdinalIgnoreCase))
            {
                _myUserName = text.Substring("setname:".Length).Trim();
                _displayMessageDelegate(new SendEntity("Event", "Setting your name to " + _myUserName));
            }
            else
            {
                Context context;
                context = new Context(new CheaserChipher());
                string encodingmessage = context.ContextEncoding(text, 3);
                _channel.DisplayMessage(new SendEntity(_myUserName, encodingmessage));
            }
        }

        private void StartService()
        {
            host = new ServiceHost(this);
            host.Open();
            channelFactory = new ChannelFactory<ICommunication>("ChatEndpoint");
            _channel = channelFactory.CreateChannel();
            
            //// Information to send to the channel
            //_channel.DisplayMessage(new SendEntity("Event", _myUserName + " has entered the conversation."));

            //// Information to display locally
            //_displayMessageDelegate(new SendEntity("Info", "To change your name, type setname: NEW_NAME"));
        }

        private void StopService()
        {
            if (host != null)
            {
                _channel.DisplayMessage(new SendEntity("Event", _myUserName + " is leaving the conversation."));
                if (host.State != CommunicationState.Closed)
                {
                    channelFactory.Close();
                    host.Close();
                }
            }
        }


        #endregion // Everything we need for bi-directional communication
    }
}
