using System;
using System.Collections.Generic;
using System.Linq;

namespace Qontak.Crm
{
    public class CreateDealOptionsValidator
    {
        private readonly CreateDealOptions _options;
        private readonly IEnumerable<Info> _infoes;

        public CreateDealOptionsValidator(CreateDealOptions options, IEnumerable<Info> infoes)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (infoes is null || infoes.Count() < 1)
            {
                throw new ArgumentNullException(nameof(infoes));
            }
            _options = options;
            _infoes = infoes;
        }

        public bool IsValid => IsValidated();

        private bool IsValidated()
        {
            return false;
        }
    }
}
