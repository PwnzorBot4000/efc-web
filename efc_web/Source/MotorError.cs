using System;
using Newtonsoft.Json;

namespace EFC
{
    [Serializable]
    public class MotorError
    {
        public string keyword;
        public string description;

        public MotorError(string keyword, string description)
        {
            this.keyword = keyword;
            this.description = description;
        }

        public string jsonSerialize()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
