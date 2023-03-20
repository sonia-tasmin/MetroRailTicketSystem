﻿using MediatR;
using Shared.Security;

namespace Shared.Commands.User
{
    public class UpdateUserCommand : IRequest<object>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public bool UserTypeStatus { get; set; }
    }
}
