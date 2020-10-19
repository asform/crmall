using Crmall.Domain.Enum;

namespace Crmall.Domain.Infrastructure
{
    public class OperationMessage
    {
        public OperationMessage() { }

        public OperationMessage(OperationMessageTypes type, string description)
        {
            Description = description;
            Type = type;
        }

        public string Description { get; set; }

        public string DescriptionType { get; set; }

        public OperationMessageTypes Type { get; set; }

        public object Data { get; set; }
    }
}
