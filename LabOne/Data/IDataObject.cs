using Microsoft.Build.Framework;

namespace LabOne.Data
{
    /// <summary>Представляет объект данных из БД. </summary>
    public interface IDataObject
    {
        /// <summary>Идентификатор объекта в БД. </summary>
        string? Id { get; set; }

        /// <summary>Возвращает или задает состояние (удален/не удален) объекта. </summary>
        bool IsRemoved { get; set; }
    }
}
