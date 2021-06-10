using System;

namespace Qontak.Crm.Tests.Functional
{
    public static class CreateDealOptionsConstruction
    {
        public static CreateDealOptions Create()
        {
            return new CreateDealOptions(1, 2);
        }

        public static CreateDealOptions Create(int pipelineId, int stageId)
        {
            return new CreateDealOptions(pipelineId, stageId);
        }

        public static CreateDealOptions CreateDealDummy(int pipelineId, int stageId)
        {
            var ctr = new CreateDealOptions(pipelineId, stageId);

            ctr.Name = "Deal Test";
            ctr.Currency = "IDR";
            ctr.ClosedDate = DateTime.UtcNow;
            ctr.StartDate = DateTime.UtcNow.AddDays(-7);
            ctr.ExpiredDate = DateTime.UtcNow.AddDays(14);

            return ctr;
        }
    }
}
