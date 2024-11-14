using PayCard.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCard.Domain.Finance.Factories
{
    public interface ITransactionFactory : IFactory<Transaction>
    {
    }
}
