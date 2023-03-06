namespace LabOne.Data.Catalogs
{
    /// <summary>Представляет реализацию метода для сравнения объектов <see cref="Parallel"/> </summary>
    public class ParallelComparer : IComparer<Parallel>
    {
        public int Compare(Parallel? x, Parallel? y)
        {
            return x?.Number.CompareTo(y?.Number ?? 0) ?? -1;
        }
    }
}
