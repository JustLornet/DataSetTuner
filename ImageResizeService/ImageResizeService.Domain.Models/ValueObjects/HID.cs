namespace ImageResizeService.Domain.Models.ValueObjects
{
    /// <summary>
    /// Реализация HierarchyId.
    /// </summary>
    public class HID
    {
        private string _hid = string.Empty;

        public string Value => _hid;

        internal void SetHid(string hidValue)
        {
            // TODO: валидация
        } 
    }
}
