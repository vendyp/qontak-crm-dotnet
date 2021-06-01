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
                        

            return ctr;
        }
    }
}
