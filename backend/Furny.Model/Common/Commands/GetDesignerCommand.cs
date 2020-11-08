using Furny.Common.Commands;

namespace Furny.Model.Common.Commands
{
    public class GetDesignerCommand : GetCommand<Designer>
    {
        public GetDesignerCommand(string id) : base(id)
        { }

        public static GetDesignerCommand Create(string id)
            => new GetDesignerCommand(id);
    }
}
