using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace VRC.OSCQuery
{
    public class HostInfo
    {
        [JsonPropertyName(Keys.NAME)]
        public string name { get; set; } = string.Empty;

        [JsonPropertyName(Keys.EXTENSIONS)]
        public Dictionary<string, bool> Extensions { get; set; } = new()
        {
            { Attributes.ACCESS, true },
            { Attributes.CLIPMODE, false },
            { Attributes.RANGE, true },
            { Attributes.TYPE, true },
            { Attributes.VALUE, true },
        };

        [JsonPropertyName(Keys.OSC_IP)]
        public string oscIP { get; set; } = string.Empty;

        [JsonPropertyName(Keys.OSC_PORT)]
        public int oscPort { get; set; } = OSCQueryService.DefaultPortOsc;

        [JsonPropertyName(Keys.OSC_TRANSPORT)] 
        public string oscTransport = Keys.OSC_TRANSPORT_UDP;

        public override string ToString()
        {
            var result = JsonSerializer.Serialize(this, HostInfoJsonContext.Default.HostInfo);
            return result;
        }

        public class Keys
        {
            public const string NAME = "NAME";
            public const string EXTENSIONS = "EXTENSIONS";
            public const string OSC_IP = "OSC_IP";
            public const string OSC_PORT = "OSC_PORT";
            public const string OSC_TRANSPORT = "OSC_TRANSPORT";
            public const string OSC_TRANSPORT_UDP = "UDP";
        }

    }

    [JsonSourceGenerationOptions(DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonSerializable(typeof(HostInfo))]
    internal partial class HostInfoJsonContext : JsonSerializerContext { }
}