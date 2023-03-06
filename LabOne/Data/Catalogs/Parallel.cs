using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Microsoft.Build.ObjectModelRemoting;
using System.ComponentModel.DataAnnotations;

namespace LabOne.Data.Catalogs
{
    /// <summary>Представляет учебную параллель (1, 2, ..., 11) </summary>
    public class Parallel : IDataObject
    {
        public string? Id { get; set; }

        /// <summary>Возвращает номер параллели </summary>
        [Required,
            Range(1, 11, ErrorMessage = "Неккоретная цифра класса")]
        public int Number { get; init; }

        /// <summary>Возвращает или задает Id уровень обучения параллели. </summary>
        public string LevelId { get; set; } = null!;

        /// <summary>Возвращает или задает уровень обучения </summary>
        public Level? Level { get; set; }

        public bool IsRemoved { get; set; }
    }
}
