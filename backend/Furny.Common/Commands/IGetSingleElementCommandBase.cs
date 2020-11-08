namespace Furny.Common.Commands
{
    public interface IGetSingleElementCommandBase
    {
        public string Id { get; set; }

        public string ElementId { get; set; }
    }
}
