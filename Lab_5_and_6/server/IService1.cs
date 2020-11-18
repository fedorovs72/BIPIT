using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace server
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        void ConnectionInfo(string name, string port, string localPath, string uri, string scheme);
        [OperationContract]
        void CountOfDBRows(string count);
        [OperationContract]
        string InsertMethod(string id_exp, string id_h, string date, string autor_order);
        [OperationContract]
        DataTable GetData();
        [OperationContract]
        string RecCheck(string id_exp, string id_h, string date, string autor_order);
        [OperationContract]
        DataTable GetExpSelectData();
        [OperationContract]
        DataTable GetHallSelectData();



    }
}
