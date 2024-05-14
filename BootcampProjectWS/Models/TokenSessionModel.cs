﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BootcampProjectWS.Models;
//
//    var tokenSessionModel = TokenSessionModel.FromJson(jsonString);

namespace BootcampProjectWS.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class TokenSessionModel
    {
        [JsonProperty("userId")]
        public long UserId { get; set; }

        [JsonProperty("dateExpired")]
        public string DateExpired { get; set; }
    }

    public partial class TokenSessionModel
    {
        public static TokenSessionModel FromJson(string json) => JsonConvert.DeserializeObject<TokenSessionModel>(json, BootcampProjectWS.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this TokenSessionModel self) => JsonConvert.SerializeObject(self, BootcampProjectWS.Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
