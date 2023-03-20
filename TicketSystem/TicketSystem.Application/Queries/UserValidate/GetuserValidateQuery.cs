using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Application.Queries.UserValidate;

public record GetuserValidateQuery(string email,string password) : IRequest<object>;

