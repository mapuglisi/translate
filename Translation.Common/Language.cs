using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Translation.Common
{
    /// <summary>
    /// A common enumerator defining the supported languages
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Language
    {
        /// <summary>
        /// English
        /// </summary>
        [EnumMember(Value = "English")]
        English,

        /// <summary>
        /// French
        /// </summary>
        [EnumMember(Value = "French")]
        French,

        /// <summary>
        /// German
        /// </summary>
        [EnumMember(Value = "German")]
        German
    }
}
