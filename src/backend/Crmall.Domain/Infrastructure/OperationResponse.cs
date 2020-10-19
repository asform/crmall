using System.Collections.Generic;
using System.Linq;

namespace Crmall.Domain.Infrastructure
{
    public class OperationResponse<T>
    {
        public OperationResponse()
        {
            if (typeof(T) == typeof(string))
                Data = default(T);
            else
                Data = System.Activator.CreateInstance<T>();

            this.Messages = new List<OperationMessage>();
        }

        public List<OperationMessage> Messages { get; set; }
        public T Data { get; set; }

        public bool IsSucceed
        {
            get { return !this.Messages.Any(); }
        }

        public OperationResponse<T> AddMessage(OperationMessage message)
        {
            this.Messages.Add(message);
            return this;
        }
    }
}
