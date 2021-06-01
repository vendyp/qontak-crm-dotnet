using System.Collections.Generic;

namespace Qontak.Crm.Tests.Functional
{
    public static class DealInfoConstruction
    {
        public static List<Info> GetInfoesDummy()
        {
            var list = new List<Info>();

            list.Add(new Info
            {
                Id = 1,
                Name = "name",
                NameAlias = "Deal Name",
                Required = true,
                AdditionalField = false,
                Type = "Single-line text",
                Dropdown = null
            });

            list.Add(new Info
            {
                Id = 2,
                Name = "creator_id",
                NameAlias = "Owner",
                Required = true,
                AdditionalField = false,
                Type = "Dropdown select",
                Dropdown = new List<Dropdown>
                {
                    new Dropdown
                    {
                        Id = 1,
                        Name = "Lorep Ipsum"
                    }
                }
            });

            return list;
        }
    }
}
