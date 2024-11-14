using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TextBlade.Core.Characters;

namespace TextBlade.Core.IO;

public static class Serializer
{
    private static readonly Formatting FormattingSettings = Formatting.Indented;
    
    public static string Serialize(object o)
    {
        return JsonConvert.SerializeObject(o, FormattingSettings);
    }

    public static T Deserialize<T>(string serializedJson) where T : class
    {
        return JsonConvert.DeserializeObject<T>(serializedJson);
    }

    public static List<Character> DeserializeParty(JArray partyMembers)
    {
        var toReturn = new List<Character>();
        foreach (var member in partyMembers)
        {
            var character = JsonConvert.DeserializeObject<Character>(member.ToString());
            toReturn.Add(character);
        }
        return toReturn;
    }
}
