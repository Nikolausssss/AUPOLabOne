using System.ComponentModel.DataAnnotations;

namespace LabOne.Data.Catalogs
{
    /// <summary>Представляет уровень обучения. </summary>
    public class Level : IDataObject
    {
        public string? Id { get; set; }

        /// <summary>Возвращает название уровня обучения. </summary>
        [Required]
        public string Title { get; init; } = null!;

        public bool IsRemoved { get; set; }
    }
}
