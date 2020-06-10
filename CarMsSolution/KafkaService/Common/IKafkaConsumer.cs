using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace KafkaService.Common
{
    public interface IKafkaConsumer
    {
        Task ProccessMessage(KafkaOptions kafkaOptions, IServiceScope scope, string value);
    }
}
