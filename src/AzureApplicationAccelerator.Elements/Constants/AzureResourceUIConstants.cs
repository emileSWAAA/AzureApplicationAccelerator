namespace AzureApplicationAccelerator.Elements.Constants
{
    public class AzureResourceUIConstants
    {
        public static class CreateUiDefinition
        {
            public const string Schema = "https://schema.management.azure.com/schemas/0.1.2-preview/CreateUIDefinition.MultiVm.json#";
            public const string Handler = "Microsoft.Azure.CreateUIDef";
            public const string Version = "0.1.2-preview";

            public static class Steps
            {
                public static Guid BasicsId = Guid.Parse("ED688F25-252B-475E-9814-25E31AE2D857");
                public static string BasicsName = "Basics";

                public static Guid ReviewAndCreateId = Guid.Parse("4687DBA5-CF2F-40CB-ACF2-C8E338988ED8");
                public static string ReviewAndCreateName = "Review and Create";
            }
        }
    }
}
