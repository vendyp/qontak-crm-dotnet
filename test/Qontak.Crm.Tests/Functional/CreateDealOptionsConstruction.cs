using System;

namespace Qontak.Crm.Tests.Functional
{
    public static class CreateDealOptionsConstruction
    {
        public static CreateDealOptions Create()
        {
            return new CreateDealOptions();
        }

        public static CreateDealOptions CreateDealDummy()
        {
            var ctr = new CreateDealOptions();

            ctr.Name = "Deal Test";
            ctr.Currency = "IDR";
            ctr.ClosedDate = DateTime.UtcNow;
            ctr.StageId = 1;
            ctr.StartDate = DateTime.UtcNow.AddDays(-7);
            ctr.ExpiredDate = DateTime.UtcNow.AddDays(14);

            return ctr;
        }
    }
}
