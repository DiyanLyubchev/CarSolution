namespace KafkaService.Common
{
    public interface IKafkaServiceFactory
    {
        KafkaProducerService GetProducerService(KafkaServerSettings serverSettings, KafkaProducer producer);
    }
}