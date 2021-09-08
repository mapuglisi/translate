using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Runtime.Serialization;

namespace Translation.Common
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Language
    {
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "English")]
        English,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "French")]
        French,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "German")]
        German
    }
}
