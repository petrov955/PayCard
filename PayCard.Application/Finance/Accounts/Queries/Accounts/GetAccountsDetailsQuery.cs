using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCard.Application.Finance.Accounts.Queries.Accounts
{
    public class GetAccountsDetailsQuery : IRequest<IEnumerable<GetAccountDetailsOutputModel>>
    {
        public GetAccountsDetailsQuery(long userId, bool getActive)
        {
            UserId = userId;
            GetActive = getActive;
        }

        public long UserId { get; }
       
        public bool GetActive { get; }
       
        
        
        
       
    }
}
