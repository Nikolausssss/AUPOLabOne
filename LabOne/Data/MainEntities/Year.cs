using System.ComponentModel.DataAnnotations;

namespace LabOne.Data.MainEntities
{
    /// <summary>Представляет данные об учебном годе. </summary>
    public class Year : IDataObject
    {
        public string? Id { get; set; }

        /// <summary>Возвращает или задает наименование учебного года. </summary>
        [Required, RegularExpression(@"[2-9][0-9][0-9][0-9]-[2-9][0-9][0-9][0-9]", ErrorMessage = "Неверный формат года")]
        public string Title { get; set; } = null!;

        public bool IsRemoved { get; set; }
    }
}
