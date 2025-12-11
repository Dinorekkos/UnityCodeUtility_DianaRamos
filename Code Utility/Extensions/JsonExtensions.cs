using System;
// using Newtonsoft.Json;
// using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Dino.UtilityTools.Extensions.Json
{
    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }
    
    // public class Vector3Converter : JsonConverter<Vector3>
    // {
    //     public override void WriteJson(JsonWriter writer, Vector3 value, JsonSerializer serializer)
    //     {
    //         writer.WriteStartObject();
    //         writer.WritePropertyName("x"); writer.WriteValue(value.x);
    //         writer.WritePropertyName("y"); writer.WriteValue(value.y);
    //         writer.WritePropertyName("z"); writer.WriteValue(value.z);
    //         writer.WriteEndObject();
    //     }
    //
    //     public override Vector3 ReadJson(JsonReader reader, Type objectType, Vector3 existingValue, bool hasExistingValue, JsonSerializer serializer)
    //     {
    //         var obj = JObject.Load(reader);
    //         float x = obj["x"]?.Value<float>() ?? 0f;
    //         float y = obj["y"]?.Value<float>() ?? 0f;
    //         float z = obj["z"]?.Value<float>() ?? 0f;
    //         return new Vector3(x, y, z);
    //     }
    // }
    //
    // public class Vector4Converter : JsonConverter<Vector4>
    // {
    //     public override void WriteJson(JsonWriter writer, Vector4 value, JsonSerializer serializer)
    //     {
    //         writer.WriteStartObject();
    //         writer.WritePropertyName("x"); writer.WriteValue(value.x);
    //         writer.WritePropertyName("y"); writer.WriteValue(value.y);
    //         writer.WritePropertyName("z"); writer.WriteValue(value.z);
    //         writer.WritePropertyName("w"); writer.WriteValue(value.w);
    //         writer.WriteEndObject();
    //     }
    //
    //     public override Vector4 ReadJson(JsonReader reader, Type objectType, Vector4 existingValue, bool hasExistingValue, JsonSerializer serializer)
    //     {
    //         var obj = JObject.Load(reader);
    //         float x = obj["x"]?.Value<float>() ?? 0f;
    //         float y = obj["y"]?.Value<float>() ?? 0f;
    //         float z = obj["z"]?.Value<float>() ?? 0f;
    //         float w = obj["w"]?.Value<float>() ?? 0f;
    //         return new Vector4(x, y, z, w);
    //     }
    // }
}