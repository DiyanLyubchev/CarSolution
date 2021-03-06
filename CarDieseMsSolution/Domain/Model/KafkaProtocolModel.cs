﻿using System.Collections.Generic;

namespace Domain.Model
{
    public class KafkaProtocolModel
    {
        public KafkaProtocolModel()
        {
            Head = new KpHeapModel();
            Data = new List<KpCarModel>();
        }

        public KpHeapModel Head { get; set; }
        public List<KpCarModel> Data { get; set; }
    }

    public class KpHeapModel
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
