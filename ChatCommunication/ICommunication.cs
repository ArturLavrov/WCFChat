using System.ServiceModel;

namespace ChatCommunication
{
    //TODO:extend communication interface
    [ServiceContract]
    public interface ICommunication
    {
        [OperationContract(IsOneWay = true)]
        void DisplayMessage(SendEntity someEntity);

        void SendMessage(string text);
    }
}
