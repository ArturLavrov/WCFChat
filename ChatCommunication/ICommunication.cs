using System.ServiceModel;

namespace ChatCommunication
{
    [ServiceContract]
    public interface ICommunication
    {
        [OperationContract(IsOneWay = true)]
        void DisplayMessage(SendEntity someEntity);

        void SendMessage(string text);
    }
}
