using System.ComponentModel.DataAnnotations;

namespace LabOne.Data.MainEntities
{
    /// <summary>Представляет данные о школьнике. </summary>
    public class Scholar : Person
    {
        /// <summary>Возвращает или задает Id класса ученика. </summary>
        public string CourseId { get; set; } = null!;

        /// <summary>Возвращет или задает класс ученика. </summary>
        public Course? Course { get; set; }
    }
}
