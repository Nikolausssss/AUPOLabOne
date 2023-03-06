using LabOne.Data.Catalogs;
using NuGet.Protocol;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabOne.Data.MainEntities
{
    /// <summary>Представляет данные об учебном классе </summary>
    public class Course : IDataObject
    {
        public string? Id { get; set; }

        [Required, RegularExpression(@"[а-я]|[a-я][а-я]", ErrorMessage = "Некорректная буква класса")]
        public string Letter { get; set; } = null!;

        [NotMapped]
        /// <summary>Возвращает полное название класса (номер , буква и год). Требует загрузки <see cref="Course.Parallel"/> и <see cref="Course.Year"/> </summary>
        public string Title => $"{Parallel?.Number}{Letter} {Year?.Title}";

        /// <summary>Возвращает или задает Id учителя класса. </summary>
        [Required]
        public string TeacherId { get; set; } = null!;

        /// <summary>Возвращает или задает класснного руководителя класса. </summary>
        public Teacher? Teacher { get; set; }

        /// <summary>Возвращает или задает Id учебного года класса. </summary>
        [Required]
        public string YearId { get; set; } = null!;

        /// <summary>Возвращает или задает учебный год данного класса. </summary>
        public Year? Year { get; set; }

        /// <summary>Возвращает или задает Id учебной параллели класса. </summary>
        [Required]
        public string ParallelId { get; set; } = null!;

        /// <summary>Возвращает или задает параллель данного класса. </summary>
        public Catalogs.Parallel? Parallel { get; set; }

        /// <summary>возвращает или задает список школьников данного класса. </summary>
        public List<Scholar>? Scholars { get; set; }

        public bool IsRemoved { get; set; }
    }
}
