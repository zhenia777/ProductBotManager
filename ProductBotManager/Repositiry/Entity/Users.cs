using System.ComponentModel.DataAnnotations;

namespace ProductBotManager.Repositiry.Entity
{
    public class Users : AddedDateEntity, IEntity
    {
        public int Id { get; set; }
        [Required]
        public long TgId { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }

    }
}
