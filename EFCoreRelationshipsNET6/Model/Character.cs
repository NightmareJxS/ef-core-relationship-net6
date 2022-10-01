using System.Text.Json.Serialization;

namespace EFCoreRelationshipsNET6.Model
{
    // Normaly: there will be a authenticated User so no need for the User Object
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string RpgClass { get; set; } = "Knight";
        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }
        public Weapon Weapon { get; set; }
        public List<Skill> Skills { get; set; }
        // Could add a Enum here, other class/type, hitpoint, skill, attribute,...
    }
}
