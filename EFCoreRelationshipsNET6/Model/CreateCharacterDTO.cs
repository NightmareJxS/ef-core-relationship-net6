namespace EFCoreRelationshipsNET6.Model
{
    // Could also name CharacterDTO
    // Note this is an example, pls don't use preset value like this
    public class CreateCharacterDTO
    {
        public string Name { get; set; } = "Character";
        public string RpgClass { get; set; } = "Knight";
        public int UserId { get; set; } = 1;
    }
}
