using System;

namespace EFC
{
    [System.Serializable]
    public class MotorError
    {
        public string keyword;
        public string description;

        public MotorError(string keyword, string description)
        {
            this.keyword = keyword;
            this.description = description;
        }
    }
}
