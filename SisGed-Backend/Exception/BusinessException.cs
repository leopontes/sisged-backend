using System;
namespace SisGed_Backend.Exception
{
    [Serializable()]
    public class BusinessException: System.Exception
    {
        public BusinessException(): base() { }
        public BusinessException(string message): base(message) { }
    }
}
