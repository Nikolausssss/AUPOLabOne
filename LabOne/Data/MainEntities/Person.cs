using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabOne.Data.MainEntities
{
    /// <summary>Представляет абстрактный класс для данных о личности. </summary>
    public abstract class Person : IDataObject
    {
        public string? Id { get; set; }

        /// <summary>Возвращает или задает имя. </summary>
        [Required, 
         RegularExpression(@"[А-Я][а-я]+", ErrorMessage = "Неккоретное имя")]
        public string FirstName { get; set; } = null!;

        /// <summary>Возвращает или задает фамилию. </summary>
        [Required,
            RegularExpression(@"[А-Я][а-я]+", ErrorMessage = "Неккоретная фамилия")]
        public string SecondName { get; set; } = null!;

        /// <summary>Возвращает или задает отчество. </summary>
        [Required,
            RegularExpression(@"[А-Я][а-я]+", ErrorMessage = "Неккоретное отчество")]
        public string Surname { get; set; } = null!;
        
        /// <summary>Возвращает полное имя личности в виде Фамилия И. О. </summary>
        [NotMapped]
        public string FullName => $"{SecondName} {FirstName?.FirstOrDefault()}. {Surname?.FirstOrDefault()}";

        public bool IsRemoved { get; set; }
    }
}
