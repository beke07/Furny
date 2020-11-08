using Furny.AuthFeature.ServiceInterfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Furny.AuthFeature.Commands
{
    public class AuthFeatureIsCommandHandler :
        IRequestHandler<AuthFeatureIsNotRegistratedCommand, bool>,
        IRequestHandler<AuthFeatureLoginCommand, string>,
        IRequestHandler<AuthFeatureLogoutCommand>,
        IRequestHandler<AuthFeatureRegisterDesignerCommand>,
        IRequestHandler<AuthFeatureRegisterPanelCutterCommand>
    {
        private readonly IAuthService _authService;

        public AuthFeatureIsCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<bool> Handle(AuthFeatureIsNotRegistratedCommand request, CancellationToken cancellationToken)
            => await _authService.IsNotRegistratedAsync(request.Email);

        public async Task<string> Handle(AuthFeatureLoginCommand request, CancellationToken cancellationToken)
            => await _authService.LoginAsync(request.Login);

        public async Task<Unit> Handle(AuthFeatureLogoutCommand request, CancellationToken cancellationToken)
        {
            await _authService.LogoutAsync();

            return Unit.Value;
        }

        public async Task<Unit> Handle(AuthFeatureRegisterDesignerCommand request, CancellationToken cancellationToken)
        {
            await _authService.RegisterDesigner(request.Register);

            return Unit.Value;
        }

        public async Task<Unit> Handle(AuthFeatureRegisterPanelCutterCommand request, CancellationToken cancellationToken)
        {
            await _authService.RegisterPanelCutter(request.Register);

            return Unit.Value;
        }
    }
}
