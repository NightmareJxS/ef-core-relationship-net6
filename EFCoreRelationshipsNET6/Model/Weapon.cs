using System.Text.Json.Serialization;

namespace EFCoreRelationshipsNET6.Model
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; } = 10;
        [JsonIgnore]// could use DTO, don't need character
        public Character Character { get; set; }
        public int CharacterId { get; set; }
    }
}
