using System;

namespace CodingChick.SlackAPI.Base
{
    public class ParamValueAttribute : Attribute
    {
        public ParamValueAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}