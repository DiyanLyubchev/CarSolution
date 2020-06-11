using System.Collections.Generic;

namespace KafkaManagerService.Model
{
    public class KafkaProtocolModel
    {
        public KafkaProtocolModel()
        {
            Head = new KpHeadModel();
            Data = new List<KpCarModel>();
        }

        public KpHeadModel Head { get; set; }
        public List<KpCarModel> Data { get; set; }
    }
    public class KpHeadModel
    {
        public string Version { get; set; }
        public string Action { get; set; }
    }

    public class KpCarModel
    {
        public string CarModel { get; set; }

        public string CarBrand { get; set; }

        public string EngineType { get; set; }
    }
}
