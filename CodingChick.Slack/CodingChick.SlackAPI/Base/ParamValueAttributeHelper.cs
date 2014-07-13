using System;
using System.Linq;
using System.Reflection;

namespace CodingChick.SlackAPI.Base
{
    public class ParamValueAttributeHelper
    {
        public static string GetParamValueOfEnumAttribute<T>(Enum enumMember)
        {
            MemberInfo memberInfo = typeof (T).GetMember(enumMember.ToString())
                .FirstOrDefault();

            if (memberInfo != null)
            {
                ParamValueAttribute attribute = (ParamValueAttribute)
                    memberInfo.GetCustomAttributes(typeof (ParamValueAttribute), false)
                        .FirstOrDefault();

                return attribute.Name;
            }

            return null;
        }
    }
}