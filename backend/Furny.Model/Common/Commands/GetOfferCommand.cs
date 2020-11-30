using Furny.Model;

namespace Furny.Common.Commands
{
    public class GetOfferCommand : GetCommand<Offer>
    {
        public GetOfferCommand(string id)
        {
            Id = id;
        }

        public static GetOfferCommand Create(string id)
            => new GetOfferCommand(id);
    }
}
